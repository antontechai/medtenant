using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        User Register(User user, string plainPassword);
        User Login(string email, string password, int tenantId);
    }
}