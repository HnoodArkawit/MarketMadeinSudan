using AutoMapper;
using MarketMadeinSudan.Application.Contracts;
using MarketMadeinSudan.Domin;
using MediatR;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.CreateAdvertisements
{
    public class CreateAdvertisementsCommandHandler : IRequestHandler<CreateAdvertisementsCommand, Guid>
    {
        private readonly IAdvertisementsRepository _martyrPictureRepository;
        private readonly IMapper _mapper;

        public CreateAdvertisementsCommandHandler(IAdvertisementsRepository martyrPictureRepository, IMapper mapper)
        {
            _martyrPictureRepository = martyrPictureRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAdvertisementsCommand request, CancellationToken cancellationToken)
        {
            Advertisements martyrPicture = _mapper.Map<Advertisements>(request);

            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid");
            }

            martyrPicture = await _martyrPictureRepository.AddAsync(martyrPicture);

            return martyrPicture.AdvertisementId;
        }


    }
}
