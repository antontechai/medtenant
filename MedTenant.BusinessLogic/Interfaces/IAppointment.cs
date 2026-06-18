using MedTenant.BusinessLogic.Entities;
using System.Collections.Generic;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAppointmentsByDoctorAndDate(int doctorId, DateTime date, int tenantId);
        void BookAppointment(Appointment appointment);
    }
}