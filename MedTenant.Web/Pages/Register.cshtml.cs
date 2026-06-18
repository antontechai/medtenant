using Microsoft.AspNetCore.Mvc.RazorPages;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using MedTenant.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedTenant.Web.Pages;

public class Register : PageModel
{
    private readonly IUserService _userService; // i need user service for registration 
    private readonly ITenantService _tenantService; // i need tenant service for dropdown 
    
    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Password { get; set; }
    [BindProperty] public string Name { get; set; }
    [BindProperty] public int ChosenTenantId { get; set; }
    
    // list clinic - OnGet to show in dropdown 
    public List<Tenant> Tenants { get; set; }

    public Register(IUserService userService, ITenantService tenantService)
    {
        _userService = userService;
        _tenantService = tenantService;
    }

    public void OnGet()
    {
        Tenants = _tenantService.GetAllTenants();
    }

    public IActionResult OnPost()
    {
        //collect user from data from the form 
        User newUser = new User
        {
            Email = Email,
            Name = Name,
            TenantId = ChosenTenantId,
            Role = UserRole.Patient
        };
        
        // call userservice for register 
        _userService.Register(newUser, Password);

        return RedirectToPage("/Login");
    }
    
}