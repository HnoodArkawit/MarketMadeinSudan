using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Commands.CreateFabrics
{
    public class CreateFabricsCommandHandler : IRequestHandler<CreateFabricsCommand, Guid>
    {
        private readonly IFabricsRepository _FabricsRepository;
        private readonly IMapper _mapper;

        public CreateFabricsCommandHandler(IFabricsRepository fabricsRepository, IMapper mapper)
        {
            _FabricsRepository = fabricsRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateFabricsCommand request, CancellationToken cancellationToken)
        {
            Fabrics fabrics = _mapper.Map<Fabrics>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            fabrics = await _FabricsRepository.AddAsync(fabrics);

            return fabrics.FabricsId;
        }


    }
}
