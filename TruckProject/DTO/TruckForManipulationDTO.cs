
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Validation;

namespace TruckProject.DTO
{
    public abstract class TruckForManipulationDTO
    {
        [Required]
        [Range(0,double.MaxValue)]
        public double PriceUSD { get; set; }
        [Required]
        [OnlyCharacters]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [YearGraduation]
        public int YearGraduation { get; set; }
        [Required]
        public string RegistrationPlate { get; set; }
        //[Required]
        [Url]
        public string ImagePath { get; set; }
    }
}
