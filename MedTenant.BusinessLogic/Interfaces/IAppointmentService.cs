using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAvailableSlots(int doctorId, DateTime date);
        void BookAppointment(Appointment appointment);
    }
}