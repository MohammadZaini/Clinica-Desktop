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
        public frmAddUpdatePatient()
        {
            InitializeComponent();

            ctrlAddEditPerson1.personType = clsPerson.PersonType.Doctor;
        }

        public frmAddUpdatePatient(bool isPatient)
        {
            InitializeComponent();

            if (isPatient)
            { 
                ctrlAddEditPerson1.HideSpecialization = false;
                ctrlAddEditPerson1.personType = clsPerson.PersonType.Patient;
            }

            clsPatient patient = clsPatient.Find(3);
            patient.FirstName = "koko";

            if (patient.Save())
                MessageBox.Show("The patient data has been updated successfully");
            else
                MessageBox.Show("something went wrong :-(");

        }

    }
}
