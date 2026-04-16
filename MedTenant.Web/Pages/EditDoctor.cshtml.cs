using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.Application.Entities;
using MedTenant.Infrastructure.Repositories;

namespace MedTenant.Web.Pages
{
    public class EditDoctorModel : PageModel
    {
        [BindProperty] // let HTML automatically fill in this object
        public Doctor CurrentDoctor { get; set; }
        
        // this method will work when page is open 
        public IActionResult OnGet(int id)
        {
            DoctorRepository repo = new DoctorRepository();
            CurrentDoctor = repo.GetDoctorById(id); // pulling out old data from db

            if (CurrentDoctor == null)
            {
                return RedirectToPage("/Index"); // if no doctor,move to main 
            }

            return Page();
        }
        
        // this method will work after selecting Save
        public IActionResult OnPost()
        {
            DoctorRepository repo = new DoctorRepository();
            repo.UpdateDoctor(CurrentDoctor); // send new data to db 

            return RedirectToPage("/Index"); // Return to list
        }
    }
    
}