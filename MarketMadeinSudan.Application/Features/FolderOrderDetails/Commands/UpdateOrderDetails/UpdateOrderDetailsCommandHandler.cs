using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.UpdateOrderDetails
{
    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand>
    {
        private readonly IAsyncRepository<OrderDetails> _picRepository;
        private readonly IMapper _mapper;
        public UpdateOrderDetailsCommandHandler(IAsyncRepository<OrderDetails> picRepository, IMapper mapper)
        {
            _picRepository = picRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            OrderDetails OrderDetails = _mapper.Map<OrderDetails>(request);

            await _picRepository.UpdateAsync(OrderDetails);

            return Unit.Value;
        }

    }

}
