using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Models
{
    public class DestinationViewModel
    {
        public int DestinationID { get; set; }

        public string City { get; set; }

        public string DayNight { get; set; }

        public double Price { get; set; }

        public IFormFile Image { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile CoverImage { get; set; }

        public string ImageURL { get; set; }
        public string Image1URL { get; set; }
        public string CoverImageURL { get; set; }

        public string Description { get; set; }

        public string Details1 { get; set; }

        public string Details2 { get; set; }

        public int Capacity { get; set; }

        public bool Status { get; set; }
    }
}
