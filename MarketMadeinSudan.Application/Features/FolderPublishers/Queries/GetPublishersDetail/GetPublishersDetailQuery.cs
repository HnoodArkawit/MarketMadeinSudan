using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersDetail
{
    public class GetPublishersDetailQuery : IRequest<GetPublishersDetailViewModel>
    {
        public Guid PublishersId { get; set; }
    }
}
