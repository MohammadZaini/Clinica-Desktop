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
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            clsDoctor doctor = clsDoctor.Find(1);

            if (doctor != null)
            {
                MessageBox.Show(doctor.Person.DateOfBirth.ToString());
            }
        }
    }
}
