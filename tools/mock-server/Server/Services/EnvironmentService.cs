using System;
namespace Server.Services
{
	internal interface IEnvironmentService
	{
        public string ConfigFile { get; }
        public string PriceListFile { get; }
        public string DeviceStatusFile { get; }
        public string DeviceListFile { get; }
    }

    internal class EnvironmentService : IEnvironmentService
	{
		readonly string _configFile;
		readonly string _pricelistFile;
		readonly string _deviceStatusFile;
		readonly string _deviceListFile;

        public EnvironmentService(string configFile, string pricelistFile, string deviceStatusFile, string deviceListFile)
		{
            _configFile = configFile;
            _pricelistFile = pricelistFile;
            _deviceListFile = deviceListFile;
            _deviceStatusFile = deviceStatusFile;
		}

        public string ConfigFile => _configFile;
        public string PriceListFile => _pricelistFile;
        public string DeviceStatusFile => _deviceStatusFile;
        public string DeviceListFile =>_deviceListFile;
    }
}

