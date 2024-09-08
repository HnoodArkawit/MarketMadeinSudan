using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Queries.GetFabricsDetail
{
    public class GetFabricsDetailQueryHandler : IRequestHandler<GetFabricsDetailQuery, GetFabricsDetailViewModel>
    {
        private readonly IFabricsRepository _FabricsRepository;
        private readonly IMapper _mapper;

        public GetFabricsDetailQueryHandler(IFabricsRepository fabricsRepository, IMapper mapper)
        {
            _FabricsRepository = fabricsRepository;
            _mapper = mapper;
        }
        public async Task<GetFabricsDetailViewModel> Handle(GetFabricsDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _FabricsRepository.GetFabricsByIdAsync(request.FabricsId);

            return _mapper.Map<GetFabricsDetailViewModel>(Post);
        }
    }
}
