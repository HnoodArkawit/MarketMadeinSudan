using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Queries.GetOrderDetailsDetail
{
    public class GetOrderDetailsDetailQueryHandler : IRequestHandler<GetOrderDetailsDetailQuery, GetOrderDetailsDetailViewModel>
    {
        private readonly IOrderDetailsRepository _OrderDetailsRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsDetailQueryHandler(IOrderDetailsRepository OrderDetailsRepository, IMapper mapper)
        {
            _OrderDetailsRepository = OrderDetailsRepository;
            _mapper = mapper;
        }
        public async Task<GetOrderDetailsDetailViewModel> Handle(GetOrderDetailsDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _OrderDetailsRepository.GetOrderDetailsByIdAsync(request.OrderDetailsId);

            return _mapper.Map<GetOrderDetailsDetailViewModel>(Post);
        }
    }
}
