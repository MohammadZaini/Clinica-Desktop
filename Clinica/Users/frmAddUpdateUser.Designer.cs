﻿namespace Clinica.Users
{
    partial class frmAddUpdateUser
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
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(12, 12);
            this.ctrlAddEditPerson1.ModeTitle = "Patient";
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(664, 573);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 592);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private People.ctrlAddEditPerson ctrlAddEditPerson1;
    }
}