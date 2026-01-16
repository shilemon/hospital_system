using HospitalSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HospitalSystem.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HttpClient _client;

        public AppointmentController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44384/");
        }

        // ======================
        // LIST
        // ======================
        public async Task<IActionResult> Index()
        {
            var json = await _client.GetStringAsync("api/appointment");

            var appointments = JsonSerializer.Deserialize<List<AppointmentVM>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(appointments);
        }

        // ======================
        // CREATE (GET)
        // ======================
        public async Task<IActionResult> Create()
        {
            var model = new CreateAppointmentVM();
            await LoadDropdowns(model);
            return View(model);
        }

        // ======================
        // CREATE (POST)
        // ======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentVM model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);
                return View(model);
            }

            var payload = new
            {
                patientId = model.PatientId,
                doctorId = model.DoctorId,
                appointmentDate = model.AppointmentDate
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/appointment", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create appointment");
                await LoadDropdowns(model);
                return View(model);
            }

            // ✅ IMPORTANT: explicit redirect
            return RedirectToAction("Index", "Appointment");
        }

        // ======================
        // HELPER METHOD
        // ======================
        private async Task LoadDropdowns(CreateAppointmentVM model)
        {
            // -------- Patients --------
            var patientsJson = await _client.GetStringAsync("api/patient");
            var patients = JsonSerializer.Deserialize<List<PatientVM>>(
                patientsJson,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            model.Patients = new List<SelectListItem>();
            foreach (var p in patients)
            {
                model.Patients.Add(new SelectListItem
                {
                    Text = p.FullName,
                    Value = p.Id.ToString()
                });
            }

            // -------- Doctors --------
            var doctorsJson = await _client.GetStringAsync("api/doctor");
            var doctors = JsonSerializer.Deserialize<List<DoctorVM>>(
                doctorsJson,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            model.Doctors = new List<SelectListItem>();
            foreach (var d in doctors)
            {
                model.Doctors.Add(new SelectListItem
                {
                    Text = d.FullName,
                    Value = d.Id.ToString()
                });
            }
        }
    }
}
