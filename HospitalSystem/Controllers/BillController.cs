using HospitalSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        IBillService service;

        public BillController(IBillService service)
        {
            this.service = service;
        }

        [HttpPost("{appointmentId}")]
        public IActionResult Generate(int appointmentId)
        {
            var result = service.GenerateBill(appointmentId);
            if (!result)
                return BadRequest("Bill generation failed");

            return Ok("Bill generated successfully");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bill = service.Get(id);
            if (bill == null) return NotFound();
            return Ok(bill);
        }
    }
}
