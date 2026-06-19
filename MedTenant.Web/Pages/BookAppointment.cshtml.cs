using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedTenant.Web.Pages
{
    [Authorize(Roles = "Patient")]
    public class BookAppointmentModel : PageModel
    {
        // в BookAppointment.cshtml.cs
            private readonly IAppointmentService _appointmentService;

            public BookAppointmentModel(IAppointmentService appointmentService)
            {
                _appointmentService = appointmentService;
            }

            public List<DateTime> AvailableSlots { get; set; }

            public void OnGet(int doctorId, DateTime date)
            {
                int tenantId = int.Parse(User.FindFirst("TenantId")!.Value);
                AvailableSlots = _appointmentService.GetAvailableSlots(doctorId, date, tenantId);
            }
        }
    }
