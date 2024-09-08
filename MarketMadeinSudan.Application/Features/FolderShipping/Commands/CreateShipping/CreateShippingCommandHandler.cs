using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;
using MarketMadeinSudan.Domin;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.CreateShipping
{
    public class CreateShippingCommandHandler : IRequestHandler<CreateShippingCommand, Guid>
    {
        private readonly IShippingRepository _ShippingRepository;
        private readonly IMapper _mapper;

        public CreateShippingCommandHandler(IShippingRepository ShippingRepository, IMapper mapper)
        {
            _ShippingRepository = ShippingRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateShippingCommand request, CancellationToken cancellationToken)
        {
            Shipping Shipping = _mapper.Map<Shipping>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            Shipping = await _ShippingRepository.AddAsync(Shipping);

            return Shipping.ShippingId;
        }


    }
}
