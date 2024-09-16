using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Sales")]
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var result = await _salesService.GetSales();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSale(SaleRequest request)
        {
            var result = await _salesService.RegisterSale(request);
            return Ok(result);
        }

    }
}
