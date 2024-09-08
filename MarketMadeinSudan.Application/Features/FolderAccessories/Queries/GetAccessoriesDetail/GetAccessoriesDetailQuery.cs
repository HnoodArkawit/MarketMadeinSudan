using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Queries.GetAccessoriesDetail
{
    public class GetAccessoriesDetailQuery : IRequest<GetAccessoriesDetailViewModel>
    {
        public Guid AccessoriesId { get; set; }
    }
}
