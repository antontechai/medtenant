using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace MedTenant.Web.Pages;

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
        DoctorList = _doctorService.GetAllDoctors();
    }
}