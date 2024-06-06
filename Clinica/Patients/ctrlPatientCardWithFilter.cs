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
    public partial class ctrlPatientCardWithFilter : UserControl
    {

        public int PersonID;
        public int PatientID;

        public ctrlPatientCardWithFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isPatientExist = ctrlPersonCard1.LoadPersonInfo(txtFirstName.Text.Trim(), txtLastName.Text.Trim());

            if (!isPatientExist)
            {
                DialogResult dialogResult = clsUtility.ShowConfirmationMessage("Do you want to add a new patient?", "Add New Patient");

                if (dialogResult == DialogResult.Yes)
                {           
                    frmAddUpdatePatient addNewPatient = new frmAddUpdatePatient();
                    addNewPatient.ShowDialog();
                }
                return;
            }

            PersonID = ctrlPersonCard1.PersonID;
            PatientID = ctrlPersonCard1.PatientID;

            ctrlPersonCard1.Visible = true;
        }
    }
}
