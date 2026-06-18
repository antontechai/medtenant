using MedTenant.BusinessLogic.Entities;
using MedTenant.BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace MedTenant.Repository.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string _connectionString =
            "Server=mssqlstud.fhict.local;Database=dbi579814;User Id=dbi579814;Password=Lnp83ATvpj;TrustServerCertificate=True;";

        public void BookAppointment(Appointment appointment)
        {
            // open connection to database
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // SQL insert command
            string sql =
                "INSERT INTO Appointments (TenantId, DoctorId, PatientUserId, TimeSlot, Status) VALUES (@tenantId, @doctorId, @patientUserId, @timeSlot, @status);";

            SqlCommand command = new SqlCommand(sql, connection);

            // fill @ placeholders with real data
            command.Parameters.AddWithValue("@tenantId", appointment.TenantId);
            command.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
            command.Parameters.AddWithValue("@patientUserId", appointment.PatientUserId);
            command.Parameters.AddWithValue("@timeSlot", appointment.TimeSlot);
            command.Parameters.AddWithValue("@status", appointment.Status);

            
            // execute and close
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public List<Appointment> GetAppointmentsByDoctorAndDate(int doctorId, DateTime date, int tenantId)
        {
            List<Appointment> appointments = new List<Appointment>();
    
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
        
                // select appointments for specific doctor on specific date
                string sql = "SELECT Id, TenantId, DoctorId, PatientUserId, TimeSlot, Status FROM Appointments WHERE DoctorId = @doctorId AND CAST(TimeSlot AS DATE) = CAST(@date AS DATE) AND TenantId = @tenantId";
        
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@tenantId", tenantId);
            
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // read each column and create Appointment object
                            Appointment a = new Appointment
                            {
                                Id = reader.GetInt32(0),
                                TenantId = reader.GetInt32(1),
                                DoctorId = reader.GetInt32(2),
                                PatientUserId = reader.GetInt32(3),
                                TimeSlot = reader.GetDateTime(4),
                                Status = reader.GetString(5)
                            };
                            appointments.Add(a);
                        }
                    }
                }
            }
            return appointments;
        }
    }
}
