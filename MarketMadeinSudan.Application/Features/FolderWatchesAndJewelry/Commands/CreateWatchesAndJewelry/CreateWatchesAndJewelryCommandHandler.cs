using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderWatchesAndJewelry.Commands.CreateWatchesAndJewelry
{
    public class CreateWatchesAndJewelryCommandHandler : IRequestHandler<CreateWatchesAndJewelryCommand, Guid>
    {
        private readonly IWatchesAndJewelryRepository _WatchesAndJewelryRepository;
        private readonly IMapper _mapper;

        public CreateWatchesAndJewelryCommandHandler(IWatchesAndJewelryRepository watchesAndJewelryRepository, IMapper mapper)
        {
            _WatchesAndJewelryRepository = watchesAndJewelryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateWatchesAndJewelryCommand request, CancellationToken cancellationToken)
        {
            WatchesAndJewelry watchesAndJewelry = _mapper.Map<WatchesAndJewelry>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            watchesAndJewelry = await _WatchesAndJewelryRepository.AddAsync(watchesAndJewelry);

            return watchesAndJewelry.WatchesAndJewelryId;
        }
    }
}
