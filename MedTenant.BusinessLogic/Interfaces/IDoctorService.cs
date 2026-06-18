using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors(int tenantId);
        void DeactiveDoctor(int id, int tenantId);
        Doctor GetDoctorById(int id, int tenantId);
        void UpdateDoctor(Doctor doctor);
    }
}