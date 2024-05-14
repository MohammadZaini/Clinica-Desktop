using Clinica_Business;
using ClinicaBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica.People
{
    public partial class ctrlAddEditPerson : UserControl
    {

        public clsPerson.PersonType personType = clsPerson.PersonType.Patient;

        private clsPatient _patient;
        private clsDoctor _doctor;

        public ctrlAddEditPerson()
        {
            InitializeComponent();
        }

        public bool HideSpecialization {
            set { gbSpecialization.Visible = value; }
        }

        private void _PreparePatientObject()
        {
            _patient = new clsPatient();

            _patient.FirstName = txtFirstName.Text.Trim();
            _patient.SecondName = txtSecondName.Text.Trim();
            _patient.ThirdName = txtThirdName.Text.Trim();
            _patient.LastName = txtLastName.Text.Trim();
            _patient.Email = txtEmail.Text.Trim();
            _patient.Phone = txtPhoneNumber.Text.Trim();
            _patient.Address = txtAddress.Text.Trim();
            _patient.DateOfBirth = dtpBirthDate.Value;
            _patient.Gender = rbMale.Checked ? (byte)0 : (byte)1;
        }

        private void _PrepareDoctorObject()
        {
            _doctor = new clsDoctor();
            _doctor.FirstName = txtFirstName.Text.Trim();
            _doctor.LastName = txtLastName.Text.Trim();
            _doctor.Email = txtEmail.Text.Trim();
            _doctor.Phone = txtPhoneNumber.Text.Trim();
            _doctor.Address = txtAddress.Text.Trim();
            _doctor.Specialization = txtSpecialization.Text.Trim();
            _doctor.DateOfBirth = dtpBirthDate.Value;
            _doctor.Gender = rbMale.Checked ? (byte)0 : (byte)1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            { 
                MessageBox.Show("Please fill all the mandatory fields", "Error", MessageBoxButtons.OK);
                return;
            }

            if (personType == clsPerson.PersonType.Patient)
            {
                _PreparePatientObject();

                if (_patient.Save())
                    MessageBox.Show("Patient has been added!", "Success", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
            }
            else if (personType == clsPerson.PersonType.Doctor)
            {
                _PrepareDoctorObject();

                if (_doctor.Save())
                    MessageBox.Show("Doctor has been added!", "Success", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
