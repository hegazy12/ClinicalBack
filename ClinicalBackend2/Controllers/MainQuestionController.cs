using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.SheetService.MainQuestionService;
using ServiceLayer.SheetService.MainQuestionService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class MainQuestionController : ControllerBase
    {
        IMainQuestionService service { get; set; }
        public MainQuestionController(IMainQuestionService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> save(MainQuestionDTO DTO)
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

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var x = await service.GetAll();

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
    }
}
