namespace Clinica.Doctors
{
    partial class frmManageDoctors
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
            this.dgvDoctors = new System.Windows.Forms.DataGridView();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.doctorDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoctors
            // 
            this.dgvDoctors.AllowUserToAddRows = false;
            this.dgvDoctors.AllowUserToDeleteRows = false;
            this.dgvDoctors.AllowUserToOrderColumns = true;
            this.dgvDoctors.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDoctors.Location = new System.Drawing.Point(58, 161);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.ReadOnly = true;
            this.dgvDoctors.Size = new System.Drawing.Size(654, 416);
            this.dgvDoctors.TabIndex = 0;
            this.dgvDoctors.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDoctors_RowPrePaint);
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDoctor.Location = new System.Drawing.Point(737, 161);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(114, 90);
            this.btnAddDoctor.TabIndex = 1;
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 321);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorDetailsToolStripMenuItem,
            this.deleteDoctorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // doctorDetailsToolStripMenuItem
            // 
            this.doctorDetailsToolStripMenuItem.Name = "doctorDetailsToolStripMenuItem";
            this.doctorDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.doctorDetailsToolStripMenuItem.Text = "Doctor Details";
            this.doctorDetailsToolStripMenuItem.Click += new System.EventHandler(this.doctorDetailsToolStripMenuItem_Click);
            // 
            // deleteDoctorToolStripMenuItem
            // 
            this.deleteDoctorToolStripMenuItem.Name = "deleteDoctorToolStripMenuItem";
            this.deleteDoctorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteDoctorToolStripMenuItem.Text = "Delete Doctor";
            this.deleteDoctorToolStripMenuItem.Click += new System.EventHandler(this.deleteDoctorToolStripMenuItem_Click);
            // 
            // frmManageDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 608);
            this.Controls.Add(this.btnAddDoctor);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDoctors";
            this.Text = "frmManageDoctors";
            this.Load += new System.EventHandler(this.frmManageDoctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem doctorDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDoctorToolStripMenuItem;
    }
}