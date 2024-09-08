using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.UpdatePublishers
{
    public class UpdatePublishersCommandHandler : IRequestHandler<UpdatePublishersCommand>
    {
        private readonly IAsyncRepository<Publishers> _PublishersRepository;
        private readonly IMapper _mapper;
        public UpdatePublishersCommandHandler(IAsyncRepository<Publishers> publishersRepository, IMapper mapper)
        {
            _PublishersRepository = publishersRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePublishersCommand request, CancellationToken cancellationToken)
        {
            Publishers publishers = _mapper.Map<Publishers>(request);

            await _PublishersRepository.UpdateAsync(publishers);

            return Unit.Value;
        }

    }

}
