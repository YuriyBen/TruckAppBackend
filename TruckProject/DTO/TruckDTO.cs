using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TruckProject.DTO
{
    public class TruckDTO
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int AmountYear { get; set; }
        public double PriceUSD { get; set; }
        public double PriceEUR { get; set; }
        public double PriceUAH { get; set; }
        public string RegistrationPlate { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} {Country} {AmountYear} {PriceUSD} {PriceEUR} {PriceUAH} {RegistrationPlate} {ImagePath}";
        }

    }
}
