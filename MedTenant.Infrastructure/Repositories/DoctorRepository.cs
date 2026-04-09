using System.Collections.Generic;
using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;
using Npgsql;

namespace MedTenant.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString =
            "Host=localhost; Database=medtenant_db; Username=postgres; Password=123";
        
    }
}