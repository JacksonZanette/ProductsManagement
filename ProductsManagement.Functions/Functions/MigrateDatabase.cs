using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsManagement.Infra;
using System.Threading.Tasks;

namespace ProductsManagement.Functions.Functions
{
    public class MigrateDatabase
    {
        private readonly ProductsManagementContext _context;

        public MigrateDatabase(ProductsManagementContext context) => _context = context;

        [FunctionName("MigrateDatabase")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "migrate-database")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function to migrate database.");

            await _context.Database.MigrateAsync();

            return new OkObjectResult("Migration executed!");
        }
    }
}