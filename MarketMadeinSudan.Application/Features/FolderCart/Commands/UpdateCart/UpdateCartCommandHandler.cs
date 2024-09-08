using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Commands.UpdateCart
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly IAsyncRepository<Cart> _CartRepository;
        private readonly IMapper _mapper;
        public UpdateCartCommandHandler(IAsyncRepository<Cart> cartRepository, IMapper mapper)
        {
            _CartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Cart cart = _mapper.Map<Cart>(request);

            await _CartRepository.UpdateAsync(cart);

            return Unit.Value;
        }

    }

}
