using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartDetail
{
    public class GetCartDetailQuery : IRequest<GetCartDetailViewModel>
    {
        public Guid ProductId { get; set; }
    }
}