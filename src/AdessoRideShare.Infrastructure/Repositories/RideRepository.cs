using AdessoRideShare.Core.Data;
using AdessoRideShare.Core.Entities;
using AdessoRideShare.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Infrastructure.Repositories
{
    public class RideRepository : IRideRepository
    {
        private readonly IRideDbContext _context;

        public RideRepository(IRideDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRideAsync(Ride journey)
        {
            string jsonRide = JsonConvert.SerializeObject(journey);

            var isAdded = await _context.Redis.StringSetAsync(journey.Id.ToString(), jsonRide);

            if (!isAdded)
            {
                return false;
            }

            return true;
        }

        public async Task<Ride> GetRideAsync(string id)
        {
            var ride = await _context.Redis.StringGetAsync(id);
                
            if (ride.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Ride>(ride);
        }

        public async Task<List<Ride>> GetRidesAsync(string beginning, string destination)
        {
            var searchList = new List<Ride>();

            foreach (var key in _context.Server.Keys())
            {
                var ride = await GetRideAsync(key);
                if (ride.IsActive && ride.Beginning == beginning && ride.Destination == destination)
                {
                    searchList.Add(ride);
                }
            }

            return searchList;
        }

        public async Task<List<Ride>> GetRidesAsync()
        {
            var searchList = new List<Ride>();

            foreach (var key in _context.Server.Keys())
            {
                var ride = await GetRideAsync(key);
                if (ride.IsActive)
                {
                    searchList.Add(ride);
                }
            }

            return searchList;
        }
    }
}
