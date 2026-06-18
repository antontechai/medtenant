namespace MedTenant.BusinessLogic.Entities
{
    public enum UserRole
    {
        Patient,
        Manager,
        Doctor
    }

    public class User
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public string Name { get; set; }
    }
}