using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersList;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FoldePublishers.Queries.GetPublishersList
{
    public class GetPublishersListQueryHandler : IRequestHandler<GePublishersListQuery, List<GetPublishersListViewModel>>
    {
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IMapper _mapper;

        public GetPublishersListQueryHandler(IPublishersRepository publishersRepository, IMapper mapper)
        {
            _PublishersRepository = publishersRepository;
            _mapper = mapper;
        }
        public async Task<List<GetPublishersListViewModel>> Handle(GePublishersListQuery request, CancellationToken cancellationToken)
        {
            var allPosts = await _PublishersRepository.GetAllPublishersAsync();
            return _mapper.Map<List<GetPublishersListViewModel>>(allPosts);
        }
    }
}
