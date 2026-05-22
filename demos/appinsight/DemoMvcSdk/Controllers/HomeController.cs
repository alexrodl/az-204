using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoMvcSdk.Models;

namespace DemoMvcSdk.Controllers;

public class HomeController : Controller
{
   private readonly ILogger<HomeController> _logger;

    private static Random _random = new Random();

    private static List<TodoDto> _allTodos = [
        new TodoDto
            {
                Id = Guid.NewGuid(),
                Title = "Example",
                DueAt = DateTimeOffset.UtcNow
            }
    ];
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Home page visited");

        return View();
    }

    [HttpGet(Name = "GetTodos")]
    public async Task<IActionResult> GetAll()
    {
        var result = _allTodos.ToArray();

        if (_random.Next(0, 10) < 1)
        {
            throw new Exception("Random failure!");
        }

        await Task.Delay(_random.Next(100, 300));

        return Ok(result);
    }
}
