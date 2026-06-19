using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedTenant.Web.Pages
{
    [Authorize(Roles = "Manager")]
    public class AddDoctor : PageModel
    {
        private readonly IDoctorService _doctorService;

        public AddDoctor(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Specialty { get; set; }

        public void OnGet()
        {
            // empty page
        }

        public IActionResult OnPost()
        {
            int tenantId = int.Parse(User.FindFirst("TenantId")!.Value);
            int userId = 1; // placeholder — Doctor has no user account in this iteration

            Doctor newDoctor = new Doctor(tenantId, userId, Name, Specialty);
            _doctorService.AddDoctor(newDoctor);
            return RedirectToPage("/Index");
        }
    }
}