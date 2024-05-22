using Clinica_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica.Patients
{
    public partial class frmAddUpdatePatient : Form
    {

        private enum enMode { Addnew = 0, Update = 1}
        private enMode _mode = enMode.Addnew;
        private clsPatient _patient;

        public frmAddUpdatePatient()
        {
            InitializeComponent();

            _AddNewPatientMode();
        }

        public frmAddUpdatePatient(int patientID)
        {
            InitializeComponent();

            _UpdatePatientMode(patientID);
        }

        private void _UpdatePatientMode(int patientID) {

            _mode = enMode.Update;
            _patient = clsPatient.Find(patientID);
            ctrlAddEditPerson1.ModeTitle = "Update Patient";
            ctrlAddEditPerson1._LoadPatientData(patientID);           
        }

        private void _AddNewPatientMode()
        {
            _mode = enMode.Addnew;
            _patient = new clsPatient();
            ctrlAddEditPerson1.IsSpecializationVisible = false;
            ctrlAddEditPerson1.SetPersonType<clsPatient>();
            ctrlAddEditPerson1.LoadPersonData<clsPatient>(2);
        }

    }
}