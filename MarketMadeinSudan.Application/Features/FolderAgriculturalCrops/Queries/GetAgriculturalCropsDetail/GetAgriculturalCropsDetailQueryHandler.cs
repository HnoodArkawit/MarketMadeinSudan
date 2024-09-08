using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsDetail
{
    public class GetAgriculturalCropsDetailQueryHandler : IRequestHandler<GetAgriculturalCropsDetailQuery, GetAgriculturalCropsDetailViewModel>
    {
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        private readonly IMapper _mapper;

        public GetAgriculturalCropsDetailQueryHandler(IAgriculturalCropsRepository AgriculturalCropsRepository, IMapper mapper)
        {
            _AgriculturalCropsRepository = AgriculturalCropsRepository;
            _mapper = mapper;
        }
        public async Task<GetAgriculturalCropsDetailViewModel> Handle(GetAgriculturalCropsDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _AgriculturalCropsRepository.GetAgriculturalCropsByIdAsync(request.AgriculturalCropsId);

            return _mapper.Map<GetAgriculturalCropsDetailViewModel>(Post);
        }
    }
}
