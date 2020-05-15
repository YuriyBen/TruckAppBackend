using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckProject.Helpers;

namespace TruckProject.Controllers
{
    [Route("api/about")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        [HttpGet("{Brand}")]
        public IActionResult GetInfoAboutCar(string Brand)
        {
            string Country = Brand.GetCountry();
            string ImagePath = Brand.GetImagePath();
            return Ok(new { Country,ImagePath});
        }   

    }

}