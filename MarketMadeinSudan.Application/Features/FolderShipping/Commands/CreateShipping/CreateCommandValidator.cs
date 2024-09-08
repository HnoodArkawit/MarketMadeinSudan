using FluentValidation;

namespace MarketMadeinSudan.Application.Features.FolderShipping.Commands.CreateShipping
{
    public class CreateCommandValidator : AbstractValidator<CreateShippingCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.NameCompany)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.firstNameCustoer)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.NameShipping)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.ProductName)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.PhoneCompany)
               .NotEmpty()
               .NotNull();

            RuleFor(p => p.PhoneCustomer)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.PhoneShipping)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.EmailCompany)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.Count)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.EmailShipping)
   .NotEmpty()
   .NotNull();

            RuleFor(p => p.AddressCompany)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.AddressCustoer)
               .NotEmpty()
               .NotNull();
            RuleFor(p => p.AddressShipping)
    .NotEmpty()
    .NotNull();

            RuleFor(p => p.CountryCustoer)
               .NotEmpty()
               .NotNull();

        }
    }
}
