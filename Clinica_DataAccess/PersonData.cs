using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    public class PersonData
    {
        public static int AddNewPerson(string firstName, string secondName, string thirdName, 
             string lastName, DateTime dateOfBirth, byte gender, string phoneNumber, 
             string email, string address) { 
            
            int personID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Insert Into People 
                                 Values ( @firstName, @secondName, @thirdName, @lastName, @dateOfBirth,
                                 @gender, @phoneNumber, @email, @address);
                                 SELECT SCOPE_IDENTITY();";
                                                        

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@secondName", secondName);
                command.Parameters.AddWithValue("@thirdName", thirdName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@address", address);

                try
                {
                    connection.Open();

                    object id = command.ExecuteScalar(); 

                    if(id != null && int.TryParse(id.ToString(), out int insertedPersonID))
                        personID = insertedPersonID;

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return personID;
        }

        public static bool UpdatePerson(int personID, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gender, string phoneNumber,
            string email, string address)
        {

            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Update People 
                                 Set FirstName = @firstName,
                                 SecondName = @secondName,
                                 ThirdName = @thirdName, LastName = @lastName, DateOfBirth = @dateOfBirth, 
                                 Gender = @gender, PhoneNumber = @phoneNumber,
                                 Email = @email, Address = @address
                                 Where PersonID = @personID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@secondName", secondName);
                command.Parameters.AddWithValue("@thirdName", thirdName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@gender", gender);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@personID", personID);

                try
                {
                    connection.Open();

                    int affectedRows = command.ExecuteNonQuery();

                    if(affectedRows > 0)
                        isUpdated = true;

                }
                catch (Exception)
                {

                    throw;
                }

            }

            return isUpdated;
        }

        public static bool FindPersonInfoByID(int personID, ref string firstName, ref string secondName, 
            ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte gender, 
            ref string phoneNumber, ref string email, ref string address) {

            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"Select * From People                              
                                 Where PersonID = @personID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personID", personID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            firstName = (string)reader["FirstName"];
                            secondName = (string)reader["SecondName"];
                            thirdName = (string)reader["ThirdName"];
                            lastName = (string)reader["LastName"];
                            dateOfBirth = (DateTime)reader["DateOfBirth"];
                            gender = (byte)reader["Gender"];
                            phoneNumber = (string)reader["PhoneNumber"];
                            email = (string)reader["Email"];
                            address = (string)reader["Address"];
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
