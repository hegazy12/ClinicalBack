using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Patient;
using ServiceLayer.vitalSignMaster.Interfaces;
using ServiceLayer.VitalSignMaster.Dtos;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    //[Authorize(Roles = "Doctor")]
    [ApiController]
    public class VitalSignController : ControllerBase
    {
        private IVitalSignMasterService VitalSignMasterService;
        public VitalSignController(IVitalSignMasterService _VitalSignMasterService)
        {
            VitalSignMasterService = _VitalSignMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> searchByTearm(string SearchTerm)
        {
           var x = await VitalSignMasterService.GetSearchTearmAsync(SearchTerm);
            if (x.Success)
            {
                return Ok(x);
            }
            else {
                return BadRequest(x);
            }
        }

        [HttpPost]
        public async Task<IActionResult> save(savaVitalSigDto savaVitalSigDto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await VitalSignMasterService.save(savaVitalSigDto, userid);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet("{appoitmentID:guid}")]
        public async Task<IActionResult> GetByAppointmentId(Guid appoitmentID)
        {
            var x = await VitalSignMasterService.GetByAppointmentIdAsync(appoitmentID);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpDelete("{VitalSignId:guid}")]
        public async Task<IActionResult> Delete(Guid VitalSignId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);

            var x = await VitalSignMasterService.Delete(VitalSignId,userid);
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
