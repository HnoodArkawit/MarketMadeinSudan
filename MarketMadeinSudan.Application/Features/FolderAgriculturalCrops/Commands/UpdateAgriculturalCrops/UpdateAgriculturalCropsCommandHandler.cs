using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.UpdateAgriculturalCrops
{
    public class UpdateAgriculturalCropsCommandHandler : IRequestHandler<UpdateAgriculturalCropsCommand>
    {
        private readonly IAsyncRepository<AgriculturalCrops> _AgriculturalCropsRepository;
        private readonly IMapper _mapper;
        public UpdateAgriculturalCropsCommandHandler(IAsyncRepository<AgriculturalCrops> agriculturalCropsRepository, IMapper mapper)
        {
            _AgriculturalCropsRepository = agriculturalCropsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAgriculturalCropsCommand request, CancellationToken cancellationToken)
        {
            AgriculturalCrops agriculturalCrops = _mapper.Map<AgriculturalCrops>(request);

            await _AgriculturalCropsRepository.UpdateAsync(agriculturalCrops);

            return Unit.Value;
        }

    }

}
