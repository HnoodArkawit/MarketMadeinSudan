using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryList
{
    public class GetWatchesAndJewelryListQueryHandler : IRequestHandler<GetWatchesAndJewelryListQuery, List<GetWatchesAndJewelryListViewModel>>
    {
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        private readonly IMapper _mapper;

        public GetWatchesAndJewelryListQueryHandler(IWatchesAndJewelryRepository watchesAndJewelryRepository, IMapper mapper)
        {
            _WatchesAndJewelryRepository = watchesAndJewelryRepository;
            _mapper = mapper;
        }
        public async Task<List<GetWatchesAndJewelryListViewModel>> Handle(GetWatchesAndJewelryListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _WatchesAndJewelryRepository.GetAllWatchesAndJewelryAsync();
            return _mapper.Map<List<GetWatchesAndJewelryListViewModel>>(allPosts);
        }
    }
}
