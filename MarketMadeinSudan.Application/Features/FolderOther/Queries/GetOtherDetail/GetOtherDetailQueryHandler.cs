using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Queries.GetOtherDetail
{
    public class GetOtherDetailQueryHandler : IRequestHandler<GetOtherDetailQuery, GetOtherDetailViewModel>
    {
        private readonly IOtherRepository _OtherRepository;
        private readonly IMapper _mapper;

        public GetOtherDetailQueryHandler(IOtherRepository otherRepository, IMapper mapper)
        {
            _OtherRepository = otherRepository;
            _mapper = mapper;
        }
        public async Task<GetOtherDetailViewModel> Handle(GetOtherDetailQuery request, CancellationToken cancellationToken)
        {
            var Post = await _OtherRepository.GetOtherByIdAsync(request.OtherId);

            return _mapper.Map<GetOtherDetailViewModel>(Post);
        }
    }
}
