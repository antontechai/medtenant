using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedTenant.Web.Pages;

[Authorize(Roles = "Patient")]
public class PatientViewModel : PageModel
{
    private readonly IDoctorService _doctorService;

    public PatientViewModel(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public List<Doctor> DoctorList { get; set; } = new List<Doctor>();

    public void OnGet()
    {
        int tenantId = int.Parse(User.FindFirst("TenantId")!.Value);
        DoctorList = _doctorService.GetAllDoctors(tenantId);
    }
}