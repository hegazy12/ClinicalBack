using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Prescription;
using ServiceLayer.Prescription.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class PrescriptionController : Controller
    {
        private ISPrescription SPrescription;
        public PrescriptionController(ISPrescription _SPrescription)
        {
            SPrescription = _SPrescription;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionDTO prescription)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await SPrescription.CreatePrescriptionAsync(prescription, userid);

            if (x.Success)
            {
                return Ok(x);
            }
            else {
                return BadRequest(x);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetbyappotmintID(Guid id)
        {
            if (true)
            {
                var x = await SPrescription.GetByAppoinmentAsync(id);
                return Ok(x);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
