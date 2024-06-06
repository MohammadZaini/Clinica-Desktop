namespace Clinica.Appointments
{
    partial class frmScheduleAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDoctors = new System.Windows.Forms.ComboBox();
            this.btnSlot1 = new System.Windows.Forms.Button();
            this.btnSlot2 = new System.Windows.Forms.Button();
            this.btnSlot4 = new System.Windows.Forms.Button();
            this.btnSlot3 = new System.Windows.Forms.Button();
            this.btnSlot6 = new System.Windows.Forms.Button();
            this.btnSlot8 = new System.Windows.Forms.Button();
            this.btnSlot5 = new System.Windows.Forms.Button();
            this.btnSlot7 = new System.Windows.Forms.Button();
            this.btnConfirmAppointment = new System.Windows.Forms.Button();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.ctrlDoctorCard1 = new Clinica.Doctors.Controls.ctrlDoctorCard();
            this.ctrlPatientCardWithFilter1 = new Clinica.Patients.ctrlPatientCardWithFilter();
            this.SuspendLayout();
            // 
            // cmbDoctors
            // 
            this.cmbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoctors.FormattingEnabled = true;
            this.cmbDoctors.Location = new System.Drawing.Point(802, 32);
            this.cmbDoctors.Name = "cmbDoctors";
            this.cmbDoctors.Size = new System.Drawing.Size(326, 24);
            this.cmbDoctors.TabIndex = 0;
            this.cmbDoctors.SelectedIndexChanged += new System.EventHandler(this.cmbDoctors_SelectedIndexChanged);
            // 
            // btnSlot1
            // 
            this.btnSlot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot1.Location = new System.Drawing.Point(449, 176);
            this.btnSlot1.Name = "btnSlot1";
            this.btnSlot1.Size = new System.Drawing.Size(90, 32);
            this.btnSlot1.TabIndex = 1;
            this.btnSlot1.Tag = "17";
            this.btnSlot1.Text = "09:00 - 10:00";
            this.btnSlot1.UseVisualStyleBackColor = true;
            this.btnSlot1.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot2
            // 
            this.btnSlot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot2.Location = new System.Drawing.Point(545, 176);
            this.btnSlot2.Name = "btnSlot2";
            this.btnSlot2.Size = new System.Drawing.Size(90, 32);
            this.btnSlot2.TabIndex = 1;
            this.btnSlot2.Tag = "18";
            this.btnSlot2.Text = "10:00 - 11:00 ";
            this.btnSlot2.UseVisualStyleBackColor = true;
            this.btnSlot2.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot4
            // 
            this.btnSlot4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot4.Location = new System.Drawing.Point(545, 214);
            this.btnSlot4.Name = "btnSlot4";
            this.btnSlot4.Size = new System.Drawing.Size(90, 32);
            this.btnSlot4.TabIndex = 1;
            this.btnSlot4.Tag = "20";
            this.btnSlot4.Text = "12:00 - 13:00";
            this.btnSlot4.UseVisualStyleBackColor = true;
            this.btnSlot4.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot3
            // 
            this.btnSlot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot3.Location = new System.Drawing.Point(449, 214);
            this.btnSlot3.Name = "btnSlot3";
            this.btnSlot3.Size = new System.Drawing.Size(90, 32);
            this.btnSlot3.TabIndex = 1;
            this.btnSlot3.Tag = "19";
            this.btnSlot3.Text = "11:00 - 12:00";
            this.btnSlot3.UseVisualStyleBackColor = true;
            this.btnSlot3.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot6
            // 
            this.btnSlot6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot6.Location = new System.Drawing.Point(545, 253);
            this.btnSlot6.Name = "btnSlot6";
            this.btnSlot6.Size = new System.Drawing.Size(90, 32);
            this.btnSlot6.TabIndex = 1;
            this.btnSlot6.Tag = "22";
            this.btnSlot6.Text = "14:00 - 15:00";
            this.btnSlot6.UseVisualStyleBackColor = true;
            this.btnSlot6.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot8
            // 
            this.btnSlot8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot8.Location = new System.Drawing.Point(545, 291);
            this.btnSlot8.Name = "btnSlot8";
            this.btnSlot8.Size = new System.Drawing.Size(90, 32);
            this.btnSlot8.TabIndex = 1;
            this.btnSlot8.Tag = "24";
            this.btnSlot8.Text = "16:00 - 17:00";
            this.btnSlot8.UseVisualStyleBackColor = true;
            this.btnSlot8.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot5
            // 
            this.btnSlot5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot5.Location = new System.Drawing.Point(449, 253);
            this.btnSlot5.Name = "btnSlot5";
            this.btnSlot5.Size = new System.Drawing.Size(90, 32);
            this.btnSlot5.TabIndex = 1;
            this.btnSlot5.Tag = "21";
            this.btnSlot5.Text = "13:00 - 14:00";
            this.btnSlot5.UseVisualStyleBackColor = true;
            this.btnSlot5.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnSlot7
            // 
            this.btnSlot7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSlot7.Location = new System.Drawing.Point(449, 291);
            this.btnSlot7.Name = "btnSlot7";
            this.btnSlot7.Size = new System.Drawing.Size(90, 32);
            this.btnSlot7.TabIndex = 1;
            this.btnSlot7.Tag = "23";
            this.btnSlot7.Text = "15:00 - 16:00";
            this.btnSlot7.UseVisualStyleBackColor = true;
            this.btnSlot7.Click += new System.EventHandler(this._TimeSlotPressed);
            // 
            // btnConfirmAppointment
            // 
            this.btnConfirmAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmAppointment.Location = new System.Drawing.Point(471, 352);
            this.btnConfirmAppointment.Name = "btnConfirmAppointment";
            this.btnConfirmAppointment.Size = new System.Drawing.Size(145, 39);
            this.btnConfirmAppointment.TabIndex = 2;
            this.btnConfirmAppointment.Text = "Confirm Appointment";
            this.btnConfirmAppointment.UseVisualStyleBackColor = true;
            this.btnConfirmAppointment.Click += new System.EventHandler(this.btnConfirmAppointment_Click);
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(457, 116);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(178, 20);
            this.dtpAppointmentDate.TabIndex = 3;
            this.dtpAppointmentDate.ValueChanged += new System.EventHandler(this.dtpAppointmentDate_ValueChanged);
            // 
            // ctrlDoctorCard1
            // 
            this.ctrlDoctorCard1.Location = new System.Drawing.Point(802, 79);
            this.ctrlDoctorCard1.Name = "ctrlDoctorCard1";
            this.ctrlDoctorCard1.Size = new System.Drawing.Size(326, 349);
            this.ctrlDoctorCard1.TabIndex = 5;
            // 
            // ctrlPatientCardWithFilter1
            // 
            this.ctrlPatientCardWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPatientCardWithFilter1.Name = "ctrlPatientCardWithFilter1";
            this.ctrlPatientCardWithFilter1.Size = new System.Drawing.Size(319, 526);
            this.ctrlPatientCardWithFilter1.TabIndex = 4;
            // 
            // frmScheduleAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 538);
            this.Controls.Add(this.ctrlDoctorCard1);
            this.Controls.Add(this.ctrlPatientCardWithFilter1);
            this.Controls.Add(this.dtpAppointmentDate);
            this.Controls.Add(this.btnConfirmAppointment);
            this.Controls.Add(this.btnSlot7);
            this.Controls.Add(this.btnSlot3);
            this.Controls.Add(this.btnSlot5);
            this.Controls.Add(this.btnSlot2);
            this.Controls.Add(this.btnSlot8);
            this.Controls.Add(this.btnSlot6);
            this.Controls.Add(this.btnSlot4);
            this.Controls.Add(this.btnSlot1);
            this.Controls.Add(this.cmbDoctors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScheduleAppointment";
            this.Load += new System.EventHandler(this.frmScheduleAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDoctors;
        private System.Windows.Forms.Button btnSlot1;
        private System.Windows.Forms.Button btnSlot2;
        private System.Windows.Forms.Button btnSlot4;
        private System.Windows.Forms.Button btnSlot3;
        private System.Windows.Forms.Button btnSlot6;
        private System.Windows.Forms.Button btnSlot8;
        private System.Windows.Forms.Button btnSlot5;
        private System.Windows.Forms.Button btnSlot7;
        private System.Windows.Forms.Button btnConfirmAppointment;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private Patients.ctrlPatientCardWithFilter ctrlPatientCardWithFilter1;
        private Doctors.Controls.ctrlDoctorCard ctrlDoctorCard1;
    }
}