using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace Az204.KeyVaultLab.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IFeatureManager _featureManager;

    public HomeController(
        IConfiguration configuration,
        IFeatureManager featureManager)
    {
        _configuration = configuration;
        _featureManager = featureManager;
    }

    public async Task<IActionResult> Index()
    {
        // Configurations
        ViewBag.WebTitle = _configuration["App:WebTitle"];

        ViewBag.Theme = _configuration["App:Theme"];

        ViewBag.Message = _configuration["App:WelcomeMessage"];

        ViewBag.ApiKey = _configuration["ApiKey"];

        ViewBag.SqlPassword = _configuration["SqlPassword"];

        ViewBag.StorageConnection = _configuration["StorageConnection"];

        // Feature Flags
        ViewBag.BetaEnabled = await _featureManager.IsEnabledAsync("BetaPage");
        
        return View();
    }
}