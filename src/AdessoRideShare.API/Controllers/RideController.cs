using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdessoRideShare.API.ViewModels;
using AdessoRideShare.Application.Interfaces;
using AdessoRideShare.Application.Services;
using AdessoRideShare.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdessoRideShare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RideController : ControllerBase
    {
        private readonly IRideService rideService;
        private readonly IRotaService rotaService;
        private readonly IMapper mapper;

        public RideController(
            IRideService rideService,
            IRotaService rotaService,
            IMapper mapper)
        {
            this.rideService = rideService;
            this.rotaService = rotaService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostRideAsync(RideViewModel rideViewModel)
        {
            var ride = mapper.Map<Ride>(rideViewModel);

            var result = await rideService.AddRideAsync(ride);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("{id}/Activeness")]
        public async Task<IActionResult> PostRideActiveness(string id, [FromBody] bool isActive)
        {
            var result = await rideService.SetRideActiveness(id, isActive);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string beginning, string destination)
        {
            var result = await rideService.GetRidesAsync(beginning, destination);
            if (result.Success)
            {
                var itemViewModels = mapper.Map<List<RideViewModel>>(result.Data);
                return Ok(itemViewModels);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("{id}/Join")]
        public async Task<IActionResult> PostJoinRide(string id, [FromBody] string username)
        {
            var result = await rideService.JoinRide(username, id);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("InRota")]
        public async Task<IActionResult> GetRidesInRotaAsync(string beginning, string destination)
        {
            var result = await rotaService.FindRidesInRota(beginning, destination);
            if (result.Success)
            {
                var itemViewModels = mapper.Map<List<RideViewModel>>(result.Data);
                return Ok(itemViewModels);
            }

            return BadRequest(result.Message);
        }
    }
}
