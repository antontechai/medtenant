using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedTenant.Web.Pages
{
    [Authorize(Roles = "Patient")]
    // в BookAppointment.cshtml.cs
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
                try
                {
                    int tenantId = int.Parse(User.FindFirst("TenantId")!.Value);
                    int userId = int.Parse(User.FindFirst("UserId")!.Value);
                    
                    Appointment appointment = new Appointment
                    {
                        TenantId = tenantId,
                        DoctorId = doctorId,
                        PatientUserId = userId,
                        TimeSlot = timeSlot,
                        Status = "Booked"
                    };

                    _appointmentService.BookAppointment(appointment);
                    return RedirectToPage("/Index");
                }
                catch (Exception ex)
                {
                    // show error message 
                    ModelState.AddModelError("", ex.Message);
                    return Page();
                }
            }
        }
    }
