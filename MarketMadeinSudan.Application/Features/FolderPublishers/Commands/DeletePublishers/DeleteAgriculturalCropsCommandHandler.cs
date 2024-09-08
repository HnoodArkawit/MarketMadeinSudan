using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.DeletePublishers
{
    public class DeletePublishersCommandHandler : IRequestHandler<DeletePublishersCommand>
    {
        private readonly IPublishersRepository _PublishersRepository;
        public DeletePublishersCommandHandler(IPublishersRepository publishersRepository)
        {
            _PublishersRepository = publishersRepository;
        }

        public async Task<Unit> Handle(DeletePublishersCommand request, CancellationToken cancellationToken)
        {
            var post = await _PublishersRepository.GetByIdAsync(request.PublishersId);

            await _PublishersRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
