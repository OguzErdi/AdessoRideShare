using AdessoRideShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Core.Repositories
{
    public interface IRideRepository
    {
        Task<Ride> GetRideAsync(string id);
        Task<List<Ride>> GetRidesAsync(string beginning, string destination);
        Task<List<Ride>> GetRidesAsync();
        Task<bool> AddRideAsync(Ride ride);
    }
}
