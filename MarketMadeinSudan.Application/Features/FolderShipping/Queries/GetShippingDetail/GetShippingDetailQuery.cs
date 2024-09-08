using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Queries.GetShippingDetail
{
    public class GetShippingDetailQuery : IRequest<GetShippingDetailViewModel>
    {
        public Guid ShippingId { get; set; }
    }
}
