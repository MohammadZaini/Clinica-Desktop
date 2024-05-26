using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica
{
    public class clsUtility
    {
      
        public static string ComputeHash(string input)
        {
            //SHA is Secure Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static void ShowErrorMessage(string errorMessage, string errorCaption = "Failure")
        {
            MessageBox.Show(errorMessage, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformationMessage(string infoMessage, string infoCaption = "Success")
        {
            MessageBox.Show(infoMessage, infoCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowWarningMessage(string warningMessage, string warningCaption)
        {
            return MessageBox.Show(warningMessage, warningCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
