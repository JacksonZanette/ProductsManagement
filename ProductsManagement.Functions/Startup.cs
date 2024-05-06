using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using ProductsManagement.Infra.Extensions;

[assembly: FunctionsStartup(typeof(ProductsManagement.Functions.Startup))]

namespace ProductsManagement.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
        => builder.Services.AddInfrastructure();
}