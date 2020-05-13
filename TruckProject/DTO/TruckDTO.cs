using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using TruckProject.Models;

namespace TruckProject.DTO
{
    public class TruckDTO:TruckForManipulationDTO
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public int AmountYear { get; set; }
        public double PriceEUR { get; set; }
        public double PriceUAH { get; set; }
        //public Users User { get; set; }
       
        public override string ToString()
        {
            return $"{Brand} {Model} {Country} {YearGraduation} {AmountYear} {PriceUSD} {PriceEUR} {PriceUAH} {RegistrationPlate}";
        }

    }
}
