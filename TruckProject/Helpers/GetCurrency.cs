using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TruckProject.Helpers
{
    public class Currency
    {
        public string ccy { get; set; }
        public decimal buy { get; set; }
        public decimal sale { get; set; }
    }
    public static  class GetCurrency
    {
        public static double ConvertCurrency(this double usd,string currency)
        {
            WebClient client = new WebClient();

            string myJSON = client.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            var myClass = Newtonsoft.Json.JsonConvert.DeserializeObject(myJSON);

            var list = JsonConvert.DeserializeObject<List<Currency>>(myClass.ToString()).Where(cur => cur.ccy == "USD" || cur.ccy=="EUR").ToList();

            double forBuy = Convert.ToDouble(list[0].buy);
            double forSale = Convert.ToDouble(list[0].sale);

            double euroForBuy = Convert.ToDouble(list[1].buy);
            double euroForSale = Convert.ToDouble(list[1].sale);

            double toReturn = 0;
            if(usd==0)
            {
                toReturn = 0;
            }
            if(currency=="UAH")
            {
                toReturn = usd * forSale;
            }
            if(currency=="EUR")
            {
                toReturn = usd * forSale / euroForBuy;
            }
            return Math.Round(toReturn,0);
        }
    }
}
