using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Queries.GetShippingList
{
    public class GetShippingListQueryHandler : IRequestHandler<GetShippingListQuery, List<GetShippingListViewModel>>
    {
        private readonly IShippingRepository _postRepository;
        private readonly IMapper _mapper;

        public GetShippingListQueryHandler(IShippingRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetShippingListViewModel>> Handle(GetShippingListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllShippingAsync();
            return _mapper.Map<List<GetShippingListViewModel>>(allPosts);
        }
    }
}
