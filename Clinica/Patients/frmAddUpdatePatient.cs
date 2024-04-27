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
        }

        public frmAddUpdatePatient(bool isPatient)
        {
            InitializeComponent();

            if(isPatient)
                ctrlAddEditPerson1.HideSpecialization = false;
        }
       
    }
}
