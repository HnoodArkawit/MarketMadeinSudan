using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderCart.Queries.GetCartDetail
{
    public class GetCartDetailQueryHandler : IRequestHandler<GetCartDetailQuery, GetCartDetailViewModel>
    {
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;

        public GetCartDetailQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _CartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<GetCartDetailViewModel> Handle(GetCartDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _CartRepository.GetCartByIdAsync(request.ProductId);

            return _mapper.Map<GetCartDetailViewModel>(Post);
        }
    }
}
