using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ServiceLayer.Patient;
using ServiceLayer.Patient.DTO;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,User")]
    public class PatientController : ControllerBase
    {
       
        private IPatient patient;
        public PatientController(IPatient _patient)
        {
            patient = _patient;
        }

        [HttpPost]
        public IActionResult Create(PatientDTO_0 patientDTO_0)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            patient.CreatPatient(patientDTO_0,userid);
            return Ok("Patient endpoint working");
        }
    }
}
