using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using MedTenant.Application.Entities;
using MedTenant.Infrastructure.Repositories;

namespace MedTenant.Web.Pages;

public class IndexModel : PageModel
{
    public List<Doctor> DoctorList { get; set; } = new List<Doctor>();

    public void OnGet()
    {
        DoctorRepository DoctorSql = new DoctorRepository();
        DoctorList = DoctorSql.GetAllDoctors();
    }


// new method 
    public IActionResult OnPostDeactivate(int id)
    {
        // connecting to repo
        DoctorRepository DoctorSql = new DoctorRepository();
        // call DeactiveDoctor(id) method 
        DoctorSql.DeactiveDoctor(id);
        // refresh to see new list 
        return RedirectToPage();
    }
}