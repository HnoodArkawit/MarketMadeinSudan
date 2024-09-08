using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Commands.UpdateFood
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand>
    {
        private readonly IAsyncRepository<Food> _FoodRepository;
        private readonly IMapper _mapper;
        public UpdateFoodCommandHandler(IAsyncRepository<Food> foodRepository, IMapper mapper)
        {
            _FoodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            Food food = _mapper.Map<Food>(request);

            await _FoodRepository.UpdateAsync(food);

            return Unit.Value;
        }

    }

}
