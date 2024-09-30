using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/Supply")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedoresService _supplyService;

        public FornecedorController(IFornecedoresService supplyService)
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

        public async Task<IActionResult> RegisterSupply(FornecedoresRequest request)
        {
            var result = await _supplyService.RegisterSupply(request);
            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSupply(string id , FornecedoresRequest request)
        {
            var result = await _supplyService.UpdateSupply(id, request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSupply(string id)
        {
            var result = await _supplyService.DeleteSupply(id);
            return Ok(result);
        }
    }
}
