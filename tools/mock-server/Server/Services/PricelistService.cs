using System;
using Newtonsoft.Json.Linq;
using Server.Models;

namespace Server.Services
{
    internal interface IPricelistService
	{
		public List<Table> Tables { get; }
	}

    internal class PricelistService : IPricelistService
    {
        readonly IEnvironmentService _environmentService;

        public PricelistService(IEnvironmentService environmentService)
		{
            _environmentService = environmentService;
		}

        readonly List<Table> _tables = new List<Table>();
        public List<Table> Tables
        {
            get
            {
                if (!_tables.Any())
                {
                    LoadTables();
                }

                return _tables;
            }
        }

        void LoadTables()
        {
            var pricelist = ResourceLoader.GetResourceTextFile(_environmentService.PriceListFile);

            JObject results = JObject.Parse(pricelist);

            foreach (var result in results["Tables"])
            {
                JToken number = result["Number"];
                _tables.Add(new Table { Number = Convert.ToInt32(((JValue)number).Value) });
            }
        }
    }
}

