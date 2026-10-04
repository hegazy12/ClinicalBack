using Microsoft.AspNetCore.Mvc;
using SericeLayer.Account.Rgistration;
using SericeLayer.Account.Login;
using SericeLayer.Account.Login.DTO;
using SericeLayer.Account.Rgistration.DTO;


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

            // Only an authenticated admin may choose roles; anonymous sign-ups always get the default role.
            if (!User.IsInRole("Admin"))
            {
                request.Roles.Clear();
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
                return BadRequest(result);
            }
            
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _registrationService.GetList();
            if (result == null)
            {
                return BadRequest("Failed to retrieve users.");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _registrationService.GetRoles();
            if (result == null)
            {
                return BadRequest("Failed to retrieve roles.");
            }
            return Ok(result);
        }
    }
}