using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.Helpers
{
    public static class GetFormat
    {
        public static string FormatPrice(this double price)
        {
            string forRemovingZeros = price.ToString();
            string format = "000 000 000 000";
            string finish = price.ToString(format);
            finish = finish.Remove(0, finish.IndexOf(forRemovingZeros[0]));
            return finish;
        }
        public static string FormatCarNumbers(this string number)
        {
            number = number.Replace(" ", "");
            string correct = number.Substring(0, 2) + " " + number.Substring(2, 4) + " " + number.Substring(6, 2);
            return correct.ToUpper();
        }
    }
}
