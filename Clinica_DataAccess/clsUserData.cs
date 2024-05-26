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
    public class clsUserData
    {

        public static DataTable GetAllUsers() { 

            DataTable usersDt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {

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
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }
           
                }                   
            }

            return usersDt;       
        }

        public static bool GetUserInfoByID(int userID, ref int personID ,ref string username, ref string password,
            ref bool isActive) {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {

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

                            personID = (int)reader["PersonID"];
                            username = (string)reader["Username"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];

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


        public static bool GetUserInfoByUsername(string username, ref int userID, ref int personID, ref string password,
            ref bool isActive)
        {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("GetUserInfoByUsername", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            isFound = true;

                            personID = (int)reader["PersonID"];
                            userID = (int)reader["UserID"];
                            password = (string)reader["Password"];
                            isActive = (bool)reader["IsActive"];

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

        public static int AddNewUser(ref int personID, string firstName, string secondName, string thirdName,
             string lastName, DateTime dateOfBirth, byte gender, string phoneNumber,
             string email, string address, string username, string password,
            bool isActive)
        {

            int userID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) {

                using (SqlCommand command = new SqlCommand("sp_AddNewUser", connection)) {

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

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@isActive", isActive);


                    SqlParameter personIDOutputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(personIDOutputParam);

                    SqlParameter userIDOutputParam = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userIDOutputParam);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        personID = (int)personIDOutputParam.Value;
                        userID = (int)userIDOutputParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.LogEvent(ex.Message);
                    }          
                }
            }

            return userID;
        }
    }
}
