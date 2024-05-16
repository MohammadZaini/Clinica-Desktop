using Clinica_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Business
{
    public class clsPerson
    {
        public enum PersonType { Patient = 0, Doctor = 1, User = 2 };

        protected enum Mode { AddNew = 0, Update = 1 }
        protected Mode mode = Mode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }


        public clsPerson() {
            PersonID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Phone = string.Empty;
            Email = string.Empty;
            Address = string.Empty;

            mode = Mode.AddNew;
        }

        protected clsPerson(int personID, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth,
        byte gender, string phone, string email, string address) { 
            
            this.PersonID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;

            mode = Mode.Update;
        }

        public static clsPerson Find(int clsPersonID) {
            string firstName = "", secondName = "", thirdName = "", lastName = "", phone = "",
                email = "", address = "";
            DateTime dateOfBirth = DateTime.Now;
            byte gender = 0;


            if (clsPersonData.FindPersonInfoByID(clsPersonID, ref firstName, ref secondName, ref thirdName, ref lastName,
               ref dateOfBirth, ref gender, ref phone, ref email, ref address))

                return new clsPerson(clsPersonID, firstName, secondName, thirdName, lastName,
                 dateOfBirth, gender, phone, email, address);
            else
                return null;
        }

        private bool _AddNewPerson() {

            this.PersonID = clsPersonData.AddNewPerson(FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                Gender, Phone, Email, Address);

            return (this.PersonID != -1); // -1 means the clsPerson has not been added
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, 
                Gender, Phone, Email, Address);
        }

        public bool Save() {

            switch (mode)
            {
                case Mode.AddNew:
                    if (_AddNewPerson())
                    {
                        mode = Mode.Update;
                        return true;
                    }
                    return false;

                case Mode.Update:
                    return _UpdatePerson();

                default:
                    break;
            }

            return false;
        }

        public bool Delete() { 
        
            return clsPersonData.DeletePerson(PersonID);
        }

    }
}