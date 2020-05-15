
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Validation;

namespace TruckProject.Models
{
    public abstract class TruckForManipulationDTO
    {
        [Required]
        [Range(0,double.MaxValue)]
        public double PriceUSD { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [WithoutSymbols]
        public string Model { get; set; }
        [Required]
        [YearGraduation]
        public int YearGraduation { get; set; }
        [Required]
        [WithoutSymbols]
        public string RegistrationPlate { get; set; }
        [Url]
        public string ImagePath { get; set; }
    }
}
