using Common.Models.Inputs.Products;
using FluentValidation;

namespace TechnaminDemo.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductInput>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Price)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Available)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Description)
               .Cascade(CascadeMode.Stop)
               .MaximumLength(1000);
        }
    }
}
