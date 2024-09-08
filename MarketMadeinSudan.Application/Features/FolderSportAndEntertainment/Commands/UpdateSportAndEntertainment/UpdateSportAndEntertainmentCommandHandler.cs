using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Commands.UpdateSportAndEntertainment;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MartyrDecember.Application.Features.MartyrPicture.Commands.UpdateMartyrPicture
{
    public class UpdateSportAndEntertainmentCommandHandler : IRequestHandler<UpdateSportAndEntertainmentCommand>
    {
        private readonly IAsyncRepository<SportAndEntertainment> _SportAndEntertainmentRepository;
        private readonly IMapper _mapper;
        public UpdateSportAndEntertainmentCommandHandler(IAsyncRepository<SportAndEntertainment> sportAndEntertainmentRepository, IMapper mapper)
        {
            _SportAndEntertainmentRepository = sportAndEntertainmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSportAndEntertainmentCommand request, CancellationToken cancellationToken)
        {
            SportAndEntertainment sportAndEntertainment = _mapper.Map<SportAndEntertainment>(request);

            await _SportAndEntertainmentRepository.UpdateAsync(sportAndEntertainment);

            return Unit.Value;
        }

    }

}
