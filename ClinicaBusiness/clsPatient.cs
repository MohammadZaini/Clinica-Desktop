using Clinica_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Business
{
    public class clsPatient : clsPerson
    {
        private new enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode = Mode.AddNew;
        public int PatientID { get; set; }

        private clsPatient(int patientID, int personID, string firstName, string secondName, string thirdName, 
            string lastName, DateTime dateOfBirth, byte gender, string phone, string email, string address) 
            : base (personID, firstName, secondName, thirdName, lastName, dateOfBirth, gender, phone,
                  email, address) 
        { 
            PatientID = patientID;
            _mode = Mode.Update;
            base.mode = clsPerson.Mode.Update;
        }

        public clsPatient()
        {
            PatientID = -1;
            _mode = Mode.AddNew;
        }

        public static DataTable GetAllPatients() { 
        
            return clsPatientData.GetAllPatients();
        }

        public static new clsPatient Find(int patientID)
        {
            int personID = -1;

            if (clsPatientData.FindPatientInfoByID(patientID, ref personID))
            {
                clsPerson person = clsPerson.Find(personID);

                if(person == null) return null;

                return new clsPatient(patientID, personID, person.FirstName, person.SecondName, person.ThirdName,
                    person.LastName, person.DateOfBirth, person.Gender, person.Phone, person.Email, person.Address);
            }         
            else
                return null;
        }

        private bool _AddNewPatient()
        {
            int personID = 0;
            this.PatientID = clsPatientData.AddNewPatient(ref personID, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, Gender, Phone,Email,Address);

            this.PersonID = personID;

            return (this.PatientID != -1); // -1 means the Patient has not been added
        }

        private bool _UpdatePatient()
        {
            return base.Save();
        }

        public new bool Save()
        {
            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNewPatient())
                    {
                        _mode = Mode.Update;
                        base.mode = clsPerson.Mode.Update;

                        return true;
                    }
                    return false;

                case Mode.Update:
                    return _UpdatePatient();

                default:
                    break;
            }

            return false;
        }

        public new bool Delete() { 
            return DeletePatient(this.PersonID);
        }

        public static bool DeletePatient(int personID) {

            return clsPatientData.DeletePatient(personID);
        }

    }
}