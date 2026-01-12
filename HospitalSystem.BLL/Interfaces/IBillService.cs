using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface IBillService
    {
        bool GenerateBill(int appointmentId);
        List<Bill> GetAll();
        Bill Get(int id);
    }
}
