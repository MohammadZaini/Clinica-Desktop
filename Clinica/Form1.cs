﻿using Clinica.Patients;
using Clinica.People;
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

namespace Clinica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = clsUser.GetAllUsers();

            if (dt == null)
                MessageBox.Show("DataTable is null!");
            else
                dgvUsers.DataSource = dt;

        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            ManagePeople managePeopleScreen = new ManagePeople();
            managePeopleScreen.Show();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient addUpdatePatientForm = new frmAddUpdatePatient(true);
            addUpdatePatientForm.Show();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient addUpdatePatientForm = new frmAddUpdatePatient();
            addUpdatePatientForm.Show();
        }
    }
}
