using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Queries.GetOtherList
{
    public class GetOtherListQueryHandler : IRequestHandler<GetOtherListQuery, List<GetOtherListViewModel>>
    {
        private readonly IOtherRepository _OtherRepository;
        private readonly IMapper _mapper;

        public GetOtherListQueryHandler(IOtherRepository otherRepository, IMapper mapper)
        {
            _OtherRepository = otherRepository;
            _mapper = mapper;
        }
        public async Task<List<GetOtherListViewModel>> Handle(GetOtherListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _OtherRepository.GetAllOtherAsync();
            return _mapper.Map<List<GetOtherListViewModel>>(allPosts);
        }
    }
}
