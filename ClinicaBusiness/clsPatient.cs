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
    public class clsPatient : clsPerson
    {
        private enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode = Mode.AddNew;
        public int PatientID { get; set; }

        public clsPatient(int clsPatientID, int PersonID) { 
            PatientID = clsPatientID;
            this.PersonID = PersonID;

            _mode = Mode.Update;
        }

        public clsPatient()
        {
            PatientID = -1;
            _mode = Mode.AddNew;
        }

        public static clsPatient Find(int patientID)
        {
            int personID = -1;

            if (clsPatientData.FindPatientInfoByID(patientID, ref personID))
                return new clsPatient(patientID, personID);
            else
                return null;
        }

        private bool _AddNewPatient()
        {
            if (base.Save())
                this.PatientID = clsPatientData.AddNewPatient(PersonID);
            else
                return false;


            return (this.PatientID != -1); // -1 means the Patient has not been added
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
