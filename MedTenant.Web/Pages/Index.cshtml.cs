using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IDoctorService _doctorService;

    public IndexModel(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public List<Doctor> DoctorList { get; set; } = new List<Doctor>();

    public void OnGet()
    {
        DoctorList = _doctorService.GetAllDoctors();
    }

    public IActionResult OnPostDeactivate(int id)
    {
        _doctorService.DeactiveDoctor(id);
        return RedirectToPage();
    }
}