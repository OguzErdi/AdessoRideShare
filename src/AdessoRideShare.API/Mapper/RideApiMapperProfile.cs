using AdessoRideShare.API.ViewModels;
using AdessoRideShare.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.API.Mapper
{
    public class RideApiMapperProfile : Profile
    {
        public RideApiMapperProfile()
        {
            CreateMap<Ride, RideViewModel>().ReverseMap();
        }
    }
}
