using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        IAppointmentService service;

        public AppointmentController(IAppointmentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            var result = service.Create(appointment);

            if (result == null)
                return BadRequest("Appointment creation failed");

            if (result.Status == "Rejected")
            {
                return Ok(new
                {
                    message = "Appointment rejected - Doctor is not available",
                    appointment = result
                });
            }

            return Ok(new
            {
                message = "Appointment confirmed successfully",
                appointment = result
            });
        }
    }
}