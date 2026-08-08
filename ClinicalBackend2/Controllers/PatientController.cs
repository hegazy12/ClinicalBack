using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ServiceLayer.Patient;
using ServiceLayer.Patient.DTO;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class PatientController : ControllerBase
    {
       
        private IPatient patient;
        public PatientController(IPatient _patient)
        {
            patient = _patient;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientDTO_0 patientDTO_0)
        {
            try
            {
                    var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Guid userid = Guid.Parse(userIdStr);
                    var response = await patient.CreatPatient(patientDTO_0, userid);
                    if(response == null)
                    {
                        return BadRequest("Failed to create patient.");
                    }
                    return Ok(response);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet]
        public async Task<IActionResult> GetPatientsNew()
        {
            var response = await patient.GetPatientsNew();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var response = await patient.GetPatient(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInfoPatient(Guid id)
        {
            var response = await patient.GetAllInfo(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
