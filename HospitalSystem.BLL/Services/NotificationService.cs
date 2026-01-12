using HospitalSystem.BLL.Interfaces;
using HospitalSystem.DAL.Interfaces;
using HospitalSystem.DTO.Models;
using System.Collections.Generic;

namespace HospitalSystem.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notification> notificationRepo;

        public NotificationService(IRepository<Notification> notificationRepo)
        {
            this.notificationRepo = notificationRepo;
        }

        public void Send(int patientId, string message)
        {
            var notification = new Notification
            {
                PatientId = patientId,
                Message = message
            };

            notificationRepo.Create(notification);
        }

        public List<Notification> GetAll()
        {
            return notificationRepo.Get();
        }
    }
}
