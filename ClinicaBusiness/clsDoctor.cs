using Clinica_Business;
using Clinica_DataAccess;
using System;
using System.Collections.Generic;
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

        private clsDoctor(int doctorID, int personID, string specialization)
        {
            DoctorID = doctorID;       
            Specialization = specialization;
            Person = clsPerson.Find(personID);

            _mode = Mode.Update;

        }

        public static new clsDoctor Find(int doctorID) {

            int personID = -1; 
            string specialization = "";

            if (clsDoctorData.GetDoctorInfoByID(doctorID, ref personID, ref specialization))
            {
                return new clsDoctor(doctorID, personID, specialization);
            }
            else
                return null;
        }

        private bool _AddNewDoctor() {

            this.DoctorID = clsDoctorData.AddNewDoctor(this.PersonID, this.Specialization);

            return DoctorID != -1;
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
    }
}
