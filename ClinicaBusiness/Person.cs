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
    public class Person
    {
        private enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode = Mode.AddNew;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public Person() {
            ID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 0;
            Phone = string.Empty;
            Email = string.Empty;
            Address = string.Empty;

            _mode = Mode.AddNew;
        }

        private Person(int personID, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth,
        byte gender, string phone, string email, string address) { 
            
            this.ID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;

            _mode = Mode.Update;
        }

        public static Person Find(int personID) {
            string firstName = "", secondName = "", thirdName = "", lastName = "", phone = "",
                email = "", address = "";
            DateTime dateOfBirth = DateTime.MinValue;
            byte gender = 0;


            if (PersonData.FindPersonInfoByID(personID, ref firstName, ref secondName, ref thirdName, ref lastName,
               ref dateOfBirth, ref gender, ref phone, ref email, ref address))

                return new Person(personID, firstName, secondName, thirdName, lastName,
                 dateOfBirth, gender, phone, email, address);
            else
                return null;
        }

        private bool _AddNewPerson() {

            this.ID = PersonData.AddNewPerson(FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                Gender, Phone, Email, Address);

            return (this.ID != -1); // -1 means the person has not been added
        }

        private bool _UpdatePerson()
        {
            return PersonData.UpdatePerson(ID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, 
                Gender, Phone, Email, Address);
        }
        public bool Save() {

            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNewPerson())
                    {
                        _mode = Mode.Update;
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

    }
}