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

        public List<DateTime> AvailableSlots { get; set; }

        public void OnGet(int doctorId, DateTime date)
        {
            int tenantId = 1;
            AvailableSlots = _appointmentService.GetAvailableSlots(doctorId, date, tenantId);
        }
    }
}