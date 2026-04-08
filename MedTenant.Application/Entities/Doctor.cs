namespace MedTenant.Application.Entities
{
    public class Doctor
    {
        //
        public int Id { get; private set; }
        public int TenantId { get; private set }
        
        // personal data 
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        // speciality and status 
        public int SpecialityId { get; private set;  }
        public bool IsActive { get; private set; }
        
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
    }
}