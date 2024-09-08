using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.CreateAgriculturalCrops
{
    public class CreatePublishersCommandHandler : IRequestHandler<CreateAgriculturalCropsCommand, Guid>
    {
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        private readonly IMapper _mapper;

        public CreatePublishersCommandHandler(IAgriculturalCropsRepository agriculturalCropsRepository, IMapper mapper)
        {
            _AgriculturalCropsRepository = agriculturalCropsRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAgriculturalCropsCommand request, CancellationToken cancellationToken)
        {
            AgriculturalCrops agriculturalCrops = _mapper.Map<AgriculturalCrops>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            agriculturalCrops = await _AgriculturalCropsRepository.AddAsync(agriculturalCrops);

            return agriculturalCrops.AgriculturalCropsId;
        }


    }
}
