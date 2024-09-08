using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.DeleteAdvertisements
{
    public class DeleteAdvertisementsCommandHandler : IRequestHandler<DeleteAdvertisementsCommand>
    {
        private readonly IAdvertisementsRepository _AdvertisementsRepository;
        public DeleteAdvertisementsCommandHandler(IAdvertisementsRepository AdvertisementsRepository)
        {
            _AdvertisementsRepository = AdvertisementsRepository;
        }

        public async Task<Unit> Handle(DeleteAdvertisementsCommand request, CancellationToken cancellationToken)
        {
            var post = await _AdvertisementsRepository.GetByIdAsync(request.AdvertisementId);

            await _AdvertisementsRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
