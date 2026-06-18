using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface ITenantRepository
    {
        List<Tenant> GetAllTenants();

    }
}