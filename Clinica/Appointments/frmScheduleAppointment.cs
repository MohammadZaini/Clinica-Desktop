using ClinicaBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica.Appointments
{
    public partial class frmScheduleAppointment : Form
    {

        private DataTable _timeSlots;
        private int _timeSlotID;
        private Button[] _timeSlotButtons;
        private clsTimeSlot _timeSlot;
        clsAppointment _appointment;

        public int PatientID;
        public int DoctorID;

        public frmScheduleAppointment()
        {
            InitializeComponent();

            _InitializeTimeSlotButtons();
            _FillComboBoxWithDoctors();
            _ShowTimeSlots();
            _SetAppointmentDateRange();
        }

        private void _InitializeTimeSlotButtons() { 
            _timeSlotButtons = new Button[] { btnSlot1, btnSlot2, btnSlot3, btnSlot4, btnSlot5, btnSlot6, btnSlot7, btnSlot8 };
        }

        private void _TimeSlotPressed(object sender, EventArgs e) {

            Button currentButton = (Button)sender;

            _timeSlotID = Convert.ToInt32(currentButton.Tag);

            foreach (var timeSlotButton in _timeSlotButtons)
            {
                if (timeSlotButton == currentButton)
                    currentButton.BackColor = Color.Green;
                else if (timeSlotButton.BackColor == Color.Red)
                    continue;
                else
                    timeSlotButton.BackColor = Color.White;
            }
        }

        private void _SetAppointmentDateRange() {
            dtpAppointmentDate.MaxDate = DateTime.Today.AddDays(7);
            dtpAppointmentDate.MinDate = DateTime.Today;
        }

        private void _FillComboBoxWithDoctors() { 
        
            cmbDoctors.DataSource = clsDoctor.GetAllDoctors();
            cmbDoctors.DisplayMember = "FirstName"; 
            cmbDoctors.ValueMember = "DoctorID"; 
        }

        private void _ShowTimeSlots() {

            if (_timeSlots == null || _timeSlots.Rows.Count == 0) {
                _ShowDefaultTimeSlots();
                _ResetTimeSlotsToAvailable();
                return;
            };

            bool isReserved = false;

            int length = _timeSlotButtons.Length > _timeSlots.Rows.Count ? _timeSlots.Rows.Count : _timeSlotButtons.Length;

            if (length < _timeSlotButtons.Length)
            {
                _ShowDefaultTimeSlots();
                _ResetTimeSlotsToAvailable();
            }

            for (int i = 0; i < length; i++)
            {
                isReserved = (bool)_timeSlots.Rows[i]["IsReserved"];
                if (isReserved)            
                    MarkSlotAsReserved(_timeSlotButtons[i]);             
                else
                    MarkSlotAsAvailable(_timeSlotButtons[i]);

                _timeSlotButtons[i].Text = _timeSlots.Rows[i]["Start Time"].ToString() + " - " + _timeSlots.Rows[i]["End Time"].ToString();
                _timeSlotButtons[i].Tag = _timeSlots.Rows[i]["SlotID"];
            }
        }

        private void _ShowDefaultTimeSlots() {

            btnSlot1.Text = "09:00 - 10:00";
            btnSlot2.Text = "10:00 - 11:00";
            btnSlot3.Text = "11:00 - 12:00";
            btnSlot4.Text = "12:00 - 13:00";
            btnSlot5.Text = "13:00 - 14:00";
            btnSlot6.Text = "14:00 - 15:00";
            btnSlot7.Text = "15:00 - 16:00";
            btnSlot8.Text = "16:00 - 17:00";
        }

        private void _ResetTimeSlotsToAvailable()
        {
            foreach (var timeSlot in _timeSlotButtons)
            {
                MarkSlotAsAvailable(timeSlot);
            }
        }

        private void MarkSlotAsReserved(Button timeSlot) {
            timeSlot.BackColor = Color.Red;
            timeSlot.Enabled = false;
        }

        private void MarkSlotAsAvailable(Button timeSlot)
        {
            timeSlot.BackColor = Color.White;
            timeSlot.Enabled = true;
        }

        private void cmbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpAppointmentDate.Value.Date;


            if (cmbDoctors.SelectedValue is int) {

                DoctorID = (int)cmbDoctors.SelectedValue;

                ctrlDoctorCard1.LoadDoctorInfo(DoctorID);
                _timeSlots = clsTimeSlot.GetTimeSlotsPerDoctor(DoctorID, selectedDate);
                _ShowTimeSlots();
            }
        }

        private void dtpAppointmentDate_ValueChanged(object sender, EventArgs e)
        {
            _ShowTimeSlotsOnSelectedDate();
        }

        private void frmScheduleAppointment_Load(object sender, EventArgs e)
        {
            _timeSlots = clsTimeSlot.GetTimeSlotsPerDoctor((int)cmbDoctors.SelectedValue, DateTime.Today);
        }

        private void btnConfirmAppointment_Click(object sender, EventArgs e)
        {
            _FillAppointmentDetails();

            DialogResult dialogResult = clsUtility.ShowConfirmationMessage("Are you sure you want to book this appointment?", "Confirmation");

            if (dialogResult == DialogResult.Yes)
                if (_appointment.Save())
                { 
                    clsUtility.ShowInformationMessage($"The Appoinment has been booked At: {_appointment.AppointmentTime}, On: {_appointment.AppointmentDate}");

                    _ShowTimeSlotsOnSelectedDate();
                }
                else
                    clsUtility.ShowErrorMessage("The appointment has not been booked, something went wrong!");

        }

        private void _FillAppointmentDetails() {
            _timeSlot = clsTimeSlot.Find(_timeSlotID);
            _appointment = new clsAppointment();

            if (_timeSlot == null) return;

            _appointment.PatientID = ctrlPatientCardWithFilter1.PatientID;
            _appointment.DoctorID = DoctorID;
            _appointment.AppointmentDate = dtpAppointmentDate.Value.Date;
            _appointment.AppointmentTime = _timeSlot.StartTime;
            _appointment.AppointmentStatus = clsAppointment.AppointStatus.Pending;
            _appointment.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            _appointment.TimeSlotID = _timeSlotID;

        }

        private void _ShowTimeSlotsOnSelectedDate() {
            DateTime selectedDate = dtpAppointmentDate.Value.Date;
            _timeSlots = clsTimeSlot.GetTimeSlotsPerDoctor((int)cmbDoctors.SelectedValue, selectedDate);
            _ShowTimeSlots();
        }
    }
}