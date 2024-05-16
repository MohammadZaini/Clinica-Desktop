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
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _mode = enMode.AddNew;

        private clsPatient _patient;
        private clsDoctor _doctor;
        private clsUser _user;

        public ctrlAddEditPerson()
        {
            InitializeComponent();
        }

        public string ModeTitle { 
            get { return lblPerson.Text; } 
            set { lblPerson.Text = value; } 
        }

        public bool IsSpecializationVisible {
            set { gbSpecialization.Visible = value; }
        }

        private void _PreparePatientObject()
        {
            if(_mode == enMode.AddNew)
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
            if(_mode == enMode.AddNew)
                _doctor = new clsDoctor();

            _doctor.FirstName = txtFirstName.Text.Trim();
            _doctor.SecondName = txtSecondName.Text.Trim();
            _doctor.ThirdName = txtThirdName.Text.Trim();
            _doctor.LastName = txtLastName.Text.Trim();
            _doctor.Email = txtEmail.Text.Trim();
            _doctor.Phone = txtPhoneNumber.Text.Trim();
            _doctor.Address = txtAddress.Text.Trim();
            _doctor.Specialization = txtSpecialization.Text.Trim();
            _doctor.DateOfBirth = dtpBirthDate.Value;
            _doctor.Gender = rbMale.Checked ? (byte)0 : (byte)1;
        }

        public void _LoadPatientData(int patientID) {

            gbSpecialization.Visible = false;
            _mode = enMode.Update;

            _patient = clsPatient.Find(patientID);

            if (_patient == null) return;

            byte gender = _patient.Gender;

            txtFirstName.Text = _patient.FirstName;
            txtSecondName.Text = _patient.SecondName;
            txtThirdName.Text = _patient.ThirdName;
            txtLastName.Text = _patient.LastName;
            txtEmail.Text = _patient.Email;
            txtPhoneNumber.Text = _patient.Phone;
            dtpBirthDate.Value = _patient.DateOfBirth;
            txtAddress.Text = _patient.Address;
            lblID.Visible = true;
            lblID.Text = "ID: " + _patient.PatientID.ToString();

            if (gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }

        public void _LoadDoctorData(int doctorID)
        {
            gbSpecialization.Visible = true;
            _mode = enMode.Update;

            _doctor = clsDoctor.Find(doctorID);

            if (_doctor == null) return;

            byte gender = _doctor.Gender;

            txtFirstName.Text = _doctor.FirstName;
            txtSecondName.Text = _doctor.SecondName;
            txtThirdName.Text = _doctor.ThirdName;
            txtLastName.Text = _doctor.LastName;
            txtEmail.Text = _doctor.Email;
            txtPhoneNumber.Text = _doctor.Phone;
            dtpBirthDate.Value = _doctor.DateOfBirth;
            txtAddress.Text = _doctor.Address;
            txtSpecialization.Text = _doctor.Specialization;
            lblID.Visible = true;
            lblID.Text = "ID: " + _doctor.DoctorID.ToString();

            if (gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            { 
                MessageBox.Show("Please fill all the mandatory fields", "Error", MessageBoxButtons.OK);
                return;
            }

            _SavePerson();
        }

        private void _SavePerson() {

            switch (personType)
            { 
                case clsPerson.PersonType.Patient:

                    _PreparePatientObject();
                    if (_patient.Save())
                    {
                        _UpdateUI(_patient.PatientID);
                        MessageBox.Show("Patient's Data has been Saved!", "Success", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);

                    break;
                case clsPerson.PersonType.Doctor:

                     _PrepareDoctorObject();

                    if (_doctor.Save())
                    {
                        _UpdateUI(_doctor.DoctorID);
                        MessageBox.Show("Doctor's Data has been Saved!", "Success", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);

                    break;
                case clsPerson.PersonType.User:
                    if (_user.Save())
                    {
                        _UpdateUI(_user.ID);
                        MessageBox.Show("User's Data has been Saved!", "Success", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);

                    break;
                default:
                    break;
            }
        }

        private void _UpdateUI(int personID) {

            _mode = enMode.Update;
            lblPerson.Text = "Update Info";
            lblID.Text = "ID: " + personID.ToString();
            lblID.Visible = true;
        }
    }
}
