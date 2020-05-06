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
            string correctNumber = "";

            for (int i = 0; i < 2; i++)
            {
                correctNumber += number[i];
            }
            correctNumber += " ";
            for (int i = 2; i < 6; i++)
            {
                correctNumber += number[i];
            }
            correctNumber += " ";
            for (int i = 6; i < 8; i++)
            {
                correctNumber += number[i];
            }
            return correctNumber;
        }
    }
}
