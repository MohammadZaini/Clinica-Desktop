using Clinica_Business;
using ClinicaBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica.People
{
    public partial class ctrlAddEditPerson : UserControl
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _mode = enMode.AddNew;

        private dynamic _dynamicPerson;

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

            _PreparePersonObject();
            if (_dynamicPerson.Save())
            {
                 _UpdateUI(_GetPersonIDBasedOnType());           
                MessageBox.Show("Data has been Saved!", "Success", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
        }

        private void _UpdateUI(int personID) {

            _mode = enMode.Update;
            lblPerson.Text = "Update Info";
            lblID.Text = "ID: " + personID.ToString();
            lblID.Visible = true;
        }

        public void SetPersonType<T>() where T : new()
        {

            _dynamicPerson = new T();

            if (_mode == enMode.AddNew)
                if (_dynamicPerson is clsPatient)
                    _dynamicPerson = new clsPatient();
                else if (_dynamicPerson is clsDoctor)
                {
                    _dynamicPerson = new clsDoctor();
                }
                else if (_dynamicPerson is clsUser)
                {
                    _dynamicPerson = new clsUser();
                    _SetForUserMode();
                }
        }

        private void _PreparePersonObject() {

            _dynamicPerson.FirstName = txtFirstName.Text.Trim();
            _dynamicPerson.SecondName = txtSecondName.Text.Trim();
            _dynamicPerson.ThirdName = txtThirdName.Text.Trim();
            _dynamicPerson.LastName = txtLastName.Text.Trim();
            _dynamicPerson.Email = txtEmail.Text.Trim();
            _dynamicPerson.Phone = txtPhoneNumber.Text.Trim();
            _dynamicPerson.Address = txtAddress.Text.Trim();
            _dynamicPerson.DateOfBirth = dtpBirthDate.Value;
            _dynamicPerson.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            if (_dynamicPerson is clsDoctor)
                _dynamicPerson.Specialization = txtSpecialization.Text.Trim();

            if (_dynamicPerson is clsUser) {

                _dynamicPerson.Username = txtUsername.Text.Trim();
                _dynamicPerson.Password = txtPassword.Text.Trim();
                _dynamicPerson.IsActive = rbActive.Checked ? true : false;
            }

        }

        private int _GetPersonIDBasedOnType() {

            if (_dynamicPerson is clsPatient)
                return _dynamicPerson.PatientID;
            else if (_dynamicPerson is clsDoctor)
            {
                return _dynamicPerson.DoctorID;
            }
            else if (_dynamicPerson is clsUser)
                return _dynamicPerson.ID;

            return -1;
        }

        public void LoadPersonData<T>(int personID) {

            _mode = enMode.Update;

            MethodInfo find = _FindPersonMethodInfo<T>();
            if (find == null)
            {
                throw new InvalidOperationException($"The type {typeof(T).Name} does not have a public static Find method.");
            }
                 
            _dynamicPerson = find.Invoke(null, new object[] { personID });

            if (_dynamicPerson == null) return;

            if (_dynamicPerson is clsDoctor)
                txtSpecialization.Text = _dynamicPerson.Specialization;

            byte gender = _dynamicPerson.Gender;

            txtFirstName.Text = _dynamicPerson.FirstName;
            txtSecondName.Text = _dynamicPerson.SecondName;
            txtThirdName.Text = _dynamicPerson.ThirdName;
            txtLastName.Text = _dynamicPerson.LastName;
            txtEmail.Text = _dynamicPerson.Email;
            txtPhoneNumber.Text = _dynamicPerson.Phone;
            dtpBirthDate.Value = _dynamicPerson.DateOfBirth;
            txtAddress.Text = _dynamicPerson.Address;

            lblID.Visible = true;
            lblID.Text = "ID: " + _GetPersonIDBasedOnType().ToString();

            if (gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }

        private MethodInfo _FindPersonMethodInfo<T>() {
          return typeof(T).GetMethod("Find", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        }

        private void _SetForUserMode() {

            userPanel.Visible = true;
            gbIsActive.Visible = true;
        }
    }
}