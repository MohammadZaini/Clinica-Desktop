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

namespace Clinica.Appointments
{
    public partial class frmManageAppointments : Form
    {

        private DataTable _appointments;

        public frmManageAppointments()
        {
            InitializeComponent();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            frmScheduleAppointment scheduleAppointment = new frmScheduleAppointment();
            scheduleAppointment.ShowDialog();
        }

        private void _ListAppointments() {      
            _appointments = clsAppointment.GetAllAppointments();
            dgvAppointments.DataSource = _appointments;
        }

        private void frmManageAppointments_Load(object sender, EventArgs e)
        {
            _ListAppointments();
        }

        private void confirmAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeAppointmentStatus("Are you sure you want to confirm this appointment?", clsAppointment.AppointStatus.Confirmed,
               "The appointment has been confirmed successfully", "The appointment has not been confirmed, something went wrong!");
        }

        private void cancelAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeAppointmentStatus("Are you sure you want to cancel this appointment?", clsAppointment.AppointStatus.Cancelled, 
                "The appointment has been cancelled successfully", "The appointment has not been cancelled, something went wrong!");
        }


        private void _ChangeAppointmentStatus(string confirmationMessage, clsAppointment.AppointStatus appointmentStatus, string informationMessage,
            string errorMessage) {

            clsAppointment selectedAppointment = clsAppointment.Find((int)dgvAppointments.CurrentRow.Cells[0].Value);

            DialogResult dialogResult = clsUtility.ShowConfirmationMessage(confirmationMessage);
            if (dialogResult == DialogResult.Yes)
            {
                selectedAppointment.AppointmentStatus = appointmentStatus;

                if (selectedAppointment.Save())
                {
                    clsUtility.ShowInformationMessage(informationMessage);
                    _ListAppointments();
                }
                else
                    clsUtility.ShowErrorMessage(errorMessage);
            }

        }
    }
}