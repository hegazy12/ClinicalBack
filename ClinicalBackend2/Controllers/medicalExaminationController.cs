using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Drug.Interfaces;
using ServiceLayer.SmedicalExaminations;
using ServiceLayer.SmedicalExaminations.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Authorize(Roles = "Admin,User,BaseUser")]
    public class medicalExaminationController : Controller
    {
        private readonly ImedicalExaminations service;

        public medicalExaminationController(ImedicalExaminations _service)
        {
            service = _service;
        }


        [HttpGet]
        public async Task<IActionResult> GetGetDrugs(string SearchTerm)
        {
           
            var x = await service.GetbySearchTerm(SearchTerm);
            if (x.Success) {
                return Ok(x); 
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByAppointmentId(Guid id)
        {

            var x = await service.GetByAppointmentIdAsync(id);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(saveExaminationDTO save)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await service.saveExaminationAsync(save,userid);
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
