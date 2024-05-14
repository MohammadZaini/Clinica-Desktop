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
        public static bool GetDoctorInfoByID(int doctorID, ref int personID, ref string specialization) { 
            
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
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
                        DataAccessSettings.LogEvent(ex.Message);
                    }
                }

            }

            return isFound;
        }

        public static int AddNewDoctor(int personID, string specialization) {

            int doctorID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("sp_AddNewDoctor", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@@Specialization", specialization);


                    SqlParameter outputParameter = new SqlParameter("@DoctorID", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        doctorID = (int)outputParameter.Value;
                    }
                    catch (Exception ex)
                    {
                        DataAccessSettings.LogEvent(ex.Message);
                    }
                }
            }

            return doctorID;
        }
    }
}
