using DataAccessLayer.Concrete;
using DotNetCoreTraversal.CQRS.Commands.GuideCommands;
using EntityLayer.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            await _context.Guides.AddAsync(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                TwitterUrl = request.TwitterUrl,
                InstagramUrl = request.InstagramUrl,
                Status = request.Status
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
