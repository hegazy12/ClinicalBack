using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Appointment;
using ServiceLayer.Appointment.DTO;
using System.Security.Claims;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,User,BaseUser")]
    public class AppointmentController : Controller
    {
        private IAppointmentService appointmentService;
        public AppointmentController(IAppointmentService _IAppointmentService){
            this.appointmentService = _IAppointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> createAppointment(AppointmentDTO_0 appointmentDTO)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid userid = Guid.Parse(userIdStr);
            var appointment = await appointmentService.Creat(appointmentDTO, userid);
            if (appointment.Success)
            {
                return Ok(appointment);
            }
            else
            {
                return BadRequest(appointment);
            }
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> getPatientAppointments(Guid Id) { 
            var appointments = await  appointmentService.GetByPatient(Id);
            
            if (appointments.Success)
            {
                return Ok(appointments);
            }
            else
            {
                return BadRequest(appointments);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> getDoctorAppointments(Guid Id)
        {
            var appointments = await appointmentService.GetByDoctor(Id);

            if (appointments.Success)
            {
                return Ok(appointments);
            }
            else
            {
                return BadRequest(appointments);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAllInfo(Guid id)
        {
            var appointments = await appointmentService.GetAllInfo(id);

            if (appointments.Success)
            {
                return Ok(appointments);
            }
            else
            {
                return BadRequest(appointments);
            }
        }

    }
}
