using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.cheifComplaneService;
using ServiceLayer.cheifComplaneService.DTO;
using ServiceLayer.Prescription;
using ServiceLayer.SheetService.QuestionService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class cheifComplaneController : ControllerBase
    {
        public IcheifComplaneService cheifComplaneService;
        public cheifComplaneController(IcheifComplaneService _cheifComplaneService)
        {
            cheifComplaneService = _cheifComplaneService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(chiefComplaintDTO DTO)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await cheifComplaneService.save(DTO, userid);

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
        public async Task<IActionResult> Delete(Guid Id)
        {

            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await cheifComplaneService.Delete(Id , userid);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet("{ID:guid}")]
        public async Task<IActionResult> GetbyAppointment(Guid Id)
        {
            var x = await cheifComplaneService.GetbyAppointmentId(Id);
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
