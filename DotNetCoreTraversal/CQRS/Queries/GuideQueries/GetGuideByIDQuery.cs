using DotNetCoreTraversal.CQRS.Results.GuideResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetAllGuideQueryResult>
    {
        public int id { get; set; }

        public GetGuideByIDQuery(int id)
        {
            this.id = id;
        }
    }
}
