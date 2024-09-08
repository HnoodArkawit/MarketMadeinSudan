using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.GetElectricalAndElctronicDetail
{
    public class GetElectricalAndElctronicDetailQueryHandler : IRequestHandler<GetElectricalAndElctronicDetailQuery, GetElectricalAndElctronicDetailViewModel>
    {
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        private readonly IMapper _mapper;

        public GetElectricalAndElctronicDetailQueryHandler(IElectricalAndElctronicRepository electricalAndElctronicRepository, IMapper mapper)
        {
            _ElectricalAndElctronicRepository = electricalAndElctronicRepository;
            _mapper = mapper;
        }
        public async Task<GetElectricalAndElctronicDetailViewModel> Handle(GetElectricalAndElctronicDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _ElectricalAndElctronicRepository.GetElectricalAndElctronicByIdAsync(request.ElectricalAndElctronicId);

            return _mapper.Map<GetElectricalAndElctronicDetailViewModel>(Post);
        }
    }
}
