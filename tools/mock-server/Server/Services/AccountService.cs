using System;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Services
{
	internal interface IAccountService
	{
        List<AccountSearch> AccountSearch { get; }
        Dictionary<string, Account> Accounts { get; }
		string NextAccountNumber();
        string AllocateTable(string accountNumber);
        Account CurrentAccountForTerminal(string terminalId);
        void SetAccountForTerminal(string terminalId, Account account);
    }

    internal class AccountService : IAccountService
    {
		readonly IConfigService _configService;
		readonly IPricelistService _pricelistService;

        List<AccountSearch> _accountSearch;
        public List<AccountSearch> AccountSearch
		{
			get
			{
				if (_accountSearch == null)
				{
					LoadAccountSearch();
				}

				return _accountSearch;
			}
		}

        public AccountService(IConfigService configService, IPricelistService pricelistService)
		{
			_configService = configService;
			_pricelistService = pricelistService;
        }

        Dictionary<string, Account> _accounts = new Dictionary<string, Account>();
        public Dictionary<string, Account> Accounts
		{
			get
			{
				return _accounts;
			}
		}

        public Account CurrentAccountForTerminal(string terminalId)
        {
            if (!_currentAccounts.ContainsKey(terminalId))
            {
                _currentAccounts[terminalId] = Account.CreateAccount(NextAccountNumber(), AllocateTable((_accountNo).ToString()));
            }
            return _currentAccounts[terminalId];
        }

        public void SetAccountForTerminal(string terminalId, Account account)
        {
            _currentAccounts[terminalId] = account;
        }

        readonly Dictionary<string, Account> _currentAccounts = new Dictionary<string, Account>();

        int _accountNo = 5923;

		public string NextAccountNumber()
		{
			return (++_accountNo).ToString();
        }

        void LoadAccountSearch()
        {
            var accountSearch = ResourceLoader.GetResourceTextFile("accountSearch.json");

            _accountSearch = JsonConvert.DeserializeObject<List<AccountSearch>>(accountSearch);

            foreach (var result in _accountSearch)
            {
                _accounts.Add(result.AccountNumber, Account.CreateAccount(result.AccountNumber, result.TableNumber));
            }
        }

        public string AllocateTable(string accountNumber)
        {
            var used = AccountSearch.Select(o => Convert.ToInt32(o.TableNumber)).ToList();
            var available = _pricelistService.Tables.Where(c => !used.Contains(c.Number)).OrderBy(o => o.Number).First();
            AccountSearch.Add(new AccountSearch { TableNumber = available.Number.ToString(), AccountNumber = accountNumber });
            return available.Number.ToString();
        }

    }
}

