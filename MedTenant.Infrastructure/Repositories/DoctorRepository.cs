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

		public List<Doctor> GetAllDoctors()
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
				string sqlDoctors = "SELECT id, TenantId, FirstName, LastName, SpecialityId, IsActive FROM Doctors";

				// creating command 
				using (SqlCommand command = new SqlCommand(sqlDoctors, connection)) // specification of what to do
				{
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
							int tenantId = reader.GetInt32(1); // 1 - second column (TenantId)
							string firstName = reader.GetString(2);
							string lastName = reader.GetString(3);
							int specialityId = reader.GetInt32(4);
							bool isActive = reader.GetBoolean(5);

							// using new constructor, to shape the doctor 
							Doctor doc = new Doctor(id, tenantId, firstName, lastName, specialityId, isActive);

							// adding new created doctor into the list 
							AllDoctors.Add(doc);
						}
					}
				}
			}

			// return fully filled list 
			return AllDoctors;
		}

		public void DeactiveDoctor(int id)
		{
			SqlConnection connection = new SqlConnection(_connectionString);
			connection.Open();
			string DeactivSql =
				"UPDATE Doctors SET IsActive = 0 WHERE Id = @id";
			using (SqlCommand command = new SqlCommand(DeactivSql, connection)) // specification of what to do
			{
				command.Parameters.AddWithValue("@id", id);
				command.ExecuteNonQuery();
				connection.Close();
			}

		}

		public Doctor GetDoctorById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				string sql =
					"SELECT Id, TenantId, FirstName, LastName, SpecialityId, IsActive FROM Doctors Where Id =@id";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@id", id);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read()) // if found doctor
						{
							int docId = reader.GetInt32(0);
							int tenantId = reader.GetInt32(1);
							string firstName = reader.GetString(2);
							string lastName = reader.GetString(3);
							int specialityId = reader.GetInt32(4);
							bool isActive = reader.GetBoolean(5);

							return new Doctor(docId, tenantId, firstName, lastName, specialityId, isActive);
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
						"UPDATE Doctors SET FirstName = @firstName, LastName = @lastName, SpecialityId = @specialityId, IsActive = @isActive WHERE Id = @id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						// filling @ with real data from C#
						command.Parameters.AddWithValue("@firstName", doctor.FirstName);
						command.Parameters.AddWithValue("@lastName", doctor.LastName);
						command.Parameters.AddWithValue("@specialityId", doctor.SpecialityId);
						command.Parameters.AddWithValue("@isActive", doctor.IsActive);
						// share ID so db know who exactly to change
						command.Parameters.AddWithValue("@id", doctor.Id);
						// execute and close 
						command.ExecuteNonQuery();
						// using will close eveything 
					}
				}
			}
		
	}
}














