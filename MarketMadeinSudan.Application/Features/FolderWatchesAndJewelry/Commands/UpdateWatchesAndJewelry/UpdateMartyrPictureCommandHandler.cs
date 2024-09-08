using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.UpdateWatchesAndJewelry
{
    public class UpdateMartyrPictureCommandHandler : IRequestHandler<UpdateWatchesAndJewelryCommand>
    {
        private readonly IAsyncRepository<WatchesAndJewelry> _WatchesAndJewelryRepository;
        private readonly IMapper _mapper;
        public UpdateMartyrPictureCommandHandler(IAsyncRepository<WatchesAndJewelry> watchesAndJewelryRepository, IMapper mapper)
        {
            _WatchesAndJewelryRepository = watchesAndJewelryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWatchesAndJewelryCommand request, CancellationToken cancellationToken)
        {
            WatchesAndJewelry watchesAndJewelry = _mapper.Map<WatchesAndJewelry>(request);

            await _WatchesAndJewelryRepository.UpdateAsync(watchesAndJewelry);

            return Unit.Value;
        }

    }

}
