using HospitalSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace HospitalSystem.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly string apiUrl = "https://localhost:44384/api/patient";

        // GET: /Patient
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(apiUrl);

            var patients = JsonSerializer.Deserialize<List<PatientVM>>(
                response,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patients);
        }

        // GET: /Patient/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Patient/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var client = new HttpClient();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to create patient");
            return View(model);
        }
        // GET: /Patient/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync($"{apiUrl}/{id}");

            var patient = JsonSerializer.Deserialize<EditPatientVM>(
                response,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPatientVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var client = new HttpClient();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(
                $"https://localhost:44384/api/patient/{model.Id}",
                content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Update failed");
                return View(model);
            }

            return RedirectToAction("Index");
        }



        // GET: /Patient/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using var client = new HttpClient();
            await client.DeleteAsync($"{apiUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
