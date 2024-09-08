using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Queries.GetShippingDetail
{
    public class GetShippingDetailQueryHandler : IRequestHandler<GetShippingDetailQuery, GetShippingDetailViewModel>
    {
        private readonly IShippingRepository _ShippingRepository;
        private readonly IMapper _mapper;

        public GetShippingDetailQueryHandler(IShippingRepository ShippingRepository, IMapper mapper)
        {
            _ShippingRepository = ShippingRepository;
            _mapper = mapper;
        }
        public async Task<GetShippingDetailViewModel> Handle(GetShippingDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _ShippingRepository.GetShippingByIdAsync(request.ShippingId);

            return _mapper.Map<GetShippingDetailViewModel>(Post);
        }
    }
}
