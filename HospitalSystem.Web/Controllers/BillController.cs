using HospitalSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HospitalSystem.Web.Controllers
{
    public class BillController : Controller
    {
        private readonly HttpClient _client;

        public BillController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44384/");
        }

        // ======================
        // LIST
        // ======================
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("BILL INDEX HIT");

            var json = await _client.GetStringAsync("api/bill");

            Console.WriteLine(json); // 🔥 IMPORTANT

            var bills = JsonSerializer.Deserialize<List<BillVM>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(bills);
        }

        public async Task<IActionResult> Invoice(int id)
        {
            var json = await _client.GetStringAsync($"api/bill/{id}");

            var bill = JsonSerializer.Deserialize<BillVM>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(bill); // ✅ SINGLE BillVM
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
        public async Task<IActionResult> Create(CreateBillVM model)
        {
            Console.WriteLine("POST Create Bill HIT");
            Console.WriteLine($"AppointmentId={model.AppointmentId}, Amount={model.Amount}");

            var payload = new
            {
                appointmentId = model.AppointmentId,
                amount = model.Amount,
                status = model.Status
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/bill", content);

            return RedirectToAction("Index");
        }




    }
}
