using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ExaminationFindingService;

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
    }
}
