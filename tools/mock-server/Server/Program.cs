using System.Globalization;
using System.Timers;
using Server.Models;
using Server.Services;

namespace Server
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
                options =>
                {
                    options.SerializerOptions.PropertyNamingPolicy = null;
                }
                );

            string configFile = GetConfigFile(args);
            string pricelistFile = GetPricelistFile(args);
            const string deviceStatusFile = "devicestatus.json";
            const string deviceListFile = "devicelist.json";

            builder.Services.AddSingleton<IEnvironmentService>(new EnvironmentService(configFile, pricelistFile, deviceStatusFile, deviceListFile));
            builder.Services.AddSingleton<IConfigService, ConfigService>();
            builder.Services.AddSingleton<IAccountService, AccountService>();
            builder.Services.AddSingleton<IPricelistService, PricelistService>();

            int _lineID = 1;


            var app = builder.Build();

            AddAccountEndpoints(app);
            AddDeviceEndpoints(app);
            AddProxyEndpoints(app);
            AddConfigEndpoints(app);

            app.MapGet("/ping", () =>
            {
                Console.WriteLine($"Ping");
                return "OK";
            });

            app.Run();
        }

        static string PE_Dataset = "PE";
        static string iHop_Dataset = "IHOP";

        static string GetConfigFile(string[] args)
        {
            if (args.Any())
            {
                string type = args.First().ToUpper();

                if (type == PE_Dataset)
                {
                    Console.WriteLine("Selected Pizza Express Config");
                    return "PEconfig.json";
                }

                if (type == iHop_Dataset)
                {
                    Console.WriteLine("Selected iHop Config");
                    return "iHopconfig.json";
                }
            }

            Console.WriteLine("Selected Xam Config");
            return "config.json";
        }

        static string GetPricelistFile(string[] args)
        {
            if (args.Any())
            {
                string type = args.First().ToUpper();

                if (type == PE_Dataset)
                {
                    Console.WriteLine("Selected Pizza Express Pricelist");
                    return "PEpricelist.json";
                }

                if (type == iHop_Dataset)
                {
                    Console.WriteLine("Selected iHop Pricelist");
                    return "iHoppricelist.json";
                }
            }

            Console.WriteLine("Selected Xam Pricelist");
            return "pricelist1.json";
        }
    }
}
