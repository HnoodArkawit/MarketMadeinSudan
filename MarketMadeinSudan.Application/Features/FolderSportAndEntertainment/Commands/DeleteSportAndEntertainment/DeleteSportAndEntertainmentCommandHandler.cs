using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.DeleteSportAndEntertainment
{
    public class DeleteSportAndEntertainmentCommandHandler : IRequestHandler<DeleteSportAndEntertainmentCommand>
    {
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        public DeleteSportAndEntertainmentCommandHandler(ISportAndEntertainmentRepository sportAndEntertainmentRepository)
        {
            _SportAndEntertainmentRepository = sportAndEntertainmentRepository;
        }

        public async Task<Unit> Handle(DeleteSportAndEntertainmentCommand request, CancellationToken cancellationToken)
        {
            var post = await _SportAndEntertainmentRepository.GetByIdAsync(request.SportAndEntertainmentId);

            await _SportAndEntertainmentRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
