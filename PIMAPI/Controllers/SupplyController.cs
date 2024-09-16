using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Supply")]
    public class SupplyController : Controller
    {
        private readonly ISupplyService _supplyService;

        public SupplyController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupply()
        {
            var result = await _supplyService.GetSupply();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> RegisterSupply(SupplyRequest request)
        {
            var result = await _supplyService.RegisterSupply(request);
            return Ok(result);
        }
    }
}
