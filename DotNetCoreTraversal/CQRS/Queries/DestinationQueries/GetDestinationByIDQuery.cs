using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public int ID { get; set; }

        public GetDestinationByIDQuery(int Id)
        {
            ID = Id;
        }
    }
}
