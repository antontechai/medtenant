using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.Web.Pages 
{ 
	public class AddDoctor : PageModel
	{
		// store the repo 
		private readonly IDoctorService _doctorService; // not changable when set up || _ all methods can see this variable  

		// asp.net reads this constructor and give DoctorRepository(Program.cs)
		public AddDoctor(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}	

		[BindProperty] // Connect HTML 
			public string FirstName { get; set; }
		[BindProperty]
			public string LastName { get; set; }
		[BindProperty]
			public int SpecialityId { get; set; }

    public void OnGet()
    { 
		// method open empty page 
    }
	
    // public void OnPost()
       public IActionResult OnPost()
       { 
	       int tenantId = 1;
	       int userId = 1;
	       string name = "as";
	       string specialty = "sda";
		Doctor newDoctor = new Doctor(tenantId, userId, name, specialty); // shape doctor from the form 
		// uuse the field but not new DoctorRepository() as was before 
		_doctorService.AddDoctor(newDoctor);
		
		return RedirectToPage("/Index");
	}
}
}