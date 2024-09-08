using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Commands.DeleteOther
{
    public class DeleteOtherCommandHandler : IRequestHandler<DeleteOtherCommand>
    {
        private readonly IOtherRepository _OtherRepository;
        public DeleteOtherCommandHandler(IOtherRepository otherRepository)
        {
            _OtherRepository = otherRepository;
        }

        public async Task<Unit> Handle(DeleteOtherCommand request, CancellationToken cancellationToken)
        {
            var post = await _OtherRepository.GetByIdAsync(request.OtherId);

            await _OtherRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
