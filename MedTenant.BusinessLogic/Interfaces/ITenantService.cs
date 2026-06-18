using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface ITenantService
    {
        List<Tenant> GetAllTenants();

    }
}