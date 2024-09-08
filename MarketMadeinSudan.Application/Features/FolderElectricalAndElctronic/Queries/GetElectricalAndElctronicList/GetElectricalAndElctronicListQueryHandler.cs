using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.GetElectricalAndElctronicList
{
    public class GetElectricalAndElctronicListQueryHandler : IRequestHandler<GetElectricalAndElctronicListQuery, List<GetElectricalAndElctronicListViewModel>>
    {
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        private readonly IMapper _mapper;

        public GetElectricalAndElctronicListQueryHandler(IElectricalAndElctronicRepository electricalAndElctronicRepository, IMapper mapper)
        {
            _ElectricalAndElctronicRepository = electricalAndElctronicRepository;
            _mapper = mapper;
        }
        public async Task<List<GetElectricalAndElctronicListViewModel>> Handle(GetElectricalAndElctronicListQuery request, CancellationToken cancellationToken)
        {
            var allElectricalAndElctronic = await _ElectricalAndElctronicRepository.GetAllElectricalAndElctronicAsync();
            return _mapper.Map<List<GetElectricalAndElctronicListViewModel>>(allElectricalAndElctronic);
        }
    }
}
