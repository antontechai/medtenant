using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace MedTenant.Web.Pages
{
    public class BookAppointmentModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public BookAppointmentModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public List<Appointment> AvailableSlots { get; set; }

        public void OnGet(int doctorId, DateTime date)
        {
            AvailableSlots = _appointmentService.GetAvailableSlots(doctorId, date);
        }
    }
}