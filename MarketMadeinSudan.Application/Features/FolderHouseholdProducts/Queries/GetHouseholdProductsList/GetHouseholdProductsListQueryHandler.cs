using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Queries.GetHouseholdProductsList
{
    public class GetHouseholdProductsListQueryHandler : IRequestHandler<GetHouseholdProductsListQuery, List<GetHouseholdProductsListViewModel>>
    {
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        private readonly IMapper _mapper;

        public GetHouseholdProductsListQueryHandler(IHouseholdProductsRepository householdProductsRepository, IMapper mapper)
        {
            _HouseholdProductsRepository = householdProductsRepository;
            _mapper = mapper;
        }
        public async Task<List<GetHouseholdProductsListViewModel>> Handle(GetHouseholdProductsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _HouseholdProductsRepository.GetAllHouseholdProductsAsync();
            return _mapper.Map<List<GetHouseholdProductsListViewModel>>(allPosts);
        }
    }
}
