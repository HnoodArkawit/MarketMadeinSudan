using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentDetail
{
    public class GetSportAndEntertainmentDetailQuery : IRequest<GetSportAndEntertainmentDetailViewModel>
    {
        public Guid SportAndEntertainmentId { get; set; }
    }
}
