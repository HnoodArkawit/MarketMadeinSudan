using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.CreateHouseholdProducts
{
    public class CreateHouseholdProductsCommandHandler : IRequestHandler<CreateHouseholdProductsCommand, Guid>
    {
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        private readonly IMapper _mapper;

        public CreateHouseholdProductsCommandHandler(IHouseholdProductsRepository householdProductsRepository, IMapper mapper)
        {
            _HouseholdProductsRepository = householdProductsRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateHouseholdProductsCommand request, CancellationToken cancellationToken)
        {
            HouseholdProducts householdProducts = _mapper.Map<HouseholdProducts>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            householdProducts = await _HouseholdProductsRepository.AddAsync(householdProducts);

            return householdProducts.HouseholdProductsId;
        }


    }
}
