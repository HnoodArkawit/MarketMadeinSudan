using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.DeleteShipping
{
    public class DeleteShippingCommandHandler : IRequestHandler<DeleteShippingCommand>
    {
        private readonly IShippingRepository _ShippingRepository;
        public DeleteShippingCommandHandler(IShippingRepository ShippingRepository)
        {
            _ShippingRepository = ShippingRepository;
        }

        public async Task<Unit> Handle(DeleteShippingCommand request, CancellationToken cancellationToken)
        {
            var post = await _ShippingRepository.GetByIdAsync(request.ShippingId);

            await _ShippingRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
