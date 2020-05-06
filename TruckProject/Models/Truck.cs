using System;
using System.Collections.Generic;

namespace TruckProject.Models
{
    public partial class Truck
    {
        public Truck()
        {
            UserTruck = new HashSet<UserTruck>();
        }

        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int YearGraduation { get; set; }
        public double Price    { get; set; }
        public string RegistrationPlate { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<UserTruck> UserTruck { get; set; }

        
    }
}
