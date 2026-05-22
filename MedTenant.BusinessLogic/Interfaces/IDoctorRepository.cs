using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities; // for list
namespace MedTenant.BusinessLogic.Interfaces
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