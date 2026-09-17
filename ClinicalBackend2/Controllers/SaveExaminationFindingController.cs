using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ExaminationFindingService.DTO;
using ServiceLayer.ExaminationFindingService.Save;
using ServiceLayer.ExaminationFindingService.Save.DTO;
using ServiceLayer.SheetService.QuestionService;
using ServiceLayer.SheetService.saveQuestionService;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class SaveExaminationFindingController : ControllerBase
    {
        IsaveExaminationFinding service { get; set; }
        public SaveExaminationFindingController(IsaveExaminationFinding _service)
        {
            service = _service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(saveExaminationFindingDTO DTO)
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


        [HttpDelete("{ID:guid}")]
        public async Task<IActionResult> Delete(Guid ID)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await service.Delete(ID, userid);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet("{appointmentid:guid}")]
        public async Task<IActionResult> GetByAppointmentId(Guid appointmentid)
        {
            var x = await service.GetByAppointmentIdAsync(appointmentid);

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
