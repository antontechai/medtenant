using System.Collections.Generic;
using MedTenant.Application.Entities;
using MedTenant.Application.Interfaces;
using Microsoft.Data.SqlClient;

namespace MedTenant.Infrastructure.Repositories
{
	public class DoctorRepository : IDoctorRepository
	{
		private readonly string _connectionString =
			"Server=mssqlstud.fhict.local;Database=dbi579814;User Id=dbi579814;Password=Lnp83ATvpj;TrustServerCertificate=True;";

		public void AddDoctor(Doctor doctor)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			string sql =
				"INSERT INTO Doctors (TenantId, FirstName, LastName, SpecialityId, IsActive) VALUES (@tenantId, @firstName, @lastName, @specialityId, @isActive);";
			SqlCommand command = new SqlCommand(sql, connection);
			// filling @ with real data from C#
			command.Parameters.AddWithValue("@tenantId", 1); // mock data for tenants 
			command.Parameters.AddWithValue("@firstName", doctor.FirstName);
			command.Parameters.AddWithValue("@lastName", doctor.LastName);
			command.Parameters.AddWithValue("@specialityId", doctor.SpecialityId);
			command.Parameters.AddWithValue("@isActive", doctor.IsActive);

			// execute and close 
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}