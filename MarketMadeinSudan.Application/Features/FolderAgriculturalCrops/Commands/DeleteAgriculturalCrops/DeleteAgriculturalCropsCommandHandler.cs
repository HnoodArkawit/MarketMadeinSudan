using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.DeleteAgriculturalCrops
{
    public class DeleteAgriculturalCropsCommandHandler : IRequestHandler<DeleteAgriculturalCropsCommand>
    {
        private readonly IAgriculturalCropsRepository _AgriculturalCropsRepository;
        public DeleteAgriculturalCropsCommandHandler(IAgriculturalCropsRepository agriculturalCropsRepository)
        {
            _AgriculturalCropsRepository = agriculturalCropsRepository;
        }

        public async Task<Unit> Handle(DeleteAgriculturalCropsCommand request, CancellationToken cancellationToken)
        {
            var post = await _AgriculturalCropsRepository.GetByIdAsync(request.AgriculturalCropsId);

            await _AgriculturalCropsRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
