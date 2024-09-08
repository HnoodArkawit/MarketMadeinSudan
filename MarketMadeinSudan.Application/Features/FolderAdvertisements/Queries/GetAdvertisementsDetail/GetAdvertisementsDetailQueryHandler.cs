using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsDetail
{
    public class GetAdvertisementsDetailQueryHandler : IRequestHandler<GetAdvertisementsDetailQuery, GetAdvertisementsDetailViewModel>
    {
        private readonly IAdvertisementsRepository _AdvertisementsRepository;
        private readonly IMapper _mapper;

        public GetAdvertisementsDetailQueryHandler(IAdvertisementsRepository AdvertisementsRepository, IMapper mapper)
        {
            _AdvertisementsRepository = AdvertisementsRepository;
            _mapper = mapper;
        }
        public async Task<GetAdvertisementsDetailViewModel> Handle(GetAdvertisementsDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _AdvertisementsRepository.GetAdvertisementsByIdAsync(request.AdvertisementId);

            return _mapper.Map<GetAdvertisementsDetailViewModel>(Post);
        }
    }
}
