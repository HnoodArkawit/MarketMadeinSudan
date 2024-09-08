using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Queries.GetWatchesAndJewelryDetail
{
    public class GetWatchesAndJewelryDetailQuery : IRequest<GetWatchesAndJewelryDetailViewModel>
    {
        public Guid WatchesAndJewelryId { get; set; }
    }
}
