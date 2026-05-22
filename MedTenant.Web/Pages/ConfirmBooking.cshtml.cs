using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.Web.Pages
{
    public class ConfirmBookingModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public ConfirmBookingModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void OnGet(int doctorId, DateTime timeSlot)
        {
            // show confirmation page with doctor and time details
        }

        public IActionResult OnPost(int doctorId, DateTime timeSlot)
        {
            Appointment appointment = new Appointment
            {
                TenantId = 1, 
                DoctorId = doctorId,
                PatientId = 1, 
                TimeSlot = timeSlot,
                Status = "Booked"
            };

            _appointmentService.BookAppointment(appointment);
            return RedirectToPage("/Index");
        }
    }
}