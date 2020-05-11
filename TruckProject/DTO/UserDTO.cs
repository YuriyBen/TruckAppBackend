using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ImagePath { get; set; }
        public string DateOfBirth { get; set; }
        public int Years { get; set; }
        public string Sex { get; set; }
        public string Country { get; } = RegionInfo.CurrentRegion.EnglishName;
    }
}
