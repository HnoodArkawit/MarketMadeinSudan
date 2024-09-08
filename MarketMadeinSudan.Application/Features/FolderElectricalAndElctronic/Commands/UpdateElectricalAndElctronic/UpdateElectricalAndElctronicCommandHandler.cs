using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.UpdateElectricalAndElctronic
{
    public class UpdateElectricalAndElctronicCommandHandler : IRequestHandler<UpdateElectricalAndElctronicCommand>
    {
        private readonly IAsyncRepository<ElectricalAndElctronic> _ElectricalAndElctronicRepository;
        private readonly IMapper _mapper;
        public UpdateElectricalAndElctronicCommandHandler(IAsyncRepository<ElectricalAndElctronic> electricalAndElctronicRepository, IMapper mapper)
        {
            _ElectricalAndElctronicRepository = electricalAndElctronicRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateElectricalAndElctronicCommand request, CancellationToken cancellationToken)
        {
            ElectricalAndElctronic electricalAndElctronic = _mapper.Map<ElectricalAndElctronic>(request);

            await _ElectricalAndElctronicRepository.UpdateAsync(electricalAndElctronic);

            return Unit.Value;
        }

    }

}
