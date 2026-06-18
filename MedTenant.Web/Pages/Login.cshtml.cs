using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.Web.Pages;

public class Login : PageModel
{
    private readonly IUserService _userService;
    private readonly ITenantService _tenantService;

    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Password { get; set; }
    [BindProperty] public int ChosenTenantId { get; set; }

    public List<Tenant> Tenants { get; set; }
    public string? ErrorMessage { get; set; }

    public Login(IUserService userService, ITenantService tenantService)
    {
        _userService = userService;
        _tenantService = tenantService;
    }

    public void OnGet()
    {
        Tenants = _tenantService.GetAllTenants();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        User? foundUser = _userService.Login(Email, Password, ChosenTenantId);

        if (foundUser == null)
        {
            ErrorMessage = "Invalid credentials!";
            Tenants = _tenantService.GetAllTenants();
            return Page();
        }

    // claims
    var claims = new List<Claim>
    {
        new Claim("UserId", foundUser.UserId.ToString()),
        new Claim("TenantId", foundUser.TenantId.ToString()),
        new Claim(ClaimTypes.Role, foundUser.Role.ToString()),
        new Claim(ClaimTypes.Name, foundUser.Name)
    };

    // claims to identity 
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

    //user identity
    var principal = new ClaimsPrincipal(identity);

    //
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    
    return RedirectToPage("/Index");

    }
    
}
