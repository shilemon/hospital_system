using HospitalSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HospitalSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _api;
        private readonly string _baseUrl;

        public HomeController(ApiService api, IConfiguration config)
        {
            _api = api;
            _baseUrl = config["ApiSettings:BaseUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        // Patients
        public async Task<IActionResult> Patients()
        {
            var data = await _api.GetAsync($"{_baseUrl}/api/patient");
            return Content(data, "application/json");
        }

        // Doctors
        public async Task<IActionResult> Doctors()
        {
            var data = await _api.GetAsync($"{_baseUrl}/api/doctor");
            return Content(data, "application/json");
        }

        // Appointments
        public async Task<IActionResult> Appointments()
        {
            var data = await _api.GetAsync($"{_baseUrl}/api/appointment");
            return Content(data, "application/json");
        }

        // Bills
        public async Task<IActionResult> Bills()
        {
            var data = await _api.GetAsync($"{_baseUrl}/api/bill");
            return Content(data, "application/json");
        }
    }
}
