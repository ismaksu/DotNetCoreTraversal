using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int GuideID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}
