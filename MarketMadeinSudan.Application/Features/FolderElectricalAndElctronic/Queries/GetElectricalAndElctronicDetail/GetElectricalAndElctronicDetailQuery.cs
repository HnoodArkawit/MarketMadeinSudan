using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.GetElectricalAndElctronicDetail
{
    public class GetElectricalAndElctronicDetailQuery : IRequest<GetElectricalAndElctronicDetailViewModel>
    {
        public Guid ElectricalAndElctronicId { get; set; }
    }
}
