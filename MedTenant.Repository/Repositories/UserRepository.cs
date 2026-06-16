using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace MedTenant.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi579814;" +
                                                    "User Id=dbi579814;Password=Lnp83ATvpj;TrustServerCertificate=True;";

        public void AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string sql =
                "INSERT INTO Users (TenantId, Email, Name, PasswordHash, Role) VALUES (@tenantId, @email, @name, @passwordHash, @role);";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@tenantId", user.TenantId); // mock data for tenants 
            command.Parameters.AddWithValue("@name", user.Name);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@role", user.Role.ToString());

            // execute and close 
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public User GetUserByEmail(string email, int tenantId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql =
                    "SELECT UserId, TenantId, Email, Name, PasswordHash, Role FROM Users WHERE email = @email AND tenantId = @tenantId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@tenantid", tenantId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            return new User
                            {
                                UserId = reader.GetInt32(0), 
                                TenantId = reader.GetInt32(1), 
                                Email = reader.GetString(2), 
                                Name = reader.GetString(3),
                                PasswordHash = reader.GetString(4),
                                Role = Enum.Parse<UserRole>(reader.GetString(5))
                            };
                        }
						
                    }
                }

            }
            return null; 
        }
        public User GetUserById(int userId, int tenantId)
        {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql =
                        "SELECT UserId, TenantId, Email, Name, PasswordHash, Role FROM Users WHERE UserId = @userId AND TenantId = @tenantId";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userid", userId);
                        command.Parameters.AddWithValue("@tenantid", tenantId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // if found doctor
                            {

                                return new User 
                                {
                                    UserId = reader.GetInt32(0), 
                                    TenantId = reader.GetInt32(1), 
                                    Email = reader.GetString(2), 
                                    Name = reader.GetString(3),
                                    PasswordHash = reader.GetString(4),
                                    Role = Enum.Parse<UserRole>(reader.GetString(5))
                                };
                            }
						
                        }
                    }

                }

                return null;
        }
    }
}