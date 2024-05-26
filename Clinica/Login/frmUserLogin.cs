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

namespace Clinica.Login
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            clsUser loggedInUser = clsUser.Find(username);


            if (loggedInUser == null)
            {
                clsUtility.ShowInformationMessage($"There's no user found with username: {username}", "Not Found");
                return;
            }

            // Check Username
            if (loggedInUser.Username != username)
            {
                clsUtility.ShowErrorMessage("Username is incorrect");
                return;
            }

            if (loggedInUser.Password != password)
            {

                clsUtility.ShowErrorMessage("Password is incorrect");
                return;
            }

            if (!loggedInUser.IsActive)
            {
                clsUtility.ShowErrorMessage("Your account is deactivated. Please contact your admin");
                return;
            }

            clsGlobalSettings.LoggedInUser = loggedInUser;

            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
