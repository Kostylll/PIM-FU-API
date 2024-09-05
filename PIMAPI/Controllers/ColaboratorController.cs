using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Request;
using PIMAPI.Application.Abstraction.Domain.Response;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Services;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboratorController : Controller
    {
        private readonly IColaboratorService _colaboratorService;


        public ColaboratorController (IColaboratorService colaboratorService)
        {
            _colaboratorService = colaboratorService;
        }


        [HttpGet]

        public async Task<IActionResult> GetColaborator()
        {
            var result = await _colaboratorService.GetColaborator();
            return Ok(result);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetColaboratorById(string id)
        {
            var result = await _colaboratorService.GetColaboratorById(id);
            return Ok(result);
        }


        [HttpPost]

        public async Task<IActionResult> RegisterColaborator(ColaboratorRequest request)
        {
            var result =  await _colaboratorService.RegisterColaborator(request);

            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteColaborator(string id)
        {
            var result = await _colaboratorService.DeleteColaborator(id);
            return Ok(result);
        }
    }
}
