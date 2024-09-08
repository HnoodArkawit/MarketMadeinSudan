using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryDetail
{
    public class GetWatchesAndJewelryDetailQueryHandler : IRequestHandler<GetWatchesAndJewelryDetailQuery, GetWatchesAndJewelryDetailViewModel>
    {
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        private readonly IMapper _mapper;

        public GetWatchesAndJewelryDetailQueryHandler(IWatchesAndJewelryRepository watchesAndJewelryRepository, IMapper mapper)
        {
            _WatchesAndJewelryRepository = watchesAndJewelryRepository;
            _mapper = mapper;
        }
        public async Task<GetWatchesAndJewelryDetailViewModel> Handle(GetWatchesAndJewelryDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _WatchesAndJewelryRepository.GetWatchesAndJewelryByIdAsync(request.WatchesAndJewelryId);

            return _mapper.Map<GetWatchesAndJewelryDetailViewModel>(Post);
        }
    }
}
