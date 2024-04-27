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
    public class clsUser
    {

        enum Mode { AddNew = 0, Update = 1 };
        private Mode _mode = Mode.AddNew;

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int clsPersonID { get; set; }
        public clsPerson clsPerson { get; set; }

        public clsUser() { 
            ID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
            clsPersonID = -1;
            clsPerson = null;

            _mode = Mode.AddNew;
        }

        private clsUser(int userID, int clsPersonID, string username, string password, bool isActive) { 
        
            ID = userID;
            Username= username;
            Password= password;
            IsActive = isActive;
            clsPersonID = clsPersonID;

            clsPerson = clsPerson.Find(clsPersonID);

            _mode = Mode.Update;

        }

        public static DataTable GetAllUsers() { 
        
            return UserData.GetAllUsers();
        }

        public static clsUser Find(int userID) {

            int clsPersonID = -1;
            string username = "", passowrd = "";
            bool isActive = false;

            if (UserData.GetUserInfoByID(userID, ref clsPersonID, ref username, ref passowrd, ref isActive))
                return new clsUser(userID, clsPersonID, username, passowrd, isActive);
            else
                return null;
        }

        private bool _AddNewUser() {

            ID = UserData.AddNewUser(clsPersonID, Username, Password, IsActive);

            return ID != -1; // other than -1 means that the user has been inserted successfully

        }

        private bool _UpdateUser()
        {
            return false;
        }

        public bool Save() {

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
