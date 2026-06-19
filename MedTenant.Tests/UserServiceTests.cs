using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Services;
using MedTenant.BusinessLogic.Interfaces;
using Xunit;

namespace MedTenant.Tests
{
    public class UserServiceTests
    {
        //  happy path
        [Fact]
        public void Login_WithCorrectCredentials_ReturnsUser()
        {
            //  prepare fake repo and service
            var fakeRepo = new FakeUserRepository();
            var service = new UserService(fakeRepo);

            var newUser = new User
            {
                Email = "test@example.com",
                Name = "Test User",
                TenantId = 1,
                Role = UserRole.Patient
            };

            // Register hashes the password and saves the user
            service.Register(newUser, "MyPassword123");

            // try to login with the same credentials
            var result = service.Login("test@example.com", "MyPassword123", 1);

            //  expect a real user back, not null
            Assert.NotNull(result);
            Assert.Equal("test@example.com", result.Email);
        }

        // wrong password should return null
        [Fact]
        public void Login_WithWrongPassword_ReturnsNull()
        {
            var fakeRepo = new FakeUserRepository();
            var service = new UserService(fakeRepo);

            var newUser = new User
            {
                Email = "test@example.com",
                Name = "Test User",
                TenantId = 1,
                Role = UserRole.Patient
            };

            service.Register(newUser, "RightPassword");

            // try to login with wrong password
            var result = service.Login("test@example.com", "WrongPassword", 1);

            //  login must fail
            Assert.Null(result);
        }

        // multi-tenant isolation - user from clinic 1 cannot login as clinic 2
        [Fact]
        public void Login_WithWrongTenant_ReturnsNull()
        {
            var fakeRepo = new FakeUserRepository();
            var service = new UserService(fakeRepo);

            var newUser = new User
            {
                Email = "test@example.com",
                Name = "Test User",
                TenantId = 1,
                Role = UserRole.Patient
            };

            service.Register(newUser, "MyPassword");

            //  same email and password but trying tenant 2
            var result = service.Login("test@example.com", "MyPassword", 2);

            //  the user belongs to tenant 1, so tenant 2 lookup returns null
            Assert.Null(result);
        }
    }

    // Fake user repository  stores users in memory, no real database
    public class FakeUserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserByEmail(string email, int tenantId)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.TenantId == tenantId);
        }

        public User GetUserById(int userId, int tenantId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId && u.TenantId == tenantId);
        }
    }
}