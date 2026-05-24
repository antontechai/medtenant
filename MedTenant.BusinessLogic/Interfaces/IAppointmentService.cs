using MedTenant.BusinessLogic.Entities;
using System.Collections.Generic;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IAppointmentService
    {
        List<DateTime> GetAvailableSlots(int doctorId, DateTime date);
        void BookAppointment(Appointment appointment);
    }
}