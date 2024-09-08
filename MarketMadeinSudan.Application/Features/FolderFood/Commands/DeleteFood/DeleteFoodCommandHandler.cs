using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFood.Commands.DeleteFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
    {
        private readonly IFoodRepository _FoodRepository;
        public DeleteFoodCommandHandler(IFoodRepository foodRepository)
        {
            _FoodRepository = foodRepository;
        }

        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var post = await _FoodRepository.GetByIdAsync(request.FoodId);

            await _FoodRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
