using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.SheetService.QuestionService;
using ServiceLayer.SheetService.QuestionService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin,User,BaseUser")]
    public class QuestionController : ControllerBase
    {
        IQuestionService service { get; set; }
        public QuestionController(IQuestionService _service) 
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> save(QuestionDTO DTO)
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> getbysheetid(Guid id)
        {
            var x = await service.GetbySheetId(id);

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
        public async Task<IActionResult> GetbyDepndOnQuestionID(Guid id)
        {
            var x = await service.GetbyDepndOnQuestionID(id);

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
