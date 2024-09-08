using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Queries.GetHouseholdProductsDetail
{
    public class GetHouseholdProductsDetailQueryHandler : IRequestHandler<GetHouseholdProductsDetailQuery, GetHouseholdProductsDetailViewModel>
    {
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        private readonly IMapper _mapper;

        public GetHouseholdProductsDetailQueryHandler(IHouseholdProductsRepository householdProductsRepository, IMapper mapper)
        {
            _HouseholdProductsRepository = householdProductsRepository;
            _mapper = mapper;
        }
        public async Task<GetHouseholdProductsDetailViewModel> Handle(GetHouseholdProductsDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _HouseholdProductsRepository.GetHouseholdProductsByIdAsync(request.HouseholdProductsId);

            return _mapper.Map<GetHouseholdProductsDetailViewModel>(Post);
        }
    }
}
