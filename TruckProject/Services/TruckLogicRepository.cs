using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.DTO;
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

            if(!string.IsNullOrWhiteSpace(trucksByParameters.SearchQuery))
            {
                var trucksToReturn = new List<TruckDTO>();

                foreach (var item in trucksToCheck)
                {
                    if (item.ToString().ToUpper().Contains(trucksByParameters.SearchQuery.ToUpper()))
                    {
                        trucksToReturn.Add(item);
                    }
                }
                trucksToCheck = trucksToReturn;
            }

            //trucksToCheck = trucksToCheck.OrderByDescending(p => p.GetType().GetProperty(trucksByParameters.SortBy).GetValue(p)).ToList();
            return trucksToCheck;
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
        public void UpdateTruck(long TruckId, TruckDTO truck)
        {
            IsPresent(TruckId);

            TruckDTO truckToReturn = GetTruckById(TruckId);

            truckToReturn = truck;
            
            // return truck;
        }

        void IsPresent(long TruckId) 
        {
            if (!_context.Truck.Any(t => t.Id == TruckId))
            {
                throw new Exception("Not found result..");
            }
        }
    }
}
