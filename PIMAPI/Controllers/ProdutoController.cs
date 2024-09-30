using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _productionService;

        public ProdutoController(IProdutoService productionService)
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
        public async Task<IActionResult> RegisterProduct(ProdutoRequest request)
        {
            var result = await _productionService.RegisterProducts(request);
            return Ok(result);
        }
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(string id, ProdutoRequest request)
        {
            var result = await _productionService.UpdateProducts(id, request);
            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productionService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
