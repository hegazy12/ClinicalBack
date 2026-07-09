using ServiceLayer.Drug.Interfaces;
using ServiceLayer.Drug.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalBackend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugImportController : ControllerBase
    {
        private readonly IDrugImportService _service;

        public DrugImportController(IDrugImportService service)
        {
            _service = service;
        }

        [HttpPost("import-local")]
        public async Task<IActionResult> ImportFromLocal([FromBody] ImportRequest request)
        {
            var inserted = await _service.ImportFromJsonAsync(request.Path);
            return Ok(new { inserted });
        }
    }
}
