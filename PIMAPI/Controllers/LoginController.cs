using Microsoft.AspNetCore.Mvc;
using PIMAPI.Application.Abstraction.Domain.Response;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Services;

namespace PIMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
       
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]

        public async Task<IActionResult> Authentication(LoginResponse loginResponse)
        {
            var userAuth = _loginService.GetLogin(loginResponse);

            if(userAuth != null)
            {
                return Ok(new { UserAuth = userAuth.Result });
            }
            else
            {
                return BadRequest();
            }


           
        }
    }
}
