using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class City
    {
        public int CityID { get; set; }

        public string CityName { get; set; }
        
        public string CityRegion { get; set; }

        public string CityDescription { get; set; }

        public string CityImage { get; set; }

        //-------------- Relations ---------------

        public List<Destination> Destinations { get; set; }
    }
}
