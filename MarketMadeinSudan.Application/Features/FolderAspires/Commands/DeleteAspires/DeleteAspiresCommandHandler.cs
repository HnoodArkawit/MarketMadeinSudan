using MarketMadeinSudan.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.DeleteAspires
{
    public class DeleteAspiresCommandHandler : IRequestHandler<DeleteAspiresCommand>
    {
        private readonly IAspiresRepository _AspiresRepository;
        public DeleteAspiresCommandHandler(IAspiresRepository aspiresRepository)
        {
            _AspiresRepository = aspiresRepository;
        }

        public async Task<Unit> Handle(DeleteAspiresCommand request, CancellationToken cancellationToken)
        {
            var post = await _AspiresRepository.GetByIdAsync(request.AspiresId);

            await _AspiresRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
