using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.Validation
{
    public class YearGraduationAttribute:RangeAttribute
    {
        public YearGraduationAttribute():base(0,DateTime.Now.Year)
        {
            ErrorMessageResourceType = typeof(ValidationMessages);
            ErrorMessageResourceName = "CarYear";

        }
        //public override bool IsValid(object value)
        //{
        //    return base.IsValid(value);
        //}
    }
}
