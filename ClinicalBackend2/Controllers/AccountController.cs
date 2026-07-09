using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using SericeLayer.Account.Rgistration;
using SericeLayer.Account.Rgistration.DTO;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRgistration _registrationService;

        public AccountController(IRgistration registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RgistrationDTO_0 request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _registrationService.RegisterAsync(request);

            if (result == null)
            {
                return BadRequest("Registration failed.");
            }

            return Ok("Registration successful.");
        }
    }
}