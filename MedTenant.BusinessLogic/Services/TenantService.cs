using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.BusinessLogic.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public List<Tenant> GetAllTenants()
        {
            return _tenantRepository.GetAllTenants();
        }
    }
}