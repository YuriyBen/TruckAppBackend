using System.Collections.Generic;
using System.Threading.Tasks;
using TruckProject.DTO;
using TruckProject.Models;
using TruckProject.ResourceParameters;

namespace TruckProject.Services
{
    public interface ITruckLogicRepository
    {
        IEnumerable<TruckDTO> GetTrucks();
        IEnumerable<TruckDTO> GetTrucks(SearchTrucksByParameters trucksByParameters);
        TruckDTO CreateTruck(TruckForCreationDTO truckForCreation);
        TruckDTO GetTruckById(long TruckId);
        void RemoveTruck(long TruckId);
        void UpdateTruck(long TruckId, TruckForUpdating truck);
        bool Save();
        void Dispose();

    }
}