using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartList
{
    public class GetCartListQuery : IRequest<List<GetCartListViewModel>>
    {
    }
}
