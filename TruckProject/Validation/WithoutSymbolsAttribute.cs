using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.Validation
{
    public class WithoutSymbolsAttribute:RegularExpressionAttribute
    {
        public WithoutSymbolsAttribute():base(@"^[a-zA-Z 0-9]+$")
        {
            ErrorMessageResourceType = typeof(ValidationMessages);
            ErrorMessageResourceName = "Characters";
        }
    }
}
