using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Queries.GetFabricsDetail
{
    public class GetFabricsDetailQuery : IRequest<GetFabricsDetailViewModel>
    {
        public Guid FabricsId { get; set; }
    }
}
