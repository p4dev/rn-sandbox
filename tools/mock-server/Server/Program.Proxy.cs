using System;
using Server.Models;

namespace Server
{
    partial class Program
    {
        private static void AddProxyEndpoints(WebApplication app)
        {
            app.MapGet("/proxy/aztecrest/zcps/status", () =>
            {
                Console.WriteLine("Aztec Status");
                var status = new object[] {
                    new Engine { Title = "Engine", Version = "1.1.9" },
                    new Plugin { Title = "Ocius", Version = "1.5.0", Text = "Running" }
                };
                return status;
            });

            app.MapGet("/proxy/iserveconfig/v7/config", () =>
            {
                Console.WriteLine($"Get v7 config");
                return Results.NotFound();
            });


            app.MapGet("/proxy/iserveconfig/v6/config", () =>
            {
                Console.WriteLine($"Get v6 config");
                return ResourceLoader.GetResourceTextFile("v6config.json");
            });

            app.MapGet("/proxy/iserveconfig/v5/config", () =>
            {
                Console.WriteLine($"Get v5 config");
                throw new Exception("Error");
            });

            app.MapPost("/proxy/AztecRest/ledger/search", () =>
            {
                Console.WriteLine($"AztecRest ledger search");
                return ResourceLoader.GetResourceTextFile("aztec-ledger-search.json");
            });
        }
    }
}

