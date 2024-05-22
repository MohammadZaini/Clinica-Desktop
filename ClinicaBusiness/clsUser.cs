using Clinica_Business;
using Clinica_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaBusiness
{
    public class clsUser: clsPerson
    {

        new enum Mode { AddNew = 0, Update = 1 };
        private Mode _mode = Mode.AddNew;

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser() { 
            ID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
            PersonID = -1;

            _mode = Mode.AddNew;
        }

        private clsUser(int userID, int personID, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gender, string phone, string email, string address,
             string username, string password, bool isActive)
            : base(personID, firstName, secondName, thirdName, lastName, dateOfBirth, gender, phone,
                  email, address) { 
        
            ID = userID;
            Username= username;
            Password= password;
            IsActive = isActive;

            _mode = Mode.Update;
        }

        public static DataTable GetAllUsers() { 
        
            return UserData.GetAllUsers();
        }

        public new static clsUser Find(int userID) {

            int personID = -1;
            string username = "", passowrd = "";
            bool isActive = false;

            if (UserData.GetUserInfoByID(userID, ref personID, ref username, ref passowrd, ref isActive))
            {
                clsPerson person = clsPerson.Find(personID);

                if (person == null) return null;
 
                return new clsUser(userID, personID, person.FirstName, person.SecondName, person.ThirdName,
                       person.LastName, person.DateOfBirth, person.Gender, person.Phone, person.Email, person.Address, username, passowrd, isActive);
            }
               
            else
                return null;
        }

        private bool _AddNewUser() {

            int personID = 0;
            ID = UserData.AddNewUser(ref personID, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, Gender, Phone, Email, Address, Username, Password, IsActive);

            PersonID = personID;

            return ID != -1; // other than -1 means that the user has been inserted successfully

        }

        private bool _UpdateUser()
        {
            return false;
        }

        public new bool Save() {

            switch (_mode)
            {
                case Mode.AddNew:
                    return _AddNewUser();
                case Mode.Update:
                    if (_UpdateUser())
                    {
                        _mode = Mode.Update;
                        return true;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }

    }
}
