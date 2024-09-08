using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Queries.GetAgriculturalCropsList
{
    public class GetAgriculturalCropsListQueryHandler : IRequestHandler<GetAgriculturalCropsListQuery, List<GetAgriculturalCropsListViewModel>>
    {
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        private readonly IMapper _mapper;

        public GetAgriculturalCropsListQueryHandler(IAgriculturalCropsRepository agriculturalCropsRepository, IMapper mapper)
        {
            _AgriculturalCropsRepository = agriculturalCropsRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAgriculturalCropsListViewModel>> Handle(GetAgriculturalCropsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _AgriculturalCropsRepository.GetAllAgriculturalCropsAsync();
            return _mapper.Map<List<GetAgriculturalCropsListViewModel>>(allPosts);
        }
    }
}
