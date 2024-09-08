using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderElectricalAndElctronic.Commands.DeleteElectricalAndElctronic
{
    public class DeleteElectricalAndElctronicCommandHandler : IRequestHandler<DeleteElectricalAndElctronicCommand>
    {
        private readonly IElectricalAndElctronicRepository _ElectricalAndElctronicRepository;
        public DeleteElectricalAndElctronicCommandHandler(IElectricalAndElctronicRepository electricalAndElctronicRepository)
        {
            _ElectricalAndElctronicRepository = electricalAndElctronicRepository;
        }

        public async Task<Unit> Handle(DeleteElectricalAndElctronicCommand request, CancellationToken cancellationToken)
        {
            var post = await _ElectricalAndElctronicRepository.GetByIdAsync(request.ElectricalAndElctronicId);

            await _ElectricalAndElctronicRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
