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

namespace Clinica.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {

        public int PersonID;
        public int PatientID;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }


        public bool LoadPersonInfo(string firstName, string lastName) { 
        
            bool isFound = false;

            clsPatient patient = clsPatient.Find(firstName, lastName);

            if (patient == null) return false;

            isFound = true;

            PersonID = patient.PersonID;
            PatientID = patient.PatientID;

            lblFirstName.Text = patient.FirstName;
            lblSecondName.Text = patient.SecondName;
            lblThirdName.Text = patient.ThirdName;
            lblLastName.Text = patient.LastName;
            lblDateOfBirth.Text = patient.DateOfBirth.ToString();
            lblEmail.Text = patient.Email;
            lblPhoneNumber.Text = patient.Phone;
            lblAddress.Text = patient.Address;

            return isFound;
        }

    }
}
