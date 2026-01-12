using System;
using System.Collections.Generic;
using System.Text;

using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface IPatientService
    {
        bool Create(Patient patient);
        List<Patient> Get();
        Patient Get(int id);
        bool Update(Patient patient);
        bool Delete(int id);
    }
}
