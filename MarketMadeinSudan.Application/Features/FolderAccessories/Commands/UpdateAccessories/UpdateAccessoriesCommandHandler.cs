using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAccessories.Commands.UpdateAccessories
{
    public class UpdateAccessoriesCommandHandler : IRequestHandler<UpdateAccessoriesCommand>
    {
        private readonly IAsyncRepository<Accessories> _AccessoriesRepository;
        private readonly IMapper _mapper;
        public UpdateAccessoriesCommandHandler(IAsyncRepository<Accessories> accessoriesRepository, IMapper mapper)
        {
            _AccessoriesRepository = accessoriesRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccessoriesCommand request, CancellationToken cancellationToken)
        {
            Accessories accessories = _mapper.Map<Accessories>(request);

            await _AccessoriesRepository.UpdateAsync(accessories);

            return Unit.Value;
        }

    }

}
