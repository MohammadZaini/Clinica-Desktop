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
    public class Patient
    {
        private enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode = Mode.AddNew;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }


        public Patient(int patientID, int personID) { 
            ID = patientID;
            PersonID = personID;
            Person = Person.Find(personID);

            _mode = Mode.Update;
        }

        public static Patient Find(int patientID)
        {
            int personID = -1;


            if (PatientData.FindPatientInfoByID(patientID, ref personID))

                return new Patient(patientID,personID);
            else
                return null;
        }

        private bool _AddNewPatient()
        {

            this.ID = PatientData.AddNewPatient(PersonID);

            return (this.ID != -1); // -1 means the patient has not been added
        }

        private bool _UpdatePatient()
        {
            return true;
        }
        public bool Save()
        {

            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNewPatient())
                    {
                        _mode = Mode.Update;
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

    }
}
