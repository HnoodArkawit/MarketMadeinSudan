using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderAdvertisements.Commands.CreateAdvertisements
{
    public class CreateCommandValidator : AbstractValidator<CreateAdvertisementsCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.ImageUrl)
               .NotEmpty()
               .NotNull();

        }

    }
}
