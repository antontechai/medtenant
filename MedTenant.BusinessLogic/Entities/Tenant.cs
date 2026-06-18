namespace MedTenant.BusinessLogic.Entities
{
    public class Tenant
    {
        public int Id { get; private set; }
        public string ClinicName { get; private set; }
        public string OpenHours { get; private set; }
        public bool IsActive { get; private set; }
        
        // add clinic 
        public Tenant(string clinicName, string openHours)
        {
            ClinicName = clinicName;
            OpenHours = openHours;
            
            IsActive = true;
        }
        
        // read clinic from db 
        public Tenant(int tenantId, string clinicName, string openHours, bool isActive)
        {
            Id = tenantId;
            ClinicName = clinicName;
            OpenHours = openHours;
            IsActive = isActive;
        }
    }
}