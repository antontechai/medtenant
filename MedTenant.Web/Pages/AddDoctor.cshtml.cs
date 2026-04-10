using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

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
		Console.WriteLine("First Name: " + FirstName);
		Console.WriteLine("Last Name: " + LastName);
		Console.WriteLine("Speciality Id: " + SpecialityId);
	}
}
}