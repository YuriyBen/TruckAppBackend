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
            var currentDate = DateTime.Now;
            int currentAge = DateTime.UtcNow.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(currentAge))
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
