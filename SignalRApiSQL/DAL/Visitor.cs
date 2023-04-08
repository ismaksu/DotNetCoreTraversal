using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiSQL.DAL
{
    public enum ECity
    {
        Antalya = 1,
        İzmir,
        İstanbul,
        Ankara,
        Malatya,
        Edirne,
        Bursa
    }
    public class Visitor
    {
        public int VisitorID { get; set; }

        public ECity City { get; set; }

        public int CityVisitCount { get; set; }

        public DateTime VisitDate { get; set; }
    }
}
