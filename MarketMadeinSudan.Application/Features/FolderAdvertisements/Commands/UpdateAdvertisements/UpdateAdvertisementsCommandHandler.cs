using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.UpdateAdvertisements
{
    public class UpdateAdvertisementsCommandHandler : IRequestHandler<UpdateAdvertisementsCommand>
    {
        private readonly IAsyncRepository<Advertisements> _picRepository;
        private readonly IMapper _mapper;
        public UpdateAdvertisementsCommandHandler(IAsyncRepository<Advertisements> picRepository, IMapper mapper)
        {
            _picRepository = picRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdvertisementsCommand request, CancellationToken cancellationToken)
        {
            Advertisements Advertisements = _mapper.Map<Advertisements>(request);

            await _picRepository.UpdateAsync(Advertisements);

            return Unit.Value;
        }

    }

}
