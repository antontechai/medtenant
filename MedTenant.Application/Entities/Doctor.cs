namespace MedTenant.Application.Entities
{
	public class Doctor
	{
		//
		public int Id { get; set; }
		public int TenantId { get; set; }

		// personal data 
		public string FirstName { get; set; }
		public string LastName { get; set; }

		// speciality and status 
		public int SpecialityId { get; set; }
		public bool IsActive { get; set; }

		public Doctor() // empty constructor for ASP.NET
		{
			
		}

		// construction for new doctors 
		public Doctor(int tenantId, string firstName, string lastName, int specialityId)
		{
			// not id = automatically in db
			TenantId = tenantId;
			FirstName = firstName;
			LastName = lastName;
			SpecialityId = specialityId;

			// once doctor is added, automatically let him/her be active 
			IsActive = true;
		}

		public Doctor(int id, int tenantId, string firstName, string lastName, int specialityId, bool isActive)
		{
			Id = id;
			TenantId = tenantId;
			FirstName = firstName;
			LastName = lastName;
			SpecialityId = specialityId;
			IsActive = isActive;
		}
	}
}