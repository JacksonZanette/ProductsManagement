using AcertoChallenge.Products.Application.ListProducts;
using MediatR;
using ProductsManagement.Core;

namespace ProductsManagement.Application.GetAllProducts;

internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductQueryResponse>>
{
    private readonly IProductsRepository _productsRepository;

    public GetAllProductsQueryHandler(IProductsRepository productsRepository)
        => _productsRepository = productsRepository;

    public async Task<IEnumerable<GetProductQueryResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync(cancellationToken);

        return products.Select(product => new GetProductQueryResponse
        (
            product.Id,
            product.Name,
            product.Description,
            product.Price
        ));
    }
}