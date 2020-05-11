using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.Helpers
{
    public static class GetCurrentAgeExtension
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            int currentAge = DateTime.UtcNow.Year - dateTime.Year;

            if(dateTime.Year+currentAge > DateTime.UtcNow.Year)
            {
                currentAge--;
            }
            return currentAge;
        }
        public static int GetCurrentAge(this int YearGraduation)
        {
            int currentAge = DateTime.UtcNow.Year - YearGraduation;
            return currentAge;
        }
    }
}
