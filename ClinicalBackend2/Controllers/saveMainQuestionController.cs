using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.SheetService.saveMainQuestionService;
using ServiceLayer.SheetService.saveMainQuestionService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class saveMainQuestionController : ControllerBase
    {
        IsaveMainQuestionService saveMainQuestionService;
        public saveMainQuestionController(IsaveMainQuestionService _saveMainQuestionService)
        {
            saveMainQuestionService = _saveMainQuestionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddList(IEnumerable<saveMainQuestionDTO> DTOs)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await saveMainQuestionService.AddList(DTOs, userid);

            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet("{patientid:guid}")]
        public async Task<IActionResult> GetByPatientID(Guid patientid)
        {
            var x = await saveMainQuestionService.GetByPatientID(patientid);

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
            var x = await saveMainQuestionService.Delete(id, userid);

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
