using MedTenant.BusinessLogic.Interfaces;
using MedTenant.Repository.Repositories;
using MedTenant.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // created system and return it
    .AddCookie(options => // added cookie mode to the system above  & => lambda - recipe 
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.Cookie.Name = "MedTenantAuth";
        options.Cookie.HttpOnly = true; // XSS JS protection 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // first who

app.UseAuthorization(); // than what allowed 

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
