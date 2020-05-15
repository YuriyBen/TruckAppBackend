using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Validation;

namespace TruckProject.ResourceParameters
{
    public class UserAuthentication
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Unique]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; } //mm-dd-yy
        public string Sex { get; set; }
        public string Role { get; set; } = "user";
    }
}
