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
    public  class clsAppointment
    {
        public enum AppointStatus {Pending = 0, Confirmed = 1, Completed = 2, Cancelled = 3, Rescheduled = 4,
        NoShow = 5}

        private enum Mode { AddNew = 0, Update = 1}
        private Mode _mode = Mode.AddNew;

        public int AppointmentID { get; private set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointStatus AppointmentStatus { get; set; }
        public int MedicalRecordID { get; set; }
        public int PaymentID { get; set; }
        public int CreatedByUserID { get; set; }
        public int TimeSlotID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public clsDoctor Doctor { get; set; }
        public clsPatient Patient { get; set; }


        public clsAppointment() { 
        }

        private clsAppointment(int appointmentID, int patientID, int doctorID, DateTime appointmentDate, TimeSpan appointmentTime,
                byte appointmentStatus, int medicalRecordID, int paymentID, int createdByUserID) { 
        

            AppointmentID = appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            AppointmentStatus = (AppointStatus)appointmentStatus;
            MedicalRecordID = medicalRecordID;
            PaymentID = paymentID;
            CreatedByUserID = createdByUserID;

            CreatedByUser = clsUser.Find(createdByUserID);
            Doctor = clsDoctor.Find(doctorID);
            Patient = clsPatient.Find(patientID);

            _mode = Mode.Update;

        }

        public static clsAppointment Find(int appointmentID)
        {

            int patientID = -1, doctorID = -1, medicalRecordID = -1, paymentID = -1, createdByUserID = -1;
            DateTime appointmentDate = DateTime.Now;
            TimeSpan appointmentTime = default;
            byte appointmentStatus = 0;

            if (clsAppointmentData.GetAppointmentInfoByID(appointmentID, ref patientID, ref  doctorID, ref appointmentDate, ref appointmentTime,
                ref appointmentStatus, ref medicalRecordID, ref paymentID, ref createdByUserID))
            {
                return new clsAppointment(appointmentID, patientID, doctorID, appointmentDate, appointmentTime, appointmentStatus, 
                    medicalRecordID, paymentID, createdByUserID) ;
            }
            else
                return null;
        }

        public static DataTable GetAllAppointments() {
            return clsAppointmentData.GetAllAppointments();
        }

        private bool _AddNewAppointment() {

            AppointmentID = clsAppointmentData.AddNewAppoinment(PatientID, DoctorID, AppointmentDate, AppointmentTime,
                (byte)AppointmentStatus, MedicalRecordID, PaymentID, CreatedByUserID, TimeSlotID);

            return AppointmentID != -1;
        }

        private bool _UpdateAppointment()
        {
            return clsAppointmentData.UpdateAppointment(AppointmentID, AppointmentDate, AppointmentTime ,(byte)AppointmentStatus);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case Mode.AddNew:
                    if (_AddNewAppointment())
                    {
                        _mode = Mode.Update;
                        return true;
                    }
                    else return false;     
                case Mode.Update:
                    return _UpdateAppointment();
                default:
                    return false;
            }
        }

    }
}