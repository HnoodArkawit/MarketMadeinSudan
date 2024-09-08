using MarketMadeinSudan.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Application.Features.FolderHouseholdProducts.Commands.DeleteHouseholdProducts
{
    public class DeleteHouseholdProductsCommandHandler : IRequestHandler<DeleteHouseholdProductsCommand>
    {
        private readonly IHouseholdProductsRepository _HouseholdProductsRepository;
        public DeleteHouseholdProductsCommandHandler(IHouseholdProductsRepository householdProductsRepository)
        {
            _HouseholdProductsRepository = householdProductsRepository;
        }

        public async Task<Unit> Handle(DeleteHouseholdProductsCommand request, CancellationToken cancellationToken)
        {
            var post = await _HouseholdProductsRepository.GetByIdAsync(request.HouseholdProductsId);

            await _HouseholdProductsRepository.DeleteAsync(post);

            return Unit.Value;
        }
    }
}
