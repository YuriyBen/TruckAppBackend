using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.Validation
{
    public class OnlyCharactersAttribute:RegularExpressionAttribute
    {
        public OnlyCharactersAttribute():base(@"^[a-zA-Z]+$")
        {
            ErrorMessageResourceType = typeof(ValidationMessages);
            ErrorMessageResourceName = "Characters";
        }
    }
}
