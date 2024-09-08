using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.UpdateHouseholdProducts
{
    public class UpdateHouseholdProductsCommandHandler : IRequestHandler<UpdateHouseholdProductsCommand>
    {
        private readonly IAsyncRepository<HouseholdProducts> _HouseholdProductsRepository;
        private readonly IMapper _mapper;
        public UpdateHouseholdProductsCommandHandler(IAsyncRepository<HouseholdProducts> householdProductsRepository, IMapper mapper)
        {
            _HouseholdProductsRepository = householdProductsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHouseholdProductsCommand request, CancellationToken cancellationToken)
        {
            HouseholdProducts householdProducts = _mapper.Map<HouseholdProducts>(request);

            await _HouseholdProductsRepository.UpdateAsync(householdProducts);

            return Unit.Value;
        }

    }

}
