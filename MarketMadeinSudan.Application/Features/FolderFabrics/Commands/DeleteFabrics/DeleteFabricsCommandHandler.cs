using MarketMadeinSudan.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Commands.DeleteFabrics
{
    public class DeleteFabricsCommandHandler : IRequestHandler<DeleteFabricsCommand>
    {
        private readonly IFabricsRepository _FabricsRepository;
        public DeleteFabricsCommandHandler(IFabricsRepository fabricsRepository)
        {
            _FabricsRepository = fabricsRepository;
        }

        public async Task<Unit> Handle(DeleteFabricsCommand request, CancellationToken cancellationToken)
        {
            var post = await _FabricsRepository.GetByIdAsync(request.FabricsId);

            await _FabricsRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
