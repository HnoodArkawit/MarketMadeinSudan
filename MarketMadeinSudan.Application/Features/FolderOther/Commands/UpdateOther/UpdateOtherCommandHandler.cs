using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Commands.UpdateOther
{
    public class UpdateOtherCommandHandler : IRequestHandler<UpdateOtherCommand>
    {
        private readonly IAsyncRepository<Other> _OtherRepository;
        private readonly IMapper _mapper;
        public UpdateOtherCommandHandler(IAsyncRepository<Other> otherRepository, IMapper mapper)
        {
            _OtherRepository = otherRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOtherCommand request, CancellationToken cancellationToken)
        {
            Other other = _mapper.Map<Other>(request);

            await _OtherRepository.UpdateAsync(other);

            return Unit.Value;
        }

    }

}
