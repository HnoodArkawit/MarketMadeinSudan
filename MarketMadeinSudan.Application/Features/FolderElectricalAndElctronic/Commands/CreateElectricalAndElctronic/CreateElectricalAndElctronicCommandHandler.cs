using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.CreateElectricalAndElctronic
{
    public class CreateElectricalAndElctronicCommandHandler : IRequestHandler<CreateElectricalAndElctronicCommand, Guid>
    {
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        private readonly IMapper _mapper;

        public CreateElectricalAndElctronicCommandHandler(IElectricalAndElctronicRepository electricalAndElctronicRepository, IMapper mapper)
        {
            _ElectricalAndElctronicRepository = electricalAndElctronicRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateElectricalAndElctronicCommand request, CancellationToken cancellationToken)
        {
            ElectricalAndElctronic electricalAndElctronic = _mapper.Map<ElectricalAndElctronic>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            electricalAndElctronic = await _ElectricalAndElctronicRepository.AddAsync(electricalAndElctronic);

            return electricalAndElctronic.ElectricalAndElctronicId;
        }


    }
}
