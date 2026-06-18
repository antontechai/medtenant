namespace MedTenant.BusinessLogic.Entities
{
	public class Doctor
	{
		//
		public int Id { get; set; }
		public int TenantId { get; set; }

		// personal data 
		public string Name { get; set; }

		// speciality and status 
		public string Specialty { get; set; }
		public bool IsActive { get; set; }
		public int UserId { get; set; }

		public Doctor() // empty constructor for ASP.NET
		{
			
		}

		// construction for new doctors 
		public Doctor(int tenantId, int userId, string name, string specialty)
		{
			// not id = automatically in db
			TenantId = tenantId;
			Name = name;
			UserId = userId;
			Specialty = specialty;

			// once doctor is added, automatically let him/her be active 
			IsActive = true;
		}

		public Doctor(int id, int tenantId, int userId, string name, string specialty, bool isActive)
		{
			Id = id;
			TenantId = tenantId;
			Specialty = specialty;
			IsActive = isActive;
			Name = name;
			UserId = userId;
		}
	}
}