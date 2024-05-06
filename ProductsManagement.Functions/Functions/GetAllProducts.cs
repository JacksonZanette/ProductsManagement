using AcertoChallenge.Products.Application.ListProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProductsManagement
{
    public class GetAllProducts
    {
        private readonly IMediator _mediator;

        public GetAllProducts(IMediator mediator)
            => _mediator = mediator;

        [FunctionName("GetAllProducts")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to get all products.");

            return new OkObjectResult(await _mediator.Send(new GetAllProductsQuery()));
        }
    }
}