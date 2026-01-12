using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Interfaces
{
    public interface INotificationService
    {
        void Send(int patientId, string message);
        List<Notification> GetAll();
    }
}
