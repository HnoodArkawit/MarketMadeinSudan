using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderAgriculturalCrops.Commands.CreateAgriculturalCrops
{
    public class CreateCommandValidator : AbstractValidator<CreateAgriculturalCropsCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.AgriculturalCropsName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.ImageUrl)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.Quantity)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.Pirce)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.NameCompany)
.NotEmpty()
.NotNull();

            RuleFor(p => p.DateOfEstablishment)
.NotEmpty()
.NotNull();
            RuleFor(p => p.WebSite)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.FounderAddress)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.DescriptionCompany)
               .NotEmpty()
               .NotNull();

        }

    }
}
