using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class clsPatientData
    {

        public static int AddNewPatient(int personID)
        {

            int patientID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Insert Into Patients 
                                 Values (@PersonID);
                                 SELECT SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personID);
      
                try
                {
                    connection.Open();

                    object id = command.ExecuteScalar();

                    if (id != null && int.TryParse(id.ToString(), out int insertedPersonID))
                        patientID = insertedPersonID;

                }
                catch (Exception ex)
                {
                    DataAccessSettings.LogEvent(ex.Message);
                }

            }

            return patientID;
        }

        public static bool FindPatientInfoByID(int clsPatientID, ref int clsPersonID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Select * From Patients                              
                                 Where clsPatientID = @clsPatientID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@clsPatientID", clsPatientID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            clsPersonID = (int)reader["clsPersonID"];
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
    }
}