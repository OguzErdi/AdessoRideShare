using AdessoRideShare.Application.ResultTypes;
using AdessoRideShare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Application.Interfaces
{
    public interface IRideService
    {
        Task<IDataResult<List<Ride>>> GetRidesAsync(string beginning, string destination);
        Task<IDataResult<List<Ride>>> GetRidesAsync();
        Task<IResult> AddRideAsync(Ride ride);
        Task<IResult> JoinRide(string passangerUsername, string id);
        Task<IResult> SetRideActiveness(string id, bool isActive);
    }
}
