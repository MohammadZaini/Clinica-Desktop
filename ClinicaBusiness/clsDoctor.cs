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
    public class clsDoctor : clsPerson
    {
        enum Mode { AddNew = 0, Update = 1 }

        private Mode _mode = Mode.AddNew;

        public int DoctorID {get; set;}
        public string Specialization {get; set; }

        public clsPerson Person { get; set;}

        public clsDoctor()
        {
            DoctorID = -1;
            Specialization = string.Empty;
            _mode = Mode.AddNew;       
        }

        private clsDoctor(int doctorID, int personID, string firstName, string secondName, string thirdName, 
            string lastName, DateTime dateOfBirth, byte gender, string phone, string email, string address,
            string specialization) : base(personID, firstName, secondName, thirdName, lastName, dateOfBirth, 
                gender, phone, email, address)
        {
            DoctorID = doctorID;       
            Specialization = specialization;
            _mode = Mode.Update;
        }

        public static new clsDoctor Find(int doctorID) {

            int personID = -1; 
            string specialization = "";

            if (clsDoctorData.GetDoctorInfoByID(doctorID, ref personID, ref specialization))
            {
                clsPerson person = clsPerson.Find(personID);
                return new clsDoctor(doctorID, personID, person.FirstName, person.SecondName, person.ThirdName,
                    person.LastName, person.DateOfBirth, person.Gender, person.Phone, person.Email, person.Address, specialization);
            }
            else
                return null;
        }

        private bool _AddNewDoctor() {

            int personID = 0;
            this.DoctorID = clsDoctorData.AddNewDoctor(ref personID, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, Gender, Phone, Email, Address, Specialization);

            this.PersonID = personID;

            return (this.DoctorID != -1);
        }

        private bool _UpdateDoctor()
        {
            return base.Save();
        }
        
        public new bool Save() {
            
            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNewDoctor())
                    {
                        _mode = Mode.Update;
                        return true;
                    }
                    else
                        return false;
                case Mode.Update:
                    return _UpdateDoctor();
                default:
                    return false;
            }
        }

        public static DataTable GetAllDoctors() {

            return clsDoctorData.GetAllDoctors();
        }


        public new bool Delete() {

            return DeleteDoctor(PersonID);
        }

        public static bool DeleteDoctor(int personID) {
        
            return clsDoctorData.DeleteDoctor(personID);
        }
    }
}
