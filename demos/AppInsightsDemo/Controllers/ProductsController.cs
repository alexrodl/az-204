using AppInsightsDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppInsightsDemo.Controllers
{
    [Route("products")]
    public class ProductsController     : Controller
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProductsAsync();

            return View(products);
        }
    }
}
