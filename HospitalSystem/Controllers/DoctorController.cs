using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        IDoctorService service;

        public DoctorController(IDoctorService service)
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

        [HttpGet("available")]
        public IActionResult GetAvailableDoctors()
        {
            return Ok(service.GetAvailableDoctors());
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            var result = service.Create(doctor);
            if (result) return Ok("Doctor created successfully");
            return BadRequest("Doctor creation failed");
        }

        [HttpPut]
        public IActionResult Update(Doctor doctor)
        {
            var result = service.Update(doctor);
            if (result) return Ok("Doctor updated successfully");
            return BadRequest("Doctor update failed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result) return Ok("Doctor deleted successfully");
            return BadRequest("Doctor delete failed");
        }
    }
}
