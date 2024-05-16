using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class clsPatientData
    {

        public static DataTable GetAllPatients() { 
        
            DataTable patientsDT = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {          
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_ListPatients", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();
                            if(reader.HasRows)
                                patientsDT.Load(reader);

                        }
                        catch (Exception ex)
                        {
                            DataAccessSettings.LogEvent(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessSettings.LogEvent(ex.Message);
                }

            }

            return patientsDT;
        }

        public static bool FindPatientInfoByID(int PatientID, ref int PersonID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Select * From Patients                              
                                 Where PatientID = @PatientID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", PatientID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                        }
                    }

                }
                catch (Exception ex)
                {
                    DataAccessSettings.LogEvent(ex.Message);
                }

            }

            return isFound;
        }

        public static int AddNewPatient(ref int personID, string firstName, string secondName, string thirdName,
             string lastName, DateTime dateOfBirth, byte gender, string phoneNumber,
             string email, string address)
        {

            int patientID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_AddNewPatient", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SecondName", secondName);
                    command.Parameters.AddWithValue("@ThirdName", thirdName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Address", address);

                    SqlParameter personIDOutputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(personIDOutputParam);

                    SqlParameter patientIDOutputParam = new SqlParameter("@PatientID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(patientIDOutputParam);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        personID = (int)patientIDOutputParam.Value;
                        patientID = (int)personIDOutputParam.Value;
                    }
                    catch (Exception ex)
                    {
                        DataAccessSettings.LogEvent(ex.Message);
                    }
                }
            }

            return patientID;
        }



        public static bool DeletePatient(int personID)
        {

            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_DeletePatient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

                        try
                        {
                            connection.Open();

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                isDeleted = true;

                        }
                        catch (Exception ex)
                        {
                            DataAccessSettings.LogEvent(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DataAccessSettings.LogEvent(ex.Message);
                }

            }

            return isDeleted;
        }
    }
}