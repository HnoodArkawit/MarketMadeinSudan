using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Queries.GetHouseholdProductsDetail
{
    public class GetHouseholdProductsDetailQuery : IRequest<GetHouseholdProductsDetailViewModel>
    {
        public Guid HouseholdProductsId { get; set; }
    }
}
