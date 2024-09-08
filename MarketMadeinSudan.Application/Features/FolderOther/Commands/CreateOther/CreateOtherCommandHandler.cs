using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderOther.Commands.CreateOther
{
    public class CreateOtherCommandHandler : IRequestHandler<CreateOtherCommand, Guid>
    {
        private readonly IOtherRepository _OtherRepository;
        private readonly IMapper _mapper;

        public CreateOtherCommandHandler(IOtherRepository otherRepository, IMapper mapper)
        {
            _OtherRepository = otherRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateOtherCommand request, CancellationToken cancellationToken)
        {
            Other other = _mapper.Map<Other>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            other = await _OtherRepository.AddAsync(other);

            return other.OtherId;
        }


    }
}
