using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderCart.Commands.CreateCart
{
    public class CreateCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Count)
    .NotEmpty()
    .NotNull();
        }

    }
}
