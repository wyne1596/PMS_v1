using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Generators;
using PMS_v1.Data;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using PMS_v1.Services;
using PMS_v1.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;
using System.Xml.Linq;

namespace PMS_v1.Pages.Main
{
    public partial class SignUp : Form
    {
        private const int maxAttempts = 5;
        private static int failedAttempts = 0;

        public SignUp()
        {
            InitializeComponent();

            PasswordToggle.Attach(txtPassword, btnShowHidePass1);
            PasswordToggle.Attach(txtRePassword, btnShowHidePass2);

            btnSignUp.StateNormal.Content.ShortText.Color1 = Color.White;
            btnSignUp.StateTracking.Content.ShortText.Color1 = Color.FromArgb(116, 219, 219);   // hover
            btnSignUp.StatePressed.Content.ShortText.Color1 = Color.White;     // clicked
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (failedAttempts >= maxAttempts)
            { MessageBox.Show("Maximum sign-up attempts exceeded. Please try again later."); return; }

            var request = new SignUpRequest
            {
                EmployeeNo = txtEmployeeNumber.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                ConfirmPassword = txtRePassword.Text
            };

            string? error = SignUpValidator.Validate(request);
            if (error != null)
            { MessageBox.Show(error); return; }

            try
            {
                SignUpResponse result = new AuthService().SignUp(request);

                if (!result.Success)
                {
                    if (result.EmployeeNotFound) failedAttempts++;
                    MessageBox.Show(result.Message);
                    return;
                }

                failedAttempts = 0;
                MessageBox.Show("Account created.\nYou can now log in.");
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex, ErrorRules.SignUp);
            }

        }

        private void lnklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }
    }
}