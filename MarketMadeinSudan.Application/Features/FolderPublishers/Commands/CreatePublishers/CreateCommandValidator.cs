using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderPublishers.Commands.CreatePublishers
{
    public class CreateCommandValidator : AbstractValidator<CreatePublishersCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.NameCompany)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.DescriptionCompany)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Employment)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.FounderAddress)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.WebSite)
.NotEmpty()
.NotNull();

            RuleFor(p => p.Email)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.Phone)
   .NotEmpty()
   .NotNull();

        }

    }
}
