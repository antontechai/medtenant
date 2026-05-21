using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
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