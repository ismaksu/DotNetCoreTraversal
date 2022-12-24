using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Results.DestinationResults
{
    public class GetDestinationByIDQueryResult
    {
        public int ID { get; set; }

        public string City { get; set; }

        public string DayNight { get; set; }
    }
}
