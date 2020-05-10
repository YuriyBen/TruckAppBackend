using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.DTO;
using TruckProject.Helpers;
using TruckProject.Models;

namespace TruckProject.Profiles
{
    public class TrucksProfile : Profile
    {
        public TrucksProfile()
        {
            CreateMap<Truck, TruckDTO>()
                .ForMember(
                    dest => dest.AmountYear,
                    opt => opt.MapFrom(src => src.YearGraduation.GetCurrentAge()))
                
                .ForMember(
                    dest => dest.PriceUSD,
                    opt => opt.MapFrom(src => src.Price))
                .ForMember(
                    dest => dest.PriceUAH,
                    opt => opt.MapFrom(src => src.Price.ConvertCurrency("UAH")))
                .ForMember(
                    dest => dest.PriceEUR,
                    opt => opt.MapFrom(src => src.Price.ConvertCurrency("EUR")));

            CreateMap<TruckForCreationDTO, Truck>()
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => $"{src.BrandSearch.GetCountry()}"))
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.PriceUSD))
                .ForMember(
                    dest => dest.RegistrationPlate,
                    opt => opt.MapFrom(src => src.RegistrationPlate.FormatCarNumbers()));

            CreateMap<TruckDTO, Truck>()
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.PriceUSD));
        }
    }
}
