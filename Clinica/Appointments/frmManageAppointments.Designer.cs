namespace Clinica.Appointments
{
    partial class frmManageAppointments
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
            this.components = new System.ComponentModel.Container();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cmsAppointmentOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confirmAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.cmsAppointmentOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookAppointment.Location = new System.Drawing.Point(788, 61);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(201, 147);
            this.btnBookAppointment.TabIndex = 0;
            this.btnBookAppointment.Text = "Book An Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AllowUserToOrderColumns = true;
            this.dgvAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointmentOptions;
            this.dgvAppointments.Location = new System.Drawing.Point(13, 223);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.Size = new System.Drawing.Size(976, 477);
            this.dgvAppointments.TabIndex = 1;
            // 
            // cmsAppointmentOptions
            // 
            this.cmsAppointmentOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmAppointmentToolStripMenuItem,
            this.cancelAppointmentToolStripMenuItem});
            this.cmsAppointmentOptions.Name = "cmsAppointmentOptions";
            this.cmsAppointmentOptions.Size = new System.Drawing.Size(193, 70);
            // 
            // confirmAppointmentToolStripMenuItem
            // 
            this.confirmAppointmentToolStripMenuItem.Name = "confirmAppointmentToolStripMenuItem";
            this.confirmAppointmentToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.confirmAppointmentToolStripMenuItem.Text = "Confirm Appointment";
            this.confirmAppointmentToolStripMenuItem.Click += new System.EventHandler(this.confirmAppointmentToolStripMenuItem_Click);
            // 
            // cancelAppointmentToolStripMenuItem
            // 
            this.cancelAppointmentToolStripMenuItem.Name = "cancelAppointmentToolStripMenuItem";
            this.cancelAppointmentToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cancelAppointmentToolStripMenuItem.Text = "Cancel Appointment";
            this.cancelAppointmentToolStripMenuItem.Click += new System.EventHandler(this.cancelAppointmentToolStripMenuItem_Click);
            // 
            // frmManageAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 722);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnBookAppointment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageAppointments";
            this.Load += new System.EventHandler(this.frmManageAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointmentOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBookAppointment;
        private System.Windows.Forms.ContextMenuStrip cmsAppointmentOptions;
        private System.Windows.Forms.ToolStripMenuItem confirmAppointmentToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.ToolStripMenuItem cancelAppointmentToolStripMenuItem;
    }
}