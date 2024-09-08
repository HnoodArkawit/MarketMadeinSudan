using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.DeleteShipping
{
    public class DeleteShippingCommand : IRequest
    {
        public Guid ShippingId { get; set; }

    }
}
