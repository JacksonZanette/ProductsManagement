using MediatR;
using ProductsManagement.Application.GetAllProducts;

namespace AcertoChallenge.Products.Application.ListProducts;
public sealed record GetAllProductsQuery() : IRequest<IEnumerable<GetProductQueryResponse>>
{
}