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

        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date, int tenantId)
        {
            // can't be booked in the past
            if (date < DateTime.Today)
            {
                throw new Exception("Cannot book appointments in the past");
            }

            // clinic hours: 9am to 5 5pm; each 30 min slots
            var allSlots = new List<DateTime>();
            var start = date.Date.AddHours(9);
            var end = date.Date.AddHours(17);
            
            // generate all possible slots 
            for (var slot = start; slot < end; slot = slot.AddMinutes(30))
            {
                allSlots.Add(slot);
            }
            
            // get already booked slots from repository 
            var booked = _appointmentRepository.GetAppointmentsByDoctorAndDate(doctorId, date, tenantId);
            var bookedTimes = booked.Select(a => a.TimeSlot).ToList();
            
            //return only free slots 
            return allSlots.Where(s => !bookedTimes.Contains(s)).ToList();
        }

        public void BookAppointment(Appointment appointment)
        {
            // check if the slot is already booked 
            var existing = _appointmentRepository.GetAppointmentsByDoctorAndDate
            (
                appointment.DoctorId,
                appointment.TimeSlot.Date,
                appointment.TenantId
            );

            bool slotTaken = existing.Any(a => a.TimeSlot == appointment.TimeSlot);

            if (slotTaken)
            {
                throw new Exception("This slot is no longer avaliable, please choose another one.");
            }
            
            _appointmentRepository.BookAppointment(appointment);
        }
    }
}