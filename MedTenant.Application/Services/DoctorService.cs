using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;
using System.Collections.Generic;

namespace MedTenant.Application.Services
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
            if (string.IsNullOrEmpty(doctor.FirstName))
            {
                throw new Exception("First name cannot be empty");
            }

            // if accepted move to repository 
            _doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public void DeactiveDoctor(int id)
        {
            _doctorRepository.DeactiveDoctor(id);
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorRepository.GetDoctorById(id);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _doctorRepository.UpdateDoctor(doctor);
        }
    }
}