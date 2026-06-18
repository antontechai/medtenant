using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace MedTenant.Repository.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly string _connectionString =
            "Server=mssqlstud.fhict.local;Database=dbi579814;User Id=dbi579814;Password=Lnp83ATvpj;TrustServerCertificate=True;";

        public List<Tenant> GetAllTenants()
        {
            List<Tenant> tenants = new List<Tenant>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT TenantId, Name, OpeningHours FROM Tenant";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tenant tenant = new Tenant
                                (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                true
                                );
                            tenants.Add(tenant);
                        }
                        return tenants;
                    }
                }
            }
        }
    }
}