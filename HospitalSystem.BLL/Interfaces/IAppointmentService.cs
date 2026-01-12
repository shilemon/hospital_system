using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentDto> Get();
        Appointment Create(Appointment appointment);
        Appointment Get(int id);
    }
}
