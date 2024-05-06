namespace ProductsManagement.Application.GetAllProducts;
public sealed record GetProductQueryResponse(Guid Id, string Name, string Description, decimal Price)
{
}