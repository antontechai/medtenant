using System;
using MedTenant.Application.Entities;
using MedTenant.Infrastructure.Repositories;

name space MedTenant
{
class Program
{
    static void Main(string[] args)
    {
        Doctor myDoctor = new Doctor("Anton", "Sheverdin", 1); // creating a doctor 
        DoctorRepository repository = new DoctorRepository();

        try
        {
            repository.AddDoctor(myDoctor);
            Console.WriteLine("Doctor saved into database!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Faiiled: " + ex.Message);
        }
    }
}
}