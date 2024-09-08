using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Commands.UpdateFabrics
{
    public class UpdateFabricsCommandHandler : IRequestHandler<UpdateFabricsCommand>
    {
        private readonly IAsyncRepository<Fabrics> _FabricsRepository;
        private readonly IMapper _mapper;
        public UpdateFabricsCommandHandler(IAsyncRepository<Fabrics> fabricsRepository, IMapper mapper)
        {
            _FabricsRepository = fabricsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFabricsCommand request, CancellationToken cancellationToken)
        {
            Fabrics fabrics = _mapper.Map<Fabrics>(request);

            await _FabricsRepository.UpdateAsync(fabrics);

            return Unit.Value;
        }

    }

}
