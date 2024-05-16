using Clinica.Patients;
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

namespace Clinica.Doctors
{
    public partial class frmManageDoctors : Form
    {
        public frmManageDoctors()
        {
            InitializeComponent();
        }

        private void _ListDoctors() {     
            dgvDoctors.DataSource = clsDoctor.GetAllDoctors();
        }
        private void frmManageDoctors_Load(object sender, EventArgs e)
        {
            _ListDoctors();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor addDoctor = new frmAddUpdateDoctor();
            addDoctor.ShowDialog();
            _ListDoctors();
        }

        private void deleteDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete this doctor?", "Deleting Doctor", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {                                     // personID
                if (clsDoctor.DeleteDoctor((int)dgvDoctors.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The doctor has been deleted!", "Success", MessageBoxButtons.OK);
                    frmManageDoctors_Load(null, null);
                }
                else
                    MessageBox.Show("Something went wrong!", "Failure", MessageBoxButtons.OK);
            }
        }

        private void doctorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor updateDoctorData = new frmAddUpdateDoctor(3);
            updateDoctorData.ShowDialog();
        }

        private void dgvDoctors_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            _UpdateRowsColor(e);
        }

        private void _UpdateRowsColor(DataGridViewRowPrePaintEventArgs e) {
            if (e.RowIndex % 2 == 0)
            {
                // Set the background color of the row
                dgvDoctors.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            else
            {
                // Set the default background color of the row
                dgvDoctors.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvDoctors.DefaultCellStyle.BackColor;
            }
        }
    }
}
