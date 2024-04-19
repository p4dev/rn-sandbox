using System;
using System.Collections.Generic;
using System.Globalization;
using System.Timers;
using System.Xml;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Services
{
    internal interface IConfigService
    {
        DeviceInfo[] Devices { get; }
        DateTime LastUpdated { get; }
        string LastUpdatedString { get; }
        List<IZoneMessage> Messages { get; }
        DeviceStatus DeviceStatus { get; }
        public Config Config { get; }

        void AddOutOfStock(long id);
        void AddLimitedStock(long id, int qty);
        bool RemoveOutOfStock(long id);
        bool RemoveLimitedStock(long id);
        string GetTheme(int terminalId);

        public void ForceUpdate();
    }

    internal class ConfigService : IConfigService
    {
        DeviceStatus _deviceStatus = null;

        DateTime _lastUpdated;

        public DateTime LastUpdated
        {
            get
            {
                return _lastUpdated;
            }
        }

        string _lastUpdatedString;
        public string LastUpdatedString
        {
            get
            {
                return _lastUpdatedString;
            }
        }

        public DeviceStatus DeviceStatus
        {
            get
            {
                if (_deviceStatus == null)
                {
                    var data = ResourceLoader.GetResourceTextFile(_environmentService.DeviceStatusFile);
                    _deviceStatus = JsonConvert.DeserializeObject<DeviceStatus>(data);
                }
                return _deviceStatus;
            }
        }

        public string GetTheme(int terminalId)
        {
            var data = ResourceLoader.GetResourceTextFile("theme.xml");
            return data;
        }


        readonly List<IZoneMessage> _messages = new List<IZoneMessage>();
        public List<IZoneMessage> Messages => _messages;

        DeviceInfo[]? _devices = null;

        public DeviceInfo[] Devices
        {
            get
            {
                if (_devices == null)
                {
                    var data = ResourceLoader.GetResourceTextFile(_environmentService.DeviceListFile);
                    _devices = JsonConvert.DeserializeObject<DeviceInfo[]>(data);
                }
                return _devices;
            }
        }

        public void AddOutOfStock(long id)
        {
            if (!DeviceStatus.OutOfStock.Contains(id))
            {
                DeviceStatus.OutOfStock.Add(id);
            }
        }

        public void AddLimitedStock(long id, int qty)
        {
            var existing = DeviceStatus.LimitedStock.FirstOrDefault(o => o.IngredientId == id);

            if (existing != null)
            {
                existing.QuantityRemaining = qty;
            }
            else
            {
                DeviceStatus.LimitedStock.Add(new LimitedStock { IngredientId = id, QuantityRemaining = qty });
            }
        }

        public bool RemoveOutOfStock(long id)
        {
            if (DeviceStatus.OutOfStock.Contains(id))
            {
                DeviceStatus.OutOfStock.Remove(id);
                return true;
            }
            return false;
        }

        public bool RemoveLimitedStock(long id)
        {
            var existing = DeviceStatus.LimitedStock.FirstOrDefault(o => o.IngredientId == id);

            if (existing != null)
            {
                DeviceStatus.LimitedStock.Remove(existing);
                return true;
            }
            return false;
        }

        public void ForceUpdate()
        {
            SetLastUpdated();
            _config = null;
        }

        Config? _config = null;

        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    var data = LoadConfigFile();
                    _config = JsonConvert.DeserializeObject<Config>(data);
                }
                return _config;
            }
        }

        string? LoadConfigFile()
        {
            var data = ResourceLoader.GetResourceTextFile(_environmentService.ConfigFile);
            var updated = data.Replace("_LAST_MODIFIED_", _lastUpdated.ToString("o", CultureInfo.InvariantCulture));
            return updated;
        }

        readonly IPricelistService _pricelistService;
        readonly IEnvironmentService _environmentService;

        public ConfigService(IPricelistService pricelistService, IEnvironmentService environmentService)
		{
            _pricelistService = pricelistService;
            _environmentService = environmentService;
            SetLastUpdated();
        }

        void SetLastUpdated()
        {
            _lastUpdated = DateTime.UtcNow;
            _lastUpdatedString = LastUpdated.ToString("o");
        }
    }
}