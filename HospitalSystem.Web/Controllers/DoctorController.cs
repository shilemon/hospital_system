using HospitalSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalSystem.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HttpClient _client;

        public DoctorController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44384/");
        }

        // ======================
        // PERFORMANCE DASHBOARD
        // ======================
        public async Task<IActionResult> Index()
        {
            var json = await _client.GetStringAsync("api/doctor/performance");

            var doctors = JsonSerializer.Deserialize<List<DoctorPerformanceVM>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(doctors);
        }

        // ======================
        // CREATE (GET)
        // ======================
        public IActionResult Create()
        {
            return View();
        }

        // ======================
        // CREATE (POST)
        // ======================
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var payload = new
            {
                fullName = model.FullName,
                specialty = model.Specialty,
                isAvailable = model.IsAvailable
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/doctor", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create doctor");
                return View(model);
            }

            // 🔥 Redirect back to performance dashboard
            return RedirectToAction(nameof(Index));
        }
    }
}
