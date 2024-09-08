using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderSportAndEntertainment.Queries.GetSportAndEntertainmentList
{
    public class GetSportAndEntertainmentListQueryHandler : IRequestHandler<GetSportAndEntertainmentListQuery, List<GetSportAndEntertainmentListViewModel>>
    {
        private readonly ISportAndEntertainmentRepository _SportAndEntertainmentRepository;
        private readonly IMapper _mapper;

        public GetSportAndEntertainmentListQueryHandler(ISportAndEntertainmentRepository sportAndEntertainmentRepository, IMapper mapper)
        {
            _SportAndEntertainmentRepository = sportAndEntertainmentRepository;
            _mapper = mapper;
        }
        public async Task<List<GetSportAndEntertainmentListViewModel>> Handle(GetSportAndEntertainmentListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _SportAndEntertainmentRepository.GetAllSportAndEntertainmentAsync();
            return _mapper.Map<List<GetSportAndEntertainmentListViewModel>>(allPosts);
        }
    }
}
