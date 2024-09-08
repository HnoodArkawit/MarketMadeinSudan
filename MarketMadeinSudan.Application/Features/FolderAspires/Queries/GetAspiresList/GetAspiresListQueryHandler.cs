using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresList
{
    public class GetAspiresListQueryHandler : IRequestHandler<GetAspiresListQuery, List<GetAspiresListViewModel>>
    {
        private readonly IAspiresRepository _AspiresRepository;
        private readonly IMapper _mapper;

        public GetAspiresListQueryHandler(IAspiresRepository aspiresRepository, IMapper mapper)
        {
            _AspiresRepository = aspiresRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAspiresListViewModel>> Handle(GetAspiresListQuery request, CancellationToken cancellationToken)
        {
            var allAspires = await _AspiresRepository.GetAllAspiresAsync();
            return _mapper.Map<List<GetAspiresListViewModel>>(allAspires);
        }
    }
}
