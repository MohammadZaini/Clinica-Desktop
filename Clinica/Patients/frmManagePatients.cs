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
    public partial class frmManagePatients : Form
    {
        public frmManagePatients()
        {
            InitializeComponent();
        }

        private void _ListAllPatients() { 
            dgvPatients.DataSource = clsPatient.GetAllPatients();
        }

        private void frmManagePatients_Load(object sender, EventArgs e)
        {
            _ListAllPatients();
        }

        private void dgvPatients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // e.CellStyle.BackColor = Color.Green;

            //int targetColumnIndex = dgvPatients.Columns["Gender"].Index;
            //DataGridViewCell cell = dgvPatients.Rows[e.RowIndex].Cells[targetColumnIndex];
            //cell.Style.BackColor = Color.LightGreen;
            //
            //if ((string)dgvPatients.CurrentRow.Cells["Gender"].Value == "Male")
            //{
            //    cell.Style.BackColor = Color.LightGreen;
            //}
            //else
            //    cell.Style.BackColor = Color.LightPink;

        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient addUpdatePatient = new frmAddUpdatePatient();
            addUpdatePatient.ShowDialog();
            _ListAllPatients();
        }

        private void patientDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient updatePatientData = new frmAddUpdatePatient(2);
            updatePatientData.ShowDialog();
        }

        private void deletePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
          DialogResult answer = MessageBox.Show("Are you sure you want to delete this patient?", "Deleting Patient", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {                                     // personID
                if (clsPatient.DeletePatient((int)dgvPatients.CurrentRow.Cells[0].Value))
                { 
                    MessageBox.Show("The patient has been deleted!", "Success", MessageBoxButtons.OK);
                    frmManagePatients_Load(null, null);
                }
                else
                    MessageBox.Show("Something went wrong!", "Failure", MessageBoxButtons.OK);
            }
        }

        private void dgvPatients_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ( e.RowIndex % 2 == 0)
            {
                // Set the background color of the row
                dgvPatients.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            else
            {
                // Set the default background color of the row
                dgvPatients.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvPatients.DefaultCellStyle.BackColor;
            }
        }
    }
}