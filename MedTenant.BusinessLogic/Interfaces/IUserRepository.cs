using MedTenant.BusinessLogic.Entities;

namespace MedTenant.BusinessLogic.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByEmail(string email, int tenantId);
        User GetUserById(int userId, int tenantId);
    }
}