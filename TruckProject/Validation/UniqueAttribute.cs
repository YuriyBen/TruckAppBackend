using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TruckProject.Entities;
using TruckProject.ResourceParameters;

namespace TruckProject.Validation
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var db = new AutomobileContext();
            

            var user = (UserAuthentication)validationContext.ObjectInstance;
            if(db.Database.ExecuteSqlRaw($"select Email from avto.Users where Email='{user.Email}'")!=0)
            {
                return new ValidationResult($"The e-mail {user.Email} is already exist..",
                                new[] { nameof(UserAuthentication) });
            }
            //if (db.Users.Any(u=>u.Email==user.Email))
            //{
            //    return new ValidationResult($"The e-mail {user.Email} is already exist..",
            //                    new[] {nameof(UserAuthentication)});
            //}

            return ValidationResult.Success;
        }
    }
}
