using MedTenant.Application.Entities;
using System.Collections.Generic; // for list
namespace MedTenant.Application.Interfaces
{
    public interface IDoctorRepository
    {
    void AddDoctor(Doctor doctor);
	List<Doctor> GetAllDoctors();
	void DeactiveDoctor(int id);
    
	// new edit methods 
	Doctor GetDoctorById(int id);
	void UpdateDoctor(Doctor doctor);
	}

}