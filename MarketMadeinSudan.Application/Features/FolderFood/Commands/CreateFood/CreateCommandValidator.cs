using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderFood.Commands.CreateFood
{
    public class CreateCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.NameCompany)
.NotEmpty()
.NotNull();

            RuleFor(p => p.FoodName)
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
