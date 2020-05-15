using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Models;
using TruckProject.Entities;
using TruckProject.Helpers;
using TruckProject.ResourceParameters;
using System.Globalization;

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
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                .ForMember(
                    dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString()))
                //.ForMember(
                //    dest => dest.Truck,
                //    opt => opt.MapFrom(src => src.Truck))
                ;

            CreateMap<UserAuthentication, Users>()
                .ForMember(
                    dest => dest.PasswordHash,
                    opt => opt.MapFrom(src => src.Password.Encode()) )
                .ForMember(
                    dest=>dest.RegistrationToken,
                    opt => opt.MapFrom(src => $"{src.LastName + " "+ src.FirstName}".GenerateToken()))
                ;
        }
    }
}
