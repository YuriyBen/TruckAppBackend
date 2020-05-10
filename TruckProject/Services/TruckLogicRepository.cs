﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.DTO;
using TruckProject.Helpers;
using TruckProject.Models;
using TruckProject.ResourceParameters;

namespace TruckProject.Services
{
    public class TruckLogicRepository : ITruckLogicRepository, IDisposable
    {
        private readonly AutomobileContext _context;
        private readonly IMapper _mapper;


        public TruckLogicRepository(AutomobileContext context, IMapper mapper)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(AutomobileContext));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<TruckDTO> GetTrucks()
        {
            var trucks =  _context.Truck.ToList();
            var trucksToReturn = _mapper.Map <IEnumerable<TruckDTO>>(trucks);
            return trucksToReturn;
        }
        public IEnumerable<TruckDTO> GetTrucks(SearchTrucksByParameters trucksByParameters)
        {
            if (trucksByParameters == null)
            {
                throw new ArgumentNullException(nameof(trucksByParameters));
            }

            var trucksFromContext =  _context.Truck.ToList();

            var trucksToCheck = _mapper.Map<IEnumerable<TruckDTO>>(trucksFromContext).ToList();
            
            var trucksToReturn = new List<TruckDTO>();

            if(!string.IsNullOrWhiteSpace(trucksByParameters.SearchQuery))
            {
                foreach (var item in trucksToCheck)
                {
                    if (item.ToString().ToUpper().Contains(trucksByParameters.SearchQuery.ToUpper()))
                    {
                        trucksToReturn.Add(item);
                    }
                }
            }
            return trucksToReturn;
        }

        public TruckDTO CreateTruck(TruckForCreationDTO truckForCreation)
        {
            if(truckForCreation == null)
            {
                throw new ArgumentNullException(nameof(truckForCreation));
            }
            var truck = _mapper.Map<Truck>(truckForCreation);
            _context.Truck.Add(truck);

            var truckToReturn = _mapper.Map<TruckDTO>(truck);

            return truckToReturn;
        }
        public TruckDTO GetTruckById(long TruckId)
        {
            IsPresent(TruckId);
            var truck =  _context.Truck.FirstOrDefault(t => t.Id == TruckId);
            var truckToReturn = _mapper.Map<TruckDTO>(truck);
            return truckToReturn;

        }

        public bool Save()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public void RemoveTruck(long TruckId)
        {
            IsPresent(TruckId);

            var truckContext = _context.Truck;
            var truck = truckContext.FirstOrDefault(t => t.Id == TruckId);

            truckContext.Remove(truck);
        }

        public void UpdateTruck(long TruckId, TruckForUpdating truck)
        {
            IsPresent(TruckId);

            //TruckDTO truckToUpdate = GetTruckById(TruckId);
            //var truckToReturn = _mapper.Map<Truck>(truckToUpdate);

            //truckToReturn.Price = truck.PriceUSD;
            //truckToReturn.Model = truck.Model;
            //truckToReturn.YearGraduation = truck.YearGraduation;

            //Save();
            //_context.Truck.Update(truckToUpdate);


            ////var entry = _context.Truck.First(e => e.Id == entity.Id);
            //_context.Entry(truckToReturn).CurrentValues.SetValues(truckToReturn);
            //_context.SaveChanges();
            //var author = _context.Truck.FromSqlRaw($"UPDATE avto.Truck " +
            //                        $"SET Price = {truck.PriceUSD}," +
            //                        $"Model = {truck.Model}" +
            //                        $"YearGraduation = {truck.YearGraduation}" +
            //                        $"WHERE Id = 2;").FirstOrDefault();

            _context.Database.ExecuteSqlRaw($"UPDATE avto.Truck " +
                                    $"SET Price = {truck.PriceUSD}," +
                                    $"Model = '{truck.Model}'," +
                                    $"YearGraduation = {truck.YearGraduation}" +
                                    $"WHERE Id = {TruckId};");
            Save();
        }

        //public async void UpdateTruck(long TruckId, TruckForUpdating truck)
        //{

        //    if (!_context.Truck.Any(t => t.Id == TruckId))
        //    {
        //        throw new Exception("Not found result..");
        //    }
        //    var truckFromRepo = _context.Truck.FirstOrDefault(t => t.Id == TruckId);
        //    //
        //    truckFromRepo.Price = truck.PriceUSD;
        //    truckFromRepo.Model = truck.Model;
        //    truckFromRepo.YearGraduation = truck.YearGraduation;
        //    _context.Truck.Update(_mapper.Map<Truck>(truckFromRepo));
        //    await _context.SaveChangesAsync();
        //    var test = _context.Truck.FirstOrDefault(t => t.Id == TruckId);


        //}

        void IsPresent(long TruckId) 
        {
            if (!_context.Truck.Any(t => t.Id == TruckId))
            {
                throw new Exception("Not found result..");
            }
        }

    }
}
