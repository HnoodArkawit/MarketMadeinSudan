using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Queries.GetFoodList
{
    public class GetFoodListQueryHandler : IRequestHandler<GetFoodListQuery, List<GetFoodListViewModel>>
    {
        private readonly IFoodRepository _FoodRepository;
        private readonly IMapper _mapper;

        public GetFoodListQueryHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _FoodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<List<GetFoodListViewModel>> Handle(GetFoodListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _FoodRepository.GetAllFoodAsync();
            return _mapper.Map<List<GetFoodListViewModel>>(allPosts);
        }
    }
}
