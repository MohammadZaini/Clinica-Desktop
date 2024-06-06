using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class clsAppointmentData
    {

        public static DataTable GetAllAppointments()
        {

            DataTable appointmentsDT = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAllAppointments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                                appointmentsDT.Load(reader);

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

            return appointmentsDT;
        }

        public static bool GetAppointmentInfoByID(int appointmentID, ref int patientID, ref int doctorID, ref DateTime appointmentDate,
            ref TimeSpan appointmentTime, ref byte appointmentStatus, ref int medicalRecordID, ref int paymentID, ref int createdByUserID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_GetAppointmentInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            patientID = (int)reader["PatientID"];
                            doctorID = (int)reader["DoctorID"];
                            appointmentDate = (DateTime)reader["AppointmentDate"];
                            appointmentTime = (TimeSpan)reader["AppointmentTime"];
                            appointmentStatus = (byte)reader["AppointmentStatus"];
                            medicalRecordID = (int)reader["MedicalRecordID"];
                            paymentID = (int)reader["PaymentID"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }
                }

            }

            return isFound;
        }

        public static int AddNewAppoinment(int patientID, int doctorID, DateTime appointmentDate, TimeSpan appointmentTime , byte appointmentStatus, 
            int medicalRecordID, int paymentID, int createdByUserID, int timeSlotID) {


            int appointmentID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_AddNewAppointment", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PatientID", patientID);
                    command.Parameters.AddWithValue("@DoctorID", doctorID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                    command.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus);

                    if (medicalRecordID == 0)
                        command.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@MedicalRecordID", medicalRecordID);


                    if (paymentID == 0)
                        command.Parameters.AddWithValue("@PaymentID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@PaymentID", paymentID);


                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@TimeSlotID", timeSlotID);


                    SqlParameter appointmentIDOutputParam = new SqlParameter("@AppointmentID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(appointmentIDOutputParam);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        appointmentID = (int)appointmentIDOutputParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }
                }
            }

            return appointmentID;
        }


        public static bool UpdateAppointment(int appointmentID, DateTime appointmentDate, TimeSpan appointmentTime, byte appointmentStatus) {

            bool isUpdated = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_UpdateAppointment", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@AppointmentTime", appointmentTime);
                    command.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus);
       
                    try
                    {
                        connection.Open();
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                            isUpdated = true;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }
                }
            }

            return isUpdated;
        }
    }
}