using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.BusinessLogic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            // the name cannot be empty 
            if (string.IsNullOrEmpty(doctor.Name))
            {
                throw new Exception("First name cannot be empty");
            }

            // if accepted move to repository 
            _doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors(int tenantId)
        {
            return _doctorRepository.GetAllDoctors(tenantId);
        }

        public void DeactiveDoctor(int id, int tenantId)
        {
            _doctorRepository.DeactiveDoctor(id, tenantId);
        }

        public Doctor GetDoctorById(int id, int tenantId)
        {
            return _doctorRepository.GetDoctorById(id, tenantId);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _doctorRepository.UpdateDoctor(doctor);
        }
    }
}