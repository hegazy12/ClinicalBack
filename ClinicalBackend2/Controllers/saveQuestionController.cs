using Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.SheetService.saveQuestionService;
using ServiceLayer.SheetService.saveQuestionService.saveQtionDTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin,User,BaseUser")]
    public class saveQuestionController : ControllerBase
    {
        IsaveQuestionService saveQuestionService;
        public saveQuestionController(IsaveQuestionService _saveQuestionService)
        {
            saveQuestionService = _saveQuestionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddList(IEnumerable<saveQuestionDTO> DTOs)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await saveQuestionService.AddList(DTOs , userid);

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
