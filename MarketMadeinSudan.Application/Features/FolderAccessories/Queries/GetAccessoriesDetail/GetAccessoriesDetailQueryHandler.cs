using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Queries.GetAccessoriesDetail
{
    public class GetAccessoriesDetailQueryHandler : IRequestHandler<GetAccessoriesDetailQuery, GetAccessoriesDetailViewModel>
    {
        private readonly IAccessoriesRepository _AccessoriesRepository;
        private readonly IMapper _mapper;

        public GetAccessoriesDetailQueryHandler(IAccessoriesRepository accessoriesRepository, IMapper mapper)
        {
            _AccessoriesRepository = accessoriesRepository;
            _mapper = mapper;
        }
        public async Task<GetAccessoriesDetailViewModel> Handle(GetAccessoriesDetailQuery request, CancellationToken cancellationToken)
        {
            var Accessories = await _AccessoriesRepository.GetAccessoriesByIdAsync(request.AccessoriesId);

            return _mapper.Map<GetAccessoriesDetailViewModel>(Accessories);
        }
    }
}
