using System;
using MedTenant.Application.Entities;
using MedTenant.Infrastructure.Repositories;

namespace MedTenant.Execution
{
class Program
{
    static void Main(string[] args)
    {
        Doctor myDoctor = new Doctor(1, "Anton", "Sheverdin", 5); // creating a doctor 
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