using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Validation;

namespace TruckProject.ResourceParameters
{
    public class UserAuthorization
    {
        [EmailAddress]
        public string Email { get; set; }
        //[PasswordValidation]
        public string Password { get; set; }

    }
}
