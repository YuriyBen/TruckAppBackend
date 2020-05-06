using HtmlAgilityPack;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TruckProject.Helpers
{
    public static class GetCountryByModel
    {
        public static string GetCountry(this string model)
        {
            string url = $"https://en.wikipedia.org/wiki/{model}";

            using (var httpClient = new HttpClient())
            {
                var html = httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html.Result);
                string country=GetCountry(htmlDocument);

                return country;
            }
        }
        static string GetCountry(HtmlDocument htmlDocument)
        {
            string country = null;
            string path = "//div[@class='country-name']";
        LabelGenerall:
            var generall = htmlDocument.DocumentNode.SelectNodes(path);
            if (generall != null)
            {
                country = generall[0].InnerText;
            }
            else
            {
                path = "//tr//td[@class='label']";
                goto LabelGenerall;

            }
            var locality = generall[0].InnerText;

            var countrySplit = locality.Split(" ");
            country = countrySplit[^1];
            return country;
        }
    }
}
