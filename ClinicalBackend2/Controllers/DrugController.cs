
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Drug.Interfaces; 
using ServiceLayer.Drug.Dtos;


namespace ClinicalBackend2.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    //[Authorize(Roles = "Admin,User")]
    public class DrugController : ControllerBase
    {
        private readonly IDrugService _service;
        public DrugController(IDrugService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DrugDto>>> GetDrugs(string SearchTerm)
        {
            var drugs= await _service.GetDrugsAsync(SearchTerm);
            return drugs;

        }
    }
}
