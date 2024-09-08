using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Commands.DeleteCart
{
    public class DeleteCartCommand : IRequest
    {
        public Guid ProductId { get; set; }

    }
}

