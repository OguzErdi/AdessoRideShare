using AdessoRideShare.Application.Constants;
using AdessoRideShare.Application.Helpers.Interfaces;
using AdessoRideShare.Application.Interfaces;
using AdessoRideShare.Application.ResultTypes;
using AdessoRideShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Application.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRideService rideService;
        private readonly ICityParser cityParser;

        public RotaService(IRideService rideService, ICityParser cityParser)
        {
            this.rideService = rideService;
            this.cityParser = cityParser;
        }

        public async Task<IDataResult<List<Ride>>> FindRidesInRota(string beginnig, string destination)
        {
            var begginingCity = cityParser.GetCityFrom(beginnig);
            var destinationCity = cityParser.GetCityFrom(destination);

            var allRidesResult = await rideService.GetRidesAsync();

            var searchList = new List<Ride>();

            foreach (var ride in allRidesResult.Data)
            {
                var isInXRange = false;
                var isInYRange = false;
                var rideBegginingCity = cityParser.GetCityFrom(ride.Beginning);
                var rideDestinationCity = cityParser.GetCityFrom(ride.Destination);

                if (rideBegginingCity == null || rideDestinationCity == null)
                {
                    continue;
                }

                //for determine left or right
                if (begginingCity.x <= destinationCity.x)
                {
                    if (rideBegginingCity.x <= rideDestinationCity.x)
                    {
                        //for determine in X range
                        if (begginingCity.x <= rideBegginingCity.x && destinationCity.x >= rideDestinationCity.x)
                        {
                            isInXRange = true;
                        }
                    }
                }
                else
                {
                    if (rideBegginingCity.x >= rideDestinationCity.x)
                    {
                        //for determine in X range
                        if (begginingCity.x >= rideBegginingCity.x && destinationCity.x <= rideDestinationCity.x)
                        {
                            isInXRange = true;
                        }
                    }
                }

                //for determine up or down
                if (begginingCity.y <= destinationCity.y)
                {
                    if (rideBegginingCity.y <= rideDestinationCity.y)
                    {
                        //for determine in Y range
                        if (begginingCity.y <= rideBegginingCity.y && destinationCity.y >= rideDestinationCity.y)
                        {
                            isInYRange = true;
                        }
                    }
                }
                else
                {
                    if (rideBegginingCity.y >= rideDestinationCity.y)
                    {
                        //for determine in Y range
                        if (begginingCity.y >= rideBegginingCity.y && destinationCity.y <= rideDestinationCity.y)
                        {
                            isInYRange = true;
                        }
                    }
                }

                if (isInXRange && isInYRange)
                {
                    searchList.Add(ride);
                }
            }

            return new SuccessDataResult<List<Ride>>(searchList, Messages.FindRidesInRota);
        }
    }
}
