using Microsoft.AspNetCore.Mvc;
using SericeLayer.Account.Rgistration;
using SericeLayer.Account.Rgistration.DTO;
using SericeLayer.Account.Login.DTO;
using SericeLayer.Account.Login;


namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRgistration _registrationService;
        private readonly ILogin _loginService;

        public AccountController(IRgistration registrationService, ILogin loginService)
        {
            _registrationService = registrationService;
            _loginService = loginService;
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
            
            return Ok(result);
        }

         [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _loginService.LoginAsync(request);

            if (result == null)
            {
                return BadRequest(result.Error);
            }
            
            return Ok(result);
        }
    }
}