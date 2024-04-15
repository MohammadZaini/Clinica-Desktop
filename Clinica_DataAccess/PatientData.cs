using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class PatientData
    {

        public static int AddNewPatient(int personID)
        {

            int patientID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Insert Into Patients 
                                 Values (@personID);
                                 SELECT SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personID", personID);
      
                try
                {
                    connection.Open();

                    object id = command.ExecuteScalar();

                    if (id != null && int.TryParse(id.ToString(), out int insertedPersonID))
                        patientID = insertedPersonID;

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return patientID;
        }

        public static bool FindPatientInfoByID(int patientID, ref int personID)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Select * From Patients                              
                                 Where patientID = @patientID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patientID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            personID = (int)reader["PersonID"];
                        }
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return isFound;
        }
    }
}