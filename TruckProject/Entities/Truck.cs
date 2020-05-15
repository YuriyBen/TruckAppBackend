using System;
using System.Collections.Generic;

namespace TruckProject.Entities
{
    public partial class Truck
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int YearGraduation { get; set; }
        public double Price { get; set; }
        public string RegistrationPlate { get; set; }
        public string ImagePath { get; set; }
        public long UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
