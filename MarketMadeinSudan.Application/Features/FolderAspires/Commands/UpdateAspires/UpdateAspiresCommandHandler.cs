using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.UpdateAspires
{
    public class UpdateAspiresCommandHandler : IRequestHandler<UpdateAspiresCommand>
    {
        private readonly IAsyncRepository<Aspires> _AspiresRepository;
        private readonly IMapper _mapper;
        public UpdateAspiresCommandHandler(IAsyncRepository<Aspires> aspiresRepository, IMapper mapper)
        {
            _AspiresRepository = aspiresRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAspiresCommand request, CancellationToken cancellationToken)
        {
            Aspires aspires = _mapper.Map<Aspires>(request);

            await _AspiresRepository.UpdateAsync(aspires);

            return Unit.Value;
        }

    }

}
