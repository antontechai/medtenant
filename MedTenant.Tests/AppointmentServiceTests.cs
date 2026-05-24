using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Services;
using MedTenant.BusinessLogic.Interfaces;
using Xunit;

namespace MedTenant.Tests
{
    public class AppointmentServiceTests
    {
        [Fact]
        public void BookAppointment_WhenSlotTaken_ThrowException()
        {
            // arrange, create fake repo with one booked slot
            var fakeRepo = new FakeAppointmentRepository();
            var service = new AppointmentService(fakeRepo);

            var takenSlot = new DateTime(2026, 5, 25, 10, 0, 0);
            
            // add existing appointment to fake repo 
            fakeRepo.AddExisting(new Appointment
            {
                DoctorId = 1,
                TimeSlot = takenSlot,
                Status = "Booked"
            });
            
            // Act & Assert - booking same slot should throw
            var newAppointment = new Appointment
            {
                DoctorId = 1,
                TimeSlot = takenSlot,
                Status = "Bookeed"
            };

            Assert.Throws<Exception>(() => service.BookAppointment((newAppointment)));
        }
    }
    
    // fake repo no db
    public class FakeAppointmentRepository : IAppointmentRepository
    {
        private List<Appointment> _appointments = new List<Appointment>();

        public void AddExisting(Appointment a) => _appointments.Add(a);

        public List<Appointment> GetAppointmentsByDoctorAndDate(int doctorId, DateTime date)
        {
            return _appointments
                .Where(a => a.DoctorId == doctorId && a.TimeSlot.Date == date.Date)
                .ToList();
        }

        public void BookAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }
    }
}

