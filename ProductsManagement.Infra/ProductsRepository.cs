using Microsoft.EntityFrameworkCore;
using ProductsManagement.Core;

namespace ProductsManagement.Infra;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductsManagementContext _context;

    public ProductsRepository(ProductsManagementContext context) => _context = context;

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Products.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Products.ToArrayAsync(cancellationToken);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await GetAsync(id, cancellationToken);

        if (product is null)
            return;

        _context.Products.Remove(product);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}