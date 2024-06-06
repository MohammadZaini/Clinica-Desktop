using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class clsTimeSlotData
    {
        public static DataTable GetAllTimeSlotsPerDoctor(int doctorID, DateTime selectedDate) { 

            DataTable timeSlots = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_GetTimeSlots", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DoctorID", doctorID);
                        command.Parameters.AddWithValue("@ReservationDate", selectedDate);

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                                timeSlots.Load(reader);

                        }
                        catch (Exception ex)
                        {
                            clsDataAccessSettings.LogEvent(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.LogEvent(ex.Message);
                }

            }

            return timeSlots;
        }

        public static bool GetAppointmentTimeBySlotID(int timeSlotID, ref TimeSpan startTime, ref TimeSpan endTime)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAppointmentTimeByTimeSlotID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TimeSlotID", timeSlotID);

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                isFound = true;

                                startTime = (TimeSpan)reader["StartTime"];
                                endTime = (TimeSpan)reader["EndTime"];

                            }       
                        }
                        catch (Exception ex)
                        {
                            clsDataAccessSettings.LogEvent(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.LogEvent(ex.Message);
                }

            }

            return isFound;
        }

    }
}
