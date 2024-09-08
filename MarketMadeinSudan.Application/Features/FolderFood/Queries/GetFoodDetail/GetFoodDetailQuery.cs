using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Queries.GetFoodDetail
{
    public class GetFoodDetailQuery : IRequest<GetFoodDetailViewModel>
    {
        public Guid FoodId { get; set; }
    }
}
