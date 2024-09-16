using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductController : Controller
    {
        private readonly IProductionService _productionService;

        public ProductController(IProductionService productionService)
        {
            _productionService = productionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProucts()
        {
            var result = await _productionService.GetProducts();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterProduct(ProductionRequest request)
        {
            var result = await _productionService.RegisterProducts(request);
            return Ok(result);
        }
    }
}
