using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServiceOfServices;
using ServiceLayer.ServiceOfServices.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class ServiceController : ControllerBase
    {
        IServiceOfServices service { get; set; }
        public ServiceController(IServiceOfServices _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> save(ServiceDTO DTO)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);

            var x = await service.Add(DTO, userid);

            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet]
        public async Task<IActionResult> search([FromQuery] string? name)
        {
            var x = await service.Search(name);

            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var x = await service.GetById(id);

            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return NotFound(x);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);

            var x = await service.Delete(id, userid);

            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }
    }
}
