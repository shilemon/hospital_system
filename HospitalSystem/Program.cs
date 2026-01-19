using HospitalSystem.BLL.Interfaces;
using HospitalSystem.BLL.Services;
using HospitalSystem.DAL.Context;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ================================
// ADD SERVICES
// ================================

// Controllers
builder.Services.AddControllers();

// 🔥 SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ================================
// DATABASE
// ================================
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ================================
// REPOSITORY
// ================================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// ================================
// BUSINESS SERVICES
// ================================
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();

// ================================
// MIDDLEWARE PIPELINE
// ================================
if (app.Environment.IsDevelopment())
{
    // 🔥 ENABLE SWAGGER UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalSystem API v1");
        c.RoutePrefix = "swagger"; // https://localhost:xxxx/swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
