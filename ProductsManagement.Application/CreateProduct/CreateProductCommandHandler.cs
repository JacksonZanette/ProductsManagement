using FluentResults;
using MediatR;
using ProductsManagement.Core;

namespace ProductsManagement.Application.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductCommandHandler(IProductsRepository productsRepository)
        => _productsRepository = productsRepository;

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validation = request.Validate();

        if (!validation.IsValid)
            return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

        var product = new Product(request.Name!, request.Description!, request.Price!.Value);

        await _productsRepository.AddAsync(product, cancellationToken);

        return Result.Ok(product.Id);
    }
}