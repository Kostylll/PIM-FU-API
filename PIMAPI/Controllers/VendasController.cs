using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Sales")]
    public class VendasController : Controller
    {
        private readonly IVendasService _salesService;

        public VendasController(IVendasService salesService)
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
        public async Task<IActionResult> RegisterSale(VendasRequest request)
        {
            var result = await _salesService.RegisterSale(request);
            return Ok(result);
        }

    }
}
