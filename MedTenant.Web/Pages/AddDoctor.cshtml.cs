using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;

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
		Doctor newDoctor = new Doctor(1, FirstName, LastName, SpecialityId); // shape doctor from the form 
		// uuse the field but not new DoctorRepository() as was before 
		_doctorService.AddDoctor(newDoctor);

		Console.WriteLine("First Name: " + FirstName);
		Console.WriteLine("Last Name: " + LastName);
		Console.WriteLine("Speciality Id: " + SpecialityId);
		
		return RedirectToPage("/Index");
	}
}
}