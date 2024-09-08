using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Commands.CreateFood
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Guid>
    {
        private readonly IFoodRepository _FoodRepository;
        private readonly IMapper _mapper;

        public CreateFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _FoodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            Food food = _mapper.Map<Food>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            food = await _FoodRepository.AddAsync(food);

            return food.FoodId;
        }


    }
}
