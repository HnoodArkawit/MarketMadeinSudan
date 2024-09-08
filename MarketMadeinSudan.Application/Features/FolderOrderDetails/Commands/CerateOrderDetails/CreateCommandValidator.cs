using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderOrderDetails.Commands.CreateOrderDetails
{
    public class CreateCommandValidator : AbstractValidator<CreateOrderDetailsCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.firstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.lastName)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.UserName)
               .NotEmpty()
               .NotNull();

            RuleFor(p => p.Email)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.Country)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.Address)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Zip)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.DatePay)
   .NotEmpty()
   .NotNull();

        }

    }
}
