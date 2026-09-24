using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.saveServiceService;
using ServiceLayer.saveServiceService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class saveServiceController : ControllerBase
    {
        IsaveServiceService saveServiceService;
        public saveServiceController(IsaveServiceService _saveServiceService)
        {
            saveServiceService = _saveServiceService;
        }

        [HttpPost]
        public async Task<IActionResult> save(saveServiceDTO DTO)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await saveServiceService.Add(DTO, userid);

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
        public async Task<IActionResult> GetByAppointmentID(Guid appointmentid)
        {
            var x = await saveServiceService.GetByAppointmentID(appointmentid);

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
            var x = await saveServiceService.Delete(id, userid);

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
