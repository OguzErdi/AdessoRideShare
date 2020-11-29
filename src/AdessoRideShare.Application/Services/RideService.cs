using AdessoRideShare.Application.Constants;
using AdessoRideShare.Application.Interfaces;
using AdessoRideShare.Application.ResultTypes;
using AdessoRideShare.Core.Entities;
using AdessoRideShare.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Application.Services
{
    public class RideService : IRideService
    {
        private IRideRepository rideRepository;

        public RideService(IRideRepository rideRepository)
        {
            this.rideRepository = rideRepository;
        }

        public async Task<IResult> AddRideAsync(Ride ride)
        {
            ride.Id = Guid.NewGuid();
            ride.Passangers = new List<string>();
            ride.IsActive = true;

            var result = await rideRepository.AddRideAsync(ride);

            if (!result)
            {
                return new ErrorResult(Messages.RideNotAdded);
            }

            return new SuccessResult(Messages.RideAdded);
        }

        public async Task<IDataResult<List<Ride>>> GetRidesAsync(string beginning, string destination)
        {
            var list = await rideRepository.GetRidesAsync(beginning, destination);

            if (list.Count == 0)
            {
                return new ErrorDataResult<List<Ride>>(Messages.NoRidesFound);
            }

            return new SuccessDataResult<List<Ride>>(list, Messages.RidesWereFound);
        }

        public async Task<IDataResult<List<Ride>>> GetRidesAsync()
        {
            var list = await rideRepository.GetRidesAsync();

            if (list.Count == 0)
            {
                return new ErrorDataResult<List<Ride>>(Messages.NoRidesFound);
            }

            return new SuccessDataResult<List<Ride>>(list, Messages.RidesWereFound);
        }

        public async Task<IResult> JoinRide(string passangerUsername, string id)
        {
            var ride = await rideRepository.GetRideAsync(id);

            if (ride.Passangers.Count < ride.SeatingCapacity)
            {
                ride.Passangers.Add(passangerUsername);
            }
            else
            {
                return new SuccessResult(Messages.NotEnoughSeats);
            }

            var result = await rideRepository.AddRideAsync(ride);

            if (!result)
            {
                return new SuccessResult(Messages.NotJoinedToRide);
            }

            return new SuccessResult(Messages.JoinedToRide);

        }

        public async Task<IResult> SetRideActiveness(string id, bool isActive)
        {
            var ride = await rideRepository.GetRideAsync(id);

            ride.IsActive = isActive;

            var result = await rideRepository.AddRideAsync(ride);

            if (!result)
            {
                return isActive ? new ErrorResult(Messages.RideNotActivated) : new ErrorResult(Messages.RideCouldntPassive);
            }

            return isActive ? new ErrorResult(Messages.RideActivated) : new ErrorResult(Messages.RideMadePassive);
        }
    }
}
