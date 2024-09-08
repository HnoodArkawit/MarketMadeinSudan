using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Queries.GetAdvertisementsList
{
    public class GetAdvertisementsListQueryHandler : IRequestHandler<GetAdvertisementsListQuery, List<GetAdvertisementsListViewModel>>
    {
        private readonly IAdvertisementsRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAdvertisementsListQueryHandler(IAdvertisementsRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAdvertisementsListViewModel>> Handle(GetAdvertisementsListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _postRepository.GetAllAdvertisementsAsync();
            return _mapper.Map<List<GetAdvertisementsListViewModel>>(allPosts);
        }
    }
}
