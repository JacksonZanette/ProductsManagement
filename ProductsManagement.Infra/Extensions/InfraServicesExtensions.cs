using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsManagement.Core;
using System.Reflection;

namespace ProductsManagement.Infra.Extensions;

public static class InfraServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var commandsHandlersAssembly = Assembly.Load("ProductsManagement.Application");

        return services
            .AddDatabase()
            .AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(commandsHandlersAssembly));
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MyConnection");

        return services
            .AddDbContext<ProductsManagementContext>(options => options.UseSqlServer(connectionString!))
            .AddScoped<IProductsRepository, ProductsRepository>();
    }
}