using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ProductsManagement.Application.CreateProduct;
public sealed record CreateProductCommand(string? Name, string? Description, decimal? Price) : IRequest<Result<Guid>>
{
    public ValidationResult Validate()
        => new Validator().Validate(this);
    class Validator : AbstractValidator<CreateProductCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(e => e.Price)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}