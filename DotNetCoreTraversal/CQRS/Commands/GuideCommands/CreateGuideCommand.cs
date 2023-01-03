using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public bool Status { get; set; }
    }
}
