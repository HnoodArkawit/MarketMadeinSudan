using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.CreateSportAndEntertainment
{
    public class CreateSportAndEntertainmentCommandHandler : IRequestHandler<CreateSportAndEntertainmentCommand, Guid>
    {
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        private readonly IMapper _mapper;

        public CreateSportAndEntertainmentCommandHandler(ISportAndEntertainmentRepository sportAndEntertainmentRepository, IMapper mapper)
        {
            _SportAndEntertainmentRepository = sportAndEntertainmentRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateSportAndEntertainmentCommand request, CancellationToken cancellationToken)
        {
            SportAndEntertainment sportAndEntertainment = _mapper.Map<SportAndEntertainment>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            sportAndEntertainment = await _SportAndEntertainmentRepository.AddAsync(sportAndEntertainment);

            return sportAndEntertainment.SportAndEntertainmentId;
        }


    }
}
