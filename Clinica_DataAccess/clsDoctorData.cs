using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class clsDoctorData
    {

        public static DataTable GetAllDoctors()
        {

            DataTable doctorsDT = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_ListDoctors", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            connection.Open();

                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                                doctorsDT.Load(reader);

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

            return doctorsDT;
        }

        public static bool GetDoctorInfoByID(int doctorID, ref int personID, ref string specialization) { 
            
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_GetDoctorInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;      
                    command.Parameters.AddWithValue("@DoctorID", doctorID);
  
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            personID = (int)reader["PersonID"];
                            specialization = (string)reader["Specialization"];
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

        public static int AddNewDoctor(ref int personID, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gender, string phoneNumber,
            string email, string address, string specialization)
        {

            int doctorID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_AddNewDoctor", connection))
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
                    command.Parameters.AddWithValue("@Specialization", specialization);

                    SqlParameter personIDOutputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(personIDOutputParam);

                    SqlParameter doctorIDOutputParam = new SqlParameter("@DoctorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(doctorIDOutputParam);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        personID = (int)personIDOutputParam.Value;
                        doctorID = (int)doctorIDOutputParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }
                }
            }

            return doctorID;
        }


        public static bool DeleteDoctor(int personID)
        {
            bool isDeleted = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("sp_DeleteDoctor", connection))
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
                            clsDataAccessSettings.LogEvent(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.LogEvent(ex.Message);
                }
            }

            return isDeleted;
        }
    }
}
