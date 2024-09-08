using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsList
{
    public class GetOrderDetailsListQueryHandler : IRequestHandler<GetOrderDetailsListQuery, List<GetOrderDetailsListViewModel>>
    {
        private readonly IOrderDetailsRepository _postRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsListQueryHandler(IOrderDetailsRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetOrderDetailsListViewModel>> Handle(GetOrderDetailsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllOrderDetailsAsync();
            return _mapper.Map<List<GetOrderDetailsListViewModel>>(allPosts);
        }
    }
}
