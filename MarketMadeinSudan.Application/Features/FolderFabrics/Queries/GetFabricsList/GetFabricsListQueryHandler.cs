using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderFabrics.Queries.GetFabricsList
{
    public class GetFabricsListQueryHandler : IRequestHandler<GetFabricsListQuery, List<GetFabricsListViewModel>>
    {
        private readonly IFabricsRepository _FabricsRepository;
        private readonly IMapper _mapper;

        public GetFabricsListQueryHandler(IFabricsRepository fabricsRepository, IMapper mapper)
        {
            _FabricsRepository = fabricsRepository;
            _mapper = mapper;
        }
        public async Task<List<GetFabricsListViewModel>> Handle(GetFabricsListQuery request, CancellationToken cancellationToken)
        {
            var allFabrics = await _FabricsRepository.GetAllFabricsAsync();
            return _mapper.Map<List<GetFabricsListViewModel>>(allFabrics);
        }
    }
}
