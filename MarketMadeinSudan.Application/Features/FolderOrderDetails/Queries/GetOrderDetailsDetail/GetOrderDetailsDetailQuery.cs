using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsDetail
{
    public class GetOrderDetailsDetailQuery : IRequest<GetOrderDetailsDetailViewModel>
    {
        public Guid OrderDetailsId { get; set; }
    }
}
