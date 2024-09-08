using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAspires.Commands.GetAspiresDetail
{
    public class GetAspiresDetailQueryHandler : IRequestHandler<GetAspiresDetailQuery, GetAspiresDetailViewModel>
    {
        private readonly IAspiresRepository _AspiresRepository;
        private readonly IMapper _mapper;

        public GetAspiresDetailQueryHandler(IAspiresRepository aspiresRepository, IMapper mapper)
        {
            _AspiresRepository = aspiresRepository;
            _mapper = mapper;
        }
        public async Task<GetAspiresDetailViewModel> Handle(GetAspiresDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _AspiresRepository.GetAspiresByIdAsync(request.AspiresId);

            return _mapper.Map<GetAspiresDetailViewModel>(Post);
        }
    }
}
