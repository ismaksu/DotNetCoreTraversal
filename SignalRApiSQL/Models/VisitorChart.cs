using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiSQL.Models
{
    public class VisitorChart
    {
        public VisitorChart()
        {
            Counts = new List<int>();
        }

        public string VisitDate { get; set; }

        public List<int> Counts { get; set; }
    }
}
