using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Commands.CreateAccessories
{
    public class CreateAccessoriesCommandHandler : IRequestHandler<CreateAccessoriesCommand, Guid>
    {
        private readonly IAccessoriesRepository _AccessoriesRepository;
        private readonly IMapper _mapper;

        public CreateAccessoriesCommandHandler(IAccessoriesRepository accessoriesRepository, IMapper mapper)
        {
            _AccessoriesRepository = accessoriesRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAccessoriesCommand request, CancellationToken cancellationToken)
        {
            Accessories accessories = _mapper.Map<Accessories>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            accessories = await _AccessoriesRepository.AddAsync(accessories);

            return accessories.AccessoriesId;
        }


    }
}
