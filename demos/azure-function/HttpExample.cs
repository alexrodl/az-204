using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace My.Function;

public class HttpExample
{
    private readonly ILogger<HttpExample> _logger;

    public HttpExample(ILogger<HttpExample> logger)
    {
        _logger = logger;
    }

    // [Function("HttpExample")]
    // public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    // {
    //     _logger.LogInformation("C# HTTP trigger function processed a request.");
    //       string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

    // var data = JsonSerializer.Deserialize<MyRequest>(requestBody);

    // return new OkObjectResult($"Hello {data?.Name}");
    //     return new OkObjectResult("Welcome to Azure Functions!");
    // }

    [Function("HttpExample")]
    public async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var json = await new StreamReader(req.Body).ReadToEndAsync();
        var document = JsonDocument.Parse(json);

        string name = document.RootElement.GetProperty("name").GetString();
        _logger.LogInformation($"Hello {name}");
        return new OkObjectResult($"Hello {name}");
    }
}