using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Doctor;
using ServiceLayer.Doctor.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DoctorController : Controller
    {
        private ISDoctor doctor;
        public DoctorController(ISDoctor _doctor)
        {
            this.doctor = _doctor;
        }

        [HttpGet]
        //[Authorize(Roles = "Doctor")]
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDoctor(Guid id)
        {
            var response = await doctor.GetDoctor(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorDTO_0 DTO)
        {
            if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var createdBy))
            {
                return Unauthorized();
            }

            var response = await doctor.addDoctor(DTO, createdBy);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Doctor")]
        public async Task<IActionResult> GetAllSpecialization()
        {

            var response = await doctor.GetAllSpecialization();
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
