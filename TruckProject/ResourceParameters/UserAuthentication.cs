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
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //[PasswordValidation]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Url]
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; } //mm-dd-yy
        public string Sex { get; set; }
        public string Role { get; set; } = "user";
    }
}
