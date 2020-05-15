using System;
using System.Collections.Generic;

namespace TruckProject.Entities
{
    public partial class Users
    {
        public Users()
        {
            Truck = new HashSet<Truck>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string RegistrationToken { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Truck> Truck { get; set; }
    }
}
