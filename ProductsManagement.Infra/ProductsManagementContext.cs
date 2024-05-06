using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductsManagement.Core;

namespace ProductsManagement.Infra;

public sealed class ProductsManagementContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public ProductsManagementContext(DbContextOptions<ProductsManagementContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

    public class Factory : IDesignTimeDbContextFactory<ProductsManagementContext>
    {
        public ProductsManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsManagementContext>();

            optionsBuilder.UseSqlServer("Server=tcp:stores-management.database.windows.net,1433;Initial Catalog=Stores;Persist Security Info=False;User ID=jack;Password=P4ssw0rd!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ProductsManagementContext(optionsBuilder.Options);
        }
    }
}