using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Doctor;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private ISDoctor doctor;
        public DoctorController(ISDoctor _doctor)
        {
            this.doctor = _doctor;
        }

        [HttpGet]
        public async Task<IActionResult> getAllDoctors()
        {
            var response = await doctor.GetDoctors();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
