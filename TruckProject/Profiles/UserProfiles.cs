using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.DTO;
using TruckProject.Models;
using TruckProject.Helpers;

namespace TruckProject.Profiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<Users, UserDTO>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Years,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString()));
        }
    }
}
