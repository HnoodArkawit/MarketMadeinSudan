using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.CreateAspires
{
    public class CreateAspiresCommandHandler : IRequestHandler<CreateAspiresCommand, Guid>
    {
        private readonly IAspiresRepository _AspiresRepository;
        private readonly IMapper _mapper;

        public CreateAspiresCommandHandler(IAspiresRepository aspiresRepository, IMapper mapper)
        {
            _AspiresRepository = aspiresRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAspiresCommand request, CancellationToken cancellationToken)
        {
            Aspires aspires = _mapper.Map<Aspires>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            aspires = await _AspiresRepository.AddAsync(aspires);

            return aspires.AspiresId;
        }


    }
}
