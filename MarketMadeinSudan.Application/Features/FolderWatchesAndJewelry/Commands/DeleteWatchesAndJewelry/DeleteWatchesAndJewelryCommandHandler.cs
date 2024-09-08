using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.DeleteWatchesAndJewelry
{
    public class DeleteWatchesAndJewelryCommandHandler : IRequestHandler<DeleteWatchesAndJewelryCommand>
    {
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        public DeleteWatchesAndJewelryCommandHandler(IWatchesAndJewelryRepository watchesAndJewelryRepository)
        {
            _WatchesAndJewelryRepository = watchesAndJewelryRepository;
        }

        public async Task<Unit> Handle(DeleteWatchesAndJewelryCommand request, CancellationToken cancellationToken)
        {
            var post = await _WatchesAndJewelryRepository.GetByIdAsync(request.WatchesAndJewelryId);

            await _WatchesAndJewelryRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
