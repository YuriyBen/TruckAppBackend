using System;
using System.Collections.Generic;
using System.Globalization;

namespace TruckProject.Models
{
    public partial class Users
    {
        public Users()
        {
            UserTruck = new HashSet<UserTruck>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string RegistrationToken { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Country { get; } = RegionInfo.CurrentRegion.DisplayName;

        public virtual ICollection<UserTruck> UserTruck { get; set; }
    }
}
