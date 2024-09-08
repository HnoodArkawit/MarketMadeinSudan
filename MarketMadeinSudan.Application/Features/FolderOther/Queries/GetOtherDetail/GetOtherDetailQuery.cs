using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Queries.GetOtherDetail
{
    public class GetOtherDetailQuery : IRequest<GetOtherDetailViewModel>
    {
        public Guid OtherId { get; set; }
    }
}
