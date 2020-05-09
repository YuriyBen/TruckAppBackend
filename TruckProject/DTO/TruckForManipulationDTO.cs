using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.DTO
{
    public abstract class TruckForManipulationDTO
    {
        public double PriceUSD { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearGraduation { get; set; }
        public string RegistrationPlate { get; set; }
        public string ImagePath { get; set; }
    }
}
