using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Queries.GetAccessoriesList
{
    public class GetAccessoriesListQueryHandler : IRequestHandler<GetAccessoriesListQuery, List<GetAccessoriesListViewModel>>
    {
        private readonly IAccessoriesRepository _AccessoriesRepository;
        private readonly IMapper _mapper;

        public GetAccessoriesListQueryHandler(IAccessoriesRepository pccessoriesRepository, IMapper mapper)
        {
            _AccessoriesRepository = pccessoriesRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAccessoriesListViewModel>> Handle(GetAccessoriesListQuery request, CancellationToken cancellationToken)
        {
            var allAccessories = await _AccessoriesRepository.GetAllAccessoriesAsync();
            return _mapper.Map<List<GetAccessoriesListViewModel>>(allAccessories);
        }
    }
}
