using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class UserData
    {

        public static DataTable GetAllUsers() { 

            DataTable usersDt = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString)) {

                string spGetAllUsersName = "GetAllUsers";

                using (SqlCommand command = new SqlCommand(spGetAllUsersName, connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                            usersDt.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        DataAccessSettings.LogEvent(ex.Message);
                    }
           
                }                   
            }

            return usersDt;       
        }

        public static bool GetUserInfoByID(int userID, ref int clsPersonID ,ref string username, ref string password,
            ref bool isActive) {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString)) {

                using (SqlCommand command = new SqlCommand("GetUserInfoByID", connection)) {


                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {

                            isFound = true;

                            clsPersonID = (int)reader["clsPersonID"];
                            username = (string)reader["Username"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];

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

        public static int AddNewUser(int clsPersonID, string username, string password,
            bool isActive)
        {

            int userID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString)) {

                using (SqlCommand command = new SqlCommand("sp_AddNewUser", connection)) {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@clsPersonID", clsPersonID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@isActive", isActive);


                    SqlParameter outputParameter = new SqlParameter("@UserID", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        userID = (int)outputParameter.Value;
                    }
                    catch (Exception ex)
                    {
                        DataAccessSettings.LogEvent(ex.Message);
                    }          
                }
            }

            return userID;
        }
    }
}
