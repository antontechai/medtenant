using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;
using MedTenant.Infrastructure.Repositories;
namespace DefaultNamespace 
{

public class AddDoctor : PageModel
{
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
	
	public void OnPost()
	{
		Doctor newDoctor = new Doctor(1, FirstName, LastName, SpecialityId); // shape doctor from the form 
		DoctorRepository repository = new DoctorRepository(); // working with db 
		repository.AddDoctor(newDoctor);	

		Console.WriteLine("First Name: " + FirstName);
		Console.WriteLine("Last Name: " + LastName);
		Console.WriteLine("Speciality Id: " + SpecialityId);
	}
}
}