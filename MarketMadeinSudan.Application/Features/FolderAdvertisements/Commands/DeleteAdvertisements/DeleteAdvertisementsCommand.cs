using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.DeleteAdvertisements
{
    public class DeleteAdvertisementsCommand : IRequest
    {
        public Guid AdvertisementId { get; set; }

    }
}
