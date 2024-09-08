using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartList
{
    public class GetCartListQueryHandler : IRequestHandler<GetCartListQuery, List<GetCartListViewModel>>
    {
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;

        public GetCartListQueryHandler(ICartRepository contactsRepository, IMapper mapper)
        {
            _CartRepository = contactsRepository;
            _mapper = mapper;
        }
        public async Task<List<GetCartListViewModel>> Handle(GetCartListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _CartRepository.GetAllCartAsync();
            return _mapper.Map<List<GetCartListViewModel>>(allPosts);
        }
    }
}
