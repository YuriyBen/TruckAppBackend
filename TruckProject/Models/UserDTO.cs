using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Entities;
using TruckProject.Models;

namespace TruckProject.Models
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "user";
        public string ImagePath { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Country { get; } = RegionInfo.CurrentRegion.EnglishName;
        public string RegistrationToken { get; set; }
        public string PasswordHash { get; set; }


        public  ICollection<TruckDTO> Truck { get; set; }
    }
}
