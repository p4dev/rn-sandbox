using System;
using System.Globalization;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;



namespace Server
{
    partial class Program
    {
        private static void AddConfigEndpoints(WebApplication app)
        {
            app.MapGet("/models/{terminalId}", (int terminalId, IConfigService configService) =>
            {
                var dateString = $"[\"{configService.LastUpdatedString}\"]";
                Console.WriteLine($"Theme change check for terminalId-{terminalId} {dateString}");
                return dateString;
            });

            app.MapGet("/{terminalId}/{user}/status", (string terminalId, string user, IConfigService configService) =>
            {
                Console.WriteLine($"Status for terminalId-{terminalId}, user-{user}");

                return configService.DeviceStatus;
            });

            app.MapGet("/config/{terminalId}", (int terminalId, IConfigService configService) =>
            {
                Console.WriteLine("Get config");
                return configService.Config;
            });

            app.MapPost("/themeupdate", (IConfigService configService) =>
            {
                Console.WriteLine("Force theme update");
                configService.ForceUpdate();
            });

            app.MapGet("/message", (IConfigService configService) =>
            {
                Console.WriteLine("Get message");
                return configService.Messages;
            });

            app.MapDelete("/limitedstock/{id}", (long id, IConfigService configService) =>
            {
                Console.WriteLine($"Delete limited stock - {id}");
                return configService.RemoveLimitedStock(id) ? Results.Accepted() : Results.NotFound();
            });

            app.MapDelete("/outofstock/{id}", (long id, IConfigService configService) =>
            {
                Console.WriteLine($"Delete out of stock - {id}");
                return configService.RemoveOutOfStock(id) ? Results.Accepted() : Results.NotFound();
            });

            app.MapPost("/limitedstock", ([FromBody] LimitedStock limitedStock, IConfigService configService) =>
            {
                Console.WriteLine($"Post limited stock - {limitedStock.IngredientId} {limitedStock.QuantityRemaining}");
                configService.AddLimitedStock(limitedStock.IngredientId, limitedStock.QuantityRemaining);
            });

            app.MapPost("/outofstock", ([FromBody] OutOfStock outofStock, IConfigService configService) =>
            {
                Console.WriteLine($"Post out of stock - {outofStock.IngredientId}");
                configService.AddOutOfStock(outofStock.IngredientId);
            });

            app.MapPost("/message", ([FromBody] NewMessage data, IConfigService configService) =>
            {
                Console.WriteLine($"Post message - {data.subject} - {data.body}");
                var message = IZoneMessage.CreateMessage(data.subject, data.body, configService.Messages.Any() ? configService.Messages.Max(o => o.Id) : 0);
                configService.Messages.Add(message);
                return message;
            });

            app.MapGet("/pricelist/{terminalId}", (string terminalId, IConfigService configService, IEnvironmentService environmentService) =>
            {
                Console.WriteLine($"Get pricelist");
                var pricelist = ResourceLoader.GetResourceTextFile(environmentService.PriceListFile);
                return pricelist.Replace("_LAST_MODIFIED_", configService.LastUpdatedString);
            });
            app.MapPost("/PaymentProviderConfigurations/FreedomPay", ([FromBody] RSAPublicKeyRequest request) =>
            {
                Console.WriteLine("Post RSA public key");
                try
                {
                    // Import the PEM-encoded public key using the RSAUtility
                    using var rsa = RSAUtility.ImportPublicKey(request.PublicKey.N);

                    var dataToEncrypt = Encoding.UTF8.GetBytes("batman"); // secure data to encrypt
                    var encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
                    var encryptedDataString = Convert.ToBase64String(encryptedData);

                    // Construct response with the encrypted data
                    var response = new RSAResponse
                    {
                        StoreId = "1520659978",
                        TerminalId = "2523115976",
                        DisabledEFTMerchantReceipt = true,
                        ServiceUrl = "https://cs.uat.freedompay.com/Fasta/",
                        ESKey = encryptedDataString // Encrypted data here
                    };

                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return Results.Problem("An error occurred during RSA encryption.");
                }
            });
        }
    }
}

