using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Generators;
using PMS_v1.Data;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using PMS_v1.Models.Responses;
using PMS_v1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;

namespace PMS_v1.Pages.Main
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            PasswordToggle.Attach(txtPassword, btnShowHidePass);

            btnLogin.StateNormal.Content.ShortText.Color1 = Color.White;
            btnLogin.StateTracking.Content.ShortText.Color1 = Color.FromArgb(116, 219, 219);   // hover
            btnLogin.StatePressed.Content.ShortText.Color1 = Color.White;     // clicked

            AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            try
            {
                LoginResponse result = new AuthService().Login(username, password);

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show($"Welcome, {result.FullName}.\nPosition: {result.Position}.\nNo. : {result.EmployeeNo}", "Login Successful");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex);
            }
        }

        private void lnklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (var signUp = new SignUp())
            {
                signUp.ShowDialog();

            }
            this.Show();
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}