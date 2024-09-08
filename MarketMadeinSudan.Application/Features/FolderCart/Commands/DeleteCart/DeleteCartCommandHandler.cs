using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly ICartRepository _CartRepository;
        public DeleteCartCommandHandler(ICartRepository cartRepository)
        {
            _CartRepository = cartRepository;
        }

        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var post = await _CartRepository.GetByIdAsync(request.ProductId);

            await _CartRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
