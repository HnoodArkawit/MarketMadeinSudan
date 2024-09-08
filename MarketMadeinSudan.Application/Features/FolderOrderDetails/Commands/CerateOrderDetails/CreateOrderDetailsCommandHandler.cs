using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.CreateOrderDetails
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, Guid>
    {
        private readonly IOrderDetailsRepository _martyrPictureRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailsCommandHandler(IOrderDetailsRepository martyrPictureRepository, IMapper mapper)
        {
            _martyrPictureRepository = martyrPictureRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            OrderDetails martyrPicture = _mapper.Map<OrderDetails>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            martyrPicture = await _martyrPictureRepository.AddAsync(martyrPicture);

            return martyrPicture.OrderDetailsId;
        }


    }
}
