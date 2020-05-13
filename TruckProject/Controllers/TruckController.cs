using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TruckProject.DTO;
using TruckProject.Helpers;
using TruckProject.Models;
using TruckProject.ResourceParameters;
using TruckProject.Services;

namespace TruckProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckLogicRepository _logicRepository;
        private readonly AutomobileContext _context;

        public TruckController(ITruckLogicRepository logicRepository,IMapper mapper,AutomobileContext context)
        {
            _logicRepository = logicRepository ??
                throw new ArgumentNullException(nameof(logicRepository));
            _context = context ??
                throw new ArgumentNullException(nameof(AutomobileContext));

        }
        [HttpGet("Check")]
        public IActionResult Get()
        {
            var collection = _context.Truck.Include(x => x.User).ToList();
            return Ok(collection);



        }
        [HttpGet]
        public ActionResult<IEnumerable<TruckDTO>> GetTrucks(
            [FromQuery] SearchTrucksByParameters trucksByParameters)
        {
            IEnumerable<TruckDTO> trucks = new List<TruckDTO>();

            if (string.IsNullOrWhiteSpace(trucksByParameters.SearchQuery))
            {
                trucks = _logicRepository.GetTrucks();
            }
            else
            {
                trucks = _logicRepository.GetTrucks(trucksByParameters);
            }
            trucks = trucks.OrderBy(p => p.GetType().GetProperty(trucksByParameters.SortBy).GetValue(p)).ToList();

            return Ok(trucks);
        }


        [HttpGet("{TruckId}", Name = "GetTruck")]
        public ActionResult<TruckDTO> GetTruck(long TruckId)
        {
            var truck = _logicRepository.GetTruckById(TruckId);
            if (truck == null)
            {
                NotFound();
            }
            return Ok(truck);
        }

        [HttpPost]
        public ActionResult<TruckDTO> PostTruck(TruckForCreationDTO truckForCreation)
        {
            //if(ModelState.IsValid)
            //{
            //    var truckToReturn = _logicRepository.CreateTruck(truckForCreation);
            //    _logicRepository.Save();

            //    return Ok(truckToReturn);
            //}
            //return Ok();
            var truckToReturn = _logicRepository.CreateTruck(truckForCreation);
            _logicRepository.Save();

            return Ok(truckToReturn);
        }
        [HttpDelete("{TruckId}")]
        public IActionResult RemoveTruck(long TruckId)
        {
            _logicRepository.RemoveTruck(TruckId);
            _logicRepository.Save();
            return Ok();
        }
        [HttpPut("{TruckId}")]
        public void UpdateTruck(long TruckId, [FromBody] TruckForUpdating truck)
        {
            

            _logicRepository.UpdateTruck(TruckId, truck);
            //_logicRepository.Save();

            //return Ok(truckToReturn);
        }

    }
}