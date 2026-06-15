using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities; // for list
namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IDoctorRepository
    {
    void AddDoctor(Doctor doctor);
	List<Doctor> GetAllDoctors(int tenantId);
	void DeactiveDoctor(int id, int tenantId);
    
	// new edit methods 
	Doctor GetDoctorById(int id, int tenantId);
	void UpdateDoctor(Doctor doctor);
	}	

}