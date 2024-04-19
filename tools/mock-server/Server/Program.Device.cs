using System;
using Server.Models;
using Server.Services;

namespace Server
{
	partial class Program
	{
        private static void AddDeviceEndpoints(WebApplication app)
        {
            app.MapGet("/theme/{terminalId}", (int terminalId, IConfigService configService) => new XmlResult(configService.GetTheme(terminalId)));

            app.MapGet("/0/0/device/list", (IConfigService configService) =>
            {
                Console.WriteLine("Device List");
                return configService.Devices;
            });

            app.MapPost("/0/0/device/autopair", (int salesAreaId, string device, IConfigService configService) =>
            {
                var devices = configService.Devices;
                var deviceStatus = configService.DeviceStatus;
                var matching = devices.FirstOrDefault(o => o.SalesAreaId == salesAreaId && string.IsNullOrEmpty(o.Device));
                if (matching != null)
                {
                    matching.Device = device;
                }
                matching = deviceStatus.Devices.FirstOrDefault(o => o.SalesAreaId == salesAreaId && string.IsNullOrEmpty(o.Device));
                if (matching != null)
                {
                    matching.Device = device;
                }

                Console.WriteLine("Autopair");
                return new AutoPair { PosId = matching.Id };
            });

            app.MapPost("/{terminalId}/0/device/pair", (int terminalId, string pin, string device, IConfigService configService) =>
            {
                var devices = configService.Devices;
                var deviceStatus = configService.DeviceStatus;
                var matching = devices.FirstOrDefault(o => o.Id == terminalId);
                if (matching != null)
                {
                    matching.Device = device;
                }
                var config = configService.Config;
                var employee = config.Employees.FirstOrDefault(o => o.Password == pin);
                if (employee != null)
                {
                    matching.User = employee.Id;
                }
                matching = deviceStatus.Devices.FirstOrDefault(o => o.Id == terminalId);
                if (matching != null)
                {
                    matching.Device = device;
                    matching.User = employee.Id;
                }

                Console.WriteLine($"Pair terminalId-{terminalId} with pin-{pin} for device-{device}");
                return new AutoPair { PosId = matching.Id };
            });

            app.MapPost("/{terminalId}/0/device/unpair", (int terminalId, IConfigService configService) =>
            {
                var devices = configService.Devices;
                var deviceStatus = configService.DeviceStatus;
                var matching = devices.FirstOrDefault(o => o.Id == terminalId);
                if (matching != null)
                {
                    matching.Device = null;
                    matching.User = 0;
                }
                matching = deviceStatus.Devices.FirstOrDefault(o => o.Id == terminalId);
                if (matching != null)
                {
                    matching.Device = null;
                    matching.User = 0;
                }
                Console.WriteLine($"Unpair terminalId-{terminalId}");
                return "";
            });

            app.MapGet("/{terminalId}/0/device/info", (int terminalId, IConfigService configService) =>
            {
                Console.WriteLine($"Device info for terminalId-{terminalId}");
                var devices = configService.Devices;
                var config = configService.Config;

                var device = devices.FirstOrDefault(o => o.Id == terminalId);

                if (device == null) return "";

                return
                    $@"{{
    ""ApiVersion"": ""2.35"",
    ""ServiceVersion"": ""4.38.0.31"",
    ""PosVersion"": ""3.21.0.56373"",
    ""PosId"": {device.Id},
    ""Pos"": ""{device.Name}"",
    ""TerminalId"": {device.Id},
    ""Terminal"": ""{device.Name}"",
    ""SalesAreaId"": {device.SalesAreaId},
    ""SalesArea"": ""{device.SalesArea}"",
    ""SiteId"": {config.SiteId},
    ""Site"": ""{config.Site}"",
    ""AreaId"": 3,
    ""Area"": ""01 North"",
    ""CompanyId"": 1,
    ""Company"": ""Pizza Express""
}}";
            });

        }

    }
}
