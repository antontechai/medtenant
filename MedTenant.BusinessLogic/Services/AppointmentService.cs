using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace MedTenant.BusinessLogic.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<Appointment> GetAvailableSlots(int doctorId, DateTime date)
        {
            // can't be booked in the past
            if (date < DateTime.Today)
            {
                throw new Exception("Cannot book appointments in the past");
            }
            return _appointmentRepository.GetAppointmentsByDoctorAndDate(doctorId, date);
        }

        public void BookAppointment(Appointment appointment)
        {
            _appointmentRepository.BookAppointment(appointment);
        }
    }
}