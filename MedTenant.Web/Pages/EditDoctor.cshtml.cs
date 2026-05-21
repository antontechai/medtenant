using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;

namespace MedTenant.Web.Pages
{
    public class EditDoctorModel : PageModel
    {
		private readonly IDoctorService _editDoctorService;

		public EditDoctorModel(IDoctorService editDoctorService)
		{
			_editDoctorService = editDoctorService;
		}
        [BindProperty] // let HTML automatically fill in this object
        public Doctor CurrentDoctor { get; set; }
        
        // this method will work when page is open 
        public IActionResult OnGet(int id)
        {
            CurrentDoctor = _editDoctorService.GetDoctorById(id); // pulling out old data from db

            if (CurrentDoctor == null)
            {
                return RedirectToPage("/Index"); // if no doctor,move to main 
            }

            return Page();
        }
        
        // this method will work after selecting Save
        public IActionResult OnPost()
        {
			_editDoctorService.UpdateDoctor(CurrentDoctor);
			return RedirectToPage("/Index");
        }
    }
}