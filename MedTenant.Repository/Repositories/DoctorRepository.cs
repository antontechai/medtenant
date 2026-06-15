using System.Collections.Generic;
using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace MedTenant.Repository.Repositories
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
				"INSERT INTO Doctors (TenantId, UserId, Name, Specialty, IsActive) VALUES (@tenantId, @userId, @name, @specialty, @isActive);";
			SqlCommand command = new SqlCommand(sql, connection);
			// filling @ with real data from C#
			command.Parameters.AddWithValue("@tenantId", doctor.TenantId); // mock data for tenants 
			command.Parameters.AddWithValue("@name", doctor.Name);
			command.Parameters.AddWithValue("@userId", doctor.UserId);
			command.Parameters.AddWithValue("@specialty", doctor.Specialty);
			command.Parameters.AddWithValue("@isActive", doctor.IsActive);

			// execute and close 
			command.ExecuteNonQuery();
			connection.Close();
		}

		public List<Doctor> GetAllDoctors(int tenantId)
		{
			List<Doctor> AllDoctors = new List<Doctor>(); // empty box for answers
			using (SqlConnection
			       connection =
			       new SqlConnection(_connectionString)) // creating protected connection tunnel with server and sql db
				// _connectionc string precise address 
				// using construction gurantee that code goes to connection.Close()
			{
				connection.Open();
				// preparing SQL request 
				string sqlDoctors = "SELECT id, TenantId, UserId, Name, Specialty, IsActive FROM Doctors WHERE isActive = 1 AND TenantId = @tenantId";

				// creating command 
				using (SqlCommand command = new SqlCommand(sqlDoctors, connection)) // specification of what to do
				{
					// share ID so db know who exactly to change
					command.Parameters.AddWithValue("@tenantId", tenantId);
					// executing command and get Reader
					using (SqlDataReader
					       reader = command
						       .ExecuteReader()) // ExecuteReader() get table with data and SqlDataReader tool that helps to read it 
					{
						// reader reading data 
						while (reader.Read()) // read untill false 
						{
							// taking data and putting them into variables
							int id = reader.GetInt32(0); // 0 is first column (Id)
							int docTenantId = reader.GetInt32(1); // 1 - second column (TenantId)
							int userId = reader.GetInt32(2);
							string name = reader.GetString(3);
							string specialty = reader.GetString(4);
							bool isActive = reader.GetBoolean(5);

							// using new constructor, to shape the doctor 
							Doctor doc = new Doctor(id, tenantId, userId, name, specialty, isActive);
							// adding new created doctor into the list 
							AllDoctors.Add(doc);
						}
					}
				}
			}

			// return fully filled list 
			return AllDoctors;
		}

		public void DeactiveDoctor(int id, int tenantId)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			string DeactivSql =
				"UPDATE Doctors SET IsActive = 0 WHERE Id = @id AND TenantId = @tenantId";
			using (SqlCommand command = new SqlCommand(DeactivSql, connection)) // specification of what to do
			{
				command.Parameters.AddWithValue("@id", id);
				command.Parameters.AddWithValue("@tenantid", tenantId);
				command.ExecuteNonQuery();
				connection.Close();
			}

		}

		public Doctor GetDoctorById(int id, int tenantId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				string sql =
					"SELECT Id, TenantId, UserId, Name, Specialty, IsActive FROM Doctors WHERE Id =@id AND TenantId = @tenantid";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@id", id);
					command.Parameters.AddWithValue("@tenantid", tenantId);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read()) // if found doctor
						{
							int docId = reader.GetInt32(0);
							int docTenantId = reader.GetInt32(1);
							int userId = reader.GetInt32(2);
							string name = reader.GetString(3);
							string specialty = reader.GetString(4);
							bool isActive = reader.GetBoolean(5);

							return new Doctor(docId, tenantId, userId, name, specialty, isActive);
						}
						
					}
				}

			}
			return null; // if no doctor with that ID
		}

		public void UpdateDoctor(Doctor doctor)
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					string sql =
						"UPDATE Doctors SET Name = @name, Specialty = @specialty, IsActive = @isActive WHERE Id = @id AND TenantId = @tenantID";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						// filling @ with real data from C#
						// share ID so db know who exactly to change
						command.Parameters.AddWithValue("@id", doctor.Id);
						command.Parameters.AddWithValue("@tenantId", doctor.TenantId);
						command.Parameters.AddWithValue("@name", doctor.Name);
						command.Parameters.AddWithValue("@specialty", doctor.Specialty);
						command.Parameters.AddWithValue("@isActive", doctor.IsActive);
						// execute and close 
						command.ExecuteNonQuery();
						// using will close eveything 
					}
				}
			}
		
	}
}














