using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DiagnosService;
using ServiceLayer.DiagnosService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class DiagnosController : ControllerBase
    {
        private readonly IDiagnosService service;

        public DiagnosController(IDiagnosService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiagnos(string SearchTerm)
        {
            var x = await service.GetbySearchTerm(SearchTerm);
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
        public async Task<IActionResult> AddDiagnos(CreateDiagnosDTO dTO)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await service.Add(dTO, userid);
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
        public async Task<IActionResult> GetDiagnosByAppoitmentID(Guid appoitmentID)
        {
            var x = await service.GetbyAppoitmentID(appoitmentID);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpDelete("{diagnosID:guid}")]
        public async Task<IActionResult> Delete(Guid diagnosID)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await service.Delete(diagnosID, userid);
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
