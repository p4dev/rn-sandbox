using System;
using Server.Models;
using Server.Services;

namespace Server
{
	partial class Program
	{
		private static void AddAccountEndpoints(WebApplication app)
		{
            app.MapGet("/{terminalId}/{user}/account/fetch/{accountNo}", (string terminalId, string user, string accountNo, IAccountService accountService, IConfigService configService) =>
            {
                Console.WriteLine("Get account/fetch ");
                if (accountService.Accounts.ContainsKey(accountNo))
                {
                    return accountService.Accounts[accountNo];
                }
                else
                {
                    // 1.24 passes in bad param
                    var newAcc = (accountNo == "(null)?steal=0");
                    if (newAcc)
                    {
                        accountNo = accountService.NextAccountNumber();
                    }
                    var account = Account.CreateAccount(accountNo, accountService.AllocateTable(accountNo));
                    accountService.Accounts[accountNo] = account;
                    return account;
                }
            });

            app.MapGet("/{terminalId}/{user}/account/search", (string terminalId, string user, IAccountService accountService) =>
            {
                Console.WriteLine("Get account/search ");
                return accountService.AccountSearch;
            });

            app.MapGet("/{terminalId}/{user}/account/current", (string terminalId, string user, IAccountService accountService) =>
            {
                Console.WriteLine("Get account/current ");

                return accountService.CurrentAccountForTerminal(terminalId);
            });

            int _lineID = 1;

            app.MapPost("/{terminalId}/{user}/account/order", (string terminalId, string user, Account data, IAccountService accountService, IConfigService configService) =>
            {
                Console.WriteLine("Post account/order");
                if (string.IsNullOrEmpty(data.AccountNumber))
                {
                    data.AccountNumber = accountService.NextAccountNumber();
                    data.AccountId = Convert.ToInt64(data.AccountNumber);
                    data.MoaOrderIdentifier = data.AccountNumber;
                    data.CLMAccountId = "";
                }
                if (string.IsNullOrEmpty(data.TableNumber))
                {
                    data.TableNumber = accountService.AllocateTable(data.AccountNumber);
                }
                double total = 0;
                foreach (var line in data.Lines)
                {
                    line.SentToKitchen = true;
                    line.OriginalRingUpTime = DateTime.Now;
                    line.Id = _lineID++;
                    total += line.TariffPrice ?? 0;
                }
                data.AccountTotal = total;
                //data.SaveAccount = false;
                accountService.Accounts[data.AccountNumber] = data;
                accountService.SetAccountForTerminal(terminalId, data);
                return data;
            });
        }
    }
}

