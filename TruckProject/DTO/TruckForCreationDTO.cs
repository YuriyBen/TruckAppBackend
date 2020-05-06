using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.DTO
{
    public class TruckForCreationDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearGraduation { get; set; }
        public double Price { get; set; }

        public string RegistrationPlate { get; set; }
        public string ImagePath { get; set; }
    }
}
