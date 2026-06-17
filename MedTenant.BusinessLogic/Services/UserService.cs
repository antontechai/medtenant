using System.Diagnostics.Tracing;
using MedTenant. BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;

namespace MedTenant.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(User user, string plainPassword)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword); // hashing plain password BCrypt
            _userRepository.AddUser(user); // adding to db
            // get UserByEmail to know UserId 
            User DbUser = _userRepository.GetUserByEmail(user.Email, user.TenantId);
            return DbUser; // return user
        }
        
        public User Login(string email, string password, int tenantId)
        {
        // GetUserByEmail
            User user = _userRepository.GetUserByEmail(email, tenantId); // looking for user by email | request repository 
            if (user == null) return null; // if nothing return null
            bool isMatch = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash); // check if plain password match hash with bcrypt
            if (isMatch == true) return user; // if false move to the next line which is return = null
            return null;
    }
    }
}