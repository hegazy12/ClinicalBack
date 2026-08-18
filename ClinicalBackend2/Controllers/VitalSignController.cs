using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Patient;
using ServiceLayer.vitalSignMaster.Interfaces;

namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Doctor")]
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
    }
}
