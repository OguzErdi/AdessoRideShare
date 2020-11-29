using AdessoRideShare.Application.Helpers.Interfaces;
using AdessoRideShare.Application.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Application.Helpers
{
    public class CityParser : ICityParser
    {
        private readonly char[] delimiterChars = {','};
        private readonly ILogger<CityParser> logger;

        public CityParser(ILogger<CityParser> logger)
        {
            this.logger = logger;
        }

        public City GetCityFrom(string value)
        {
            try
            {
                string[] coordinates = value.Split(delimiterChars);

                var x = int.Parse(coordinates[0]);
                var y = int.Parse(coordinates[1]);

                return new City(x, y);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
