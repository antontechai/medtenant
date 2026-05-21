using MedTenant.Application.Entities;
using System.Collections.Generic;
namespace MedTenant.Application.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
        void DeactiveDoctor(int id);
        Doctor GetDoctorById(int id);
        void UpdateDoctor(Doctor doctor);
    }
}