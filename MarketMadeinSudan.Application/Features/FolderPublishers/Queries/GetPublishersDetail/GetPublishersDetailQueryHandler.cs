using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Queries.GetPublishersDetail
{
    public class GetPublishersDetailQueryHandler : IRequestHandler<GetPublishersDetailQuery, GetPublishersDetailViewModel>
    {
        private readonly IPublishersRepository _PublishersRepository;
        private readonly IMapper _mapper;

        public GetPublishersDetailQueryHandler(IPublishersRepository publishersRepository, IMapper mapper)
        {
            _PublishersRepository = publishersRepository;
            _mapper = mapper;
        }
        public async Task<GetPublishersDetailViewModel> Handle(GetPublishersDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _PublishersRepository.GetPublishersByIdAsync(request.PublishersId);

            return _mapper.Map<GetPublishersDetailViewModel>(Post);
        }
    }
}
