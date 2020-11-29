using AdessoRideShare.Application.ResultTypes;
using AdessoRideShare.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.Application.Services
{
    public interface IRotaService
    {
        public Task<IDataResult<List<Ride>>> FindRidesInRota(string beginnig, string destination);
    }
}