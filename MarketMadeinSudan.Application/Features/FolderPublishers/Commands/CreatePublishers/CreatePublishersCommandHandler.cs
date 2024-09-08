using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.CreatePublishers
{
    public class CreatePublishersCommandHandler : IRequestHandler<CreatePublishersCommand, Guid>
    {
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IMapper _mapper;

        public CreatePublishersCommandHandler(IPublishersRepository publishersRepository, IMapper mapper)
        {
            _PublishersRepository = publishersRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreatePublishersCommand request, CancellationToken cancellationToken)
        {
            Publishers publishers = _mapper.Map<Publishers>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            publishers = await _PublishersRepository.AddAsync(publishers);

            return publishers.PublishersId;
        }


    }
}
