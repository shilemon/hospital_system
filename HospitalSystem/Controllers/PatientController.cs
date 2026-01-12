using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        IPatientService service;

        public PatientController(IPatientService service)
        {
            this.service = service;
        }

        // GET: api/patient
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Get());
        }

        // GET: api/patient/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST: api/patient
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            var result = service.Create(patient);
            if (result) return Ok("Patient created successfully");
            return BadRequest("Patient creation failed");
        }

        // PUT: api/patient
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id)
                return BadRequest("ID mismatch");

            var result = service.Update(patient);
            if (result)
                return Ok("Patient updated successfully");

            return BadRequest("Update failed");
        }


        // DELETE: api/patient/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result) return Ok("Patient deleted successfully");
            return BadRequest("Delete failed");
        }
    }
}
