using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ExaminationFindingService;
using ServiceLayer.ExaminationFindingService.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class ExaminationFindingController : ControllerBase
    {
        private IExaminationFindingService Service;
        public ExaminationFindingController(IExaminationFindingService _Service)
        {
            this.Service = _Service;
        }


        [HttpPost]
        public async Task<IActionResult> Add(ExaminationFindingDTO DTO )
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await Service.Add(DTO, userid);
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
        public async Task<IActionResult> Delete(Guid ID)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var x = await Service.Delete(ID, userid);
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x = await Service.GetAll();
            if (x.Success)
            {
                return Ok(x);
            }
            else
            {
                return BadRequest(x);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchTearm(string SearchTerm)
        {
            var x = await Service.GetSearchTearmAsync(SearchTerm);
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
