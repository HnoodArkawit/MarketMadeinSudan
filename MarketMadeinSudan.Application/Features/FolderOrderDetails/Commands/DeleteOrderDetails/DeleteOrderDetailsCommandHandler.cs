using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.DeleteOrderDetails
{
    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand>
    {
        private readonly IOrderDetailsRepository _OrderDetailsRepository;
        public DeleteOrderDetailsCommandHandler(IOrderDetailsRepository OrderDetailsRepository)
        {
            _OrderDetailsRepository = OrderDetailsRepository;
        }

        public async Task<Unit> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var post = await _OrderDetailsRepository.GetByIdAsync(request.OrderDetailsId);

            await _OrderDetailsRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
