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

namespace Clinica.Doctors.Controls
{
    public partial class ctrlDoctorCard : UserControl
    {
        public ctrlDoctorCard()
        {
            InitializeComponent();
        }


        public void LoadDoctorInfo(int doctorID) {

            clsDoctor doctor = clsDoctor.Find(doctorID);

            if (doctor == null) return;

            lblDrFirstLastName.Text = doctor.FirstName + " " + doctor.LastName;
            lblSpecialization.Text = doctor.Specialization;
            lblEmail.Text = doctor.Email;
            lblPhoneNumber.Text = doctor.Phone;
        }
    }
}
