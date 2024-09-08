using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Commands.DeleteAccessories
{
    public class DeleteAccessoriesCommandHandler : IRequestHandler<DeleteAccessoriesCommand>
    {
        private readonly IAccessoriesRepository _AccessoriesRepository;
        public DeleteAccessoriesCommandHandler(IAccessoriesRepository accessoriesRepository)
        {
            _AccessoriesRepository = accessoriesRepository;
        }

        public async Task<Unit> Handle(DeleteAccessoriesCommand request, CancellationToken cancellationToken)
        {
            var post = await _AccessoriesRepository.GetByIdAsync(request.AccessoriesId);

            await _AccessoriesRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
