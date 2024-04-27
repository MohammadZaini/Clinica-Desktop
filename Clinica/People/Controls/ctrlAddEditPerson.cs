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

namespace Clinica.People
{
    public partial class ctrlAddEditPerson : UserControl
    {


        private clsPatient _patient;

        public ctrlAddEditPerson()
        {
            InitializeComponent();
        }

        public bool HideSpecialization {
            set { gbSpecialization.Visible = value; }
        }

        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {

        }

        private void _PreparePatientObject()
        {
            _patient = new clsPatient();

            _patient.FirstName = txtFirstName.Text;
            _patient.LastName = txtLastName.Text;
            _patient.Email = txtEmail.Text;
            _patient.Phone = txtPhoneNumber.Text;
            _patient.Address = txtAddress.Text;
            _patient.DateOfBirth = dtpBirthDate.Value;
            _patient.Gender = rbMale.Checked ? (byte)0 : (byte)1;
        }

        private void _PrepareDoctorObject()
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            { 
                MessageBox.Show("Please fill all the mandatory fields", "Error", MessageBoxButtons.OK);
                return;
            }

            _PreparePatientObject();

            if (_patient.Save())
                MessageBox.Show("Patient has been added!", "Success", MessageBoxButtons.OK);
            else
                MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);

        }
    }
}
