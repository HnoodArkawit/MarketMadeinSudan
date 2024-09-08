using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Queries.GetFoodDetail
{
    public class GetFoodDetailQueryHandler : IRequestHandler<GetFoodDetailQuery, GetFoodDetailViewModel>
    {
        private readonly IFoodRepository _FoodRepository;
        private readonly IMapper _mapper;

        public GetFoodDetailQueryHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _FoodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<GetFoodDetailViewModel> Handle(GetFoodDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _FoodRepository.GetFoodByIdAsync(request.FoodId);

            return _mapper.Map<GetFoodDetailViewModel>(Post);
        }
    }
}
