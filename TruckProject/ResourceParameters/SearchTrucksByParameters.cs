using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TruckProject.ResourceParameters
{
    public class SearchTrucksByParameters
    {
        [MinLength(3, ErrorMessage = "Search query should be more than 2 characters..")]
        public string SearchQuery { get; set; }
        public string SortBy { get; set; } = "Brand";

    }
}
