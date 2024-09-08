using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.UpdateShipping
{
    public class UpdateShippingCommandHandler : IRequestHandler<UpdateShippingCommand>
    {
        private readonly IAsyncRepository<Shipping> _picRepository;
        private readonly IMapper _mapper;
        public UpdateShippingCommandHandler(IAsyncRepository<Shipping> picRepository, IMapper mapper)
        {
            _picRepository = picRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShippingCommand request, CancellationToken cancellationToken)
        {
            Shipping Shipping = _mapper.Map<Shipping>(request);

            await _picRepository.UpdateAsync(Shipping);

            return Unit.Value;
        }

    }

}
