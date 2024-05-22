using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinica_Business;
using ClinicaBusiness;
using static Clinica.People.ctrlAddEditPerson;

namespace Clinica.Doctors
{
    public partial class frmAddUpdateDoctor : Form
    {
        private int _doctorID;
        public frmAddUpdateDoctor()
        {
            InitializeComponent();

            _AddNewDoctorMode();
        }

        public frmAddUpdateDoctor(int doctorID)
        {
            InitializeComponent();
            _doctorID = doctorID;
            _UpdateDoctorMode(doctorID);
        }

        private void _UpdateDoctorMode(int doctorID)
        {
            ctrlAddEditPerson1.ModeTitle = "Update Doctor";
            ctrlAddEditPerson1.LoadPersonData<clsDoctor>(doctorID);
        }
        private void _AddNewDoctorMode() { 
        
            ctrlAddEditPerson1.IsSpecializationVisible = true;
            ctrlAddEditPerson1.ModeTitle = "Doctor";
            ctrlAddEditPerson1.SetPersonType<clsDoctor>();
        }
    }
}
