﻿namespace Clinica.Patients
{
    partial class frmAddUpdatePatient
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
            this.ctrlAddEditPerson1 = new Clinica.People.ctrlAddEditPerson();
            this.SuspendLayout();
            // 
            // ctrlAddEditPerson1
            // 
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(3, 1);
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(664, 573);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // frmAddUpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 580);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdatePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdatePatient";
            this.ResumeLayout(false);

        }

        #endregion

        private People.ctrlAddEditPerson ctrlAddEditPerson1;
    }
}