using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresDetail
{
    public class GetAspiresDetailQuery : IRequest<GetAspiresDetailViewModel>
    {
        public Guid AspiresId { get; set; }
    }
}
