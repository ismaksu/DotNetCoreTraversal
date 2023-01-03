using DataAccessLayer.Concrete;
using DotNetCoreTraversal.CQRS.Queries.GuideQueries;
using DotNetCoreTraversal.CQRS.Results.GuideResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetAllGuideQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetAllGuideQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.id);
            return new GetAllGuideQueryResult
            {
                GuideID = values.GuideID,
                Name = values.Name,
                Description = values.Description,
                Image = values.Image
            };
        }
    }
}
