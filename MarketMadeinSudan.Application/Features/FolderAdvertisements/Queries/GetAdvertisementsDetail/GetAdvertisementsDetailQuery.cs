using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsDetail
{
    public class GetAdvertisementsDetailQuery : IRequest<GetAdvertisementsDetailViewModel>
    {
        public Guid AdvertisementId { get; set; }
    }
}
