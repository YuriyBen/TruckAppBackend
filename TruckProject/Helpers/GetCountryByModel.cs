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
        #region GetHTML
        static HtmlDocument GetHTML(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var html = httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html.Result);

                return htmlDocument;

            }
        }
        #endregion

        #region GetCountryByModel
        public static string GetCountry(this string model)
        {
            string url = $"https://en.wikipedia.org/wiki/{model}";

            HtmlDocument html = GetHTML(url);
            string country = GetCountry(html);

            return country;
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
        #endregion

        #region GetImageByModel
        static string GetCarImage(HtmlDocument htmlDocument)
        {
            string path = "//table[@class='infobox vcard']//tr//td[@class='logo']";

            var generall = htmlDocument.DocumentNode.SelectNodes(path);

            string image = generall[0].ChildNodes.FirstOrDefault(x => x.Name == "a")
                                     .ChildNodes.FirstOrDefault(x => x.Name == "img")
                                     .Attributes["src"]
                                     .Value;
            return image;
        }

        public static string GetImagePath(this string model)
        {
            string url = $"https://en.wikipedia.org/wiki/{model}";

            HtmlDocument html = GetHTML(url);
            string imagePath = GetCarImage(html);

            return imagePath;
        }
        #endregion

        
    }
}
