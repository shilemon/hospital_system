using System;
using System.Collections.Generic;
using System.Text;
using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Services
{
    public class PatientService : IPatientService
    {
        IRepository<Patient> repo;

        public PatientService(IRepository<Patient> repo)
        {
            this.repo = repo;
        }

        public bool Create(Patient patient)
        {
            return repo.Create(patient);
        }

        public List<Patient> Get()
        {
            return repo.Get();
        }

        public Patient Get(int id)
        {
            return repo.Get(id);
        }

        public bool Update(Patient patient)
        {
            var existing = repo.Get(patient.Id);
            if (existing == null) return false;

            existing.FullName = patient.FullName;
            existing.Email = patient.Email;
            existing.DateOfBirth = patient.DateOfBirth;

            return repo.Update(existing);
        }


        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
