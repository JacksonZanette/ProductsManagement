using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductsManagement.Application.CreateProduct;
using System.IO;
using System.Threading.Tasks;

namespace ProductsManagement.Functions.Functions;

public class CreateProduct
{
    private readonly IMediator _mediator;

    public CreateProduct(IMediator mediator)
        => _mediator = mediator;

    [FunctionName("CreateProduct")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "products")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request to create a product.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<CreateProductCommand>(requestBody);

        var result = await _mediator.Send(data);

        return result.IsSuccess
            ? new CreatedResult($"products/{result.Value}", result.Value)
            : new BadRequestObjectResult(result.Errors);
    }
}