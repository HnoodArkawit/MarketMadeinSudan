using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentDetail
{
    public class GetSportAndEntertainmentDetailQueryHandler : IRequestHandler<GetSportAndEntertainmentDetailQuery, GetSportAndEntertainmentDetailViewModel>
    {
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        private readonly IMapper _mapper;

        public GetSportAndEntertainmentDetailQueryHandler(ISportAndEntertainmentRepository sportAndEntertainmentRepository, IMapper mapper)
        {
            _SportAndEntertainmentRepository = sportAndEntertainmentRepository;
            _mapper = mapper;
        }
        public async Task<GetSportAndEntertainmentDetailViewModel> Handle(GetSportAndEntertainmentDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _SportAndEntertainmentRepository.GetSportAndEntertainmentByIdAsync(request.SportAndEntertainmentId);

            return _mapper.Map<GetSportAndEntertainmentDetailViewModel>(Post);
        }
    }
}
