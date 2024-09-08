using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.DeleteElectricalAndElctronic
{
    public class DeleteElectricalAndElctronicCommand : IRequest
    {
        public Guid ElectricalAndElctronicId { get; set; }

    }
}
