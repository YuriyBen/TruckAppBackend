using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckProject.DTO;
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

        public TruckController(ITruckLogicRepository logicRepository)
        {
            _logicRepository = logicRepository ??
                throw new ArgumentNullException(nameof(logicRepository));

        }

        [HttpGet("Query")]
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

            return Ok(trucks);
        }
        [HttpGet]
        public ActionResult<IEnumerable<TruckDTO>> GetTrucks()
        {
            var trucks = _logicRepository.GetTrucks();
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
            var truckToReturn = _logicRepository.CreateTruck(truckForCreation);
            //_logicRepository.Save();

            return Ok(truckToReturn);
        }
        [HttpDelete("{TruckId}")]
        public IActionResult RemoveTruck(long TruckId)
        {
            _logicRepository.RemoveTruck(TruckId);
            //_logicRepository.Save();
            return Ok();
        }
        [HttpPut("{TruckId}")]
        public IActionResult UpdateTruck(long TruckId, [FromBody] TruckDTO truck)
        {
            _logicRepository.UpdateTruck(TruckId, truck);

            return Ok(truck);
        }
    }
}