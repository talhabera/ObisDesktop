using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObisDesktop
{
    public partial class FormLogin : Form
    {
        private FormApp form = new FormApp();

        private Dictionary<string, string> loginValues = new Dictionary<string, string>();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            loginValues.Add("talha", "123");

            txtPassword.PasswordChar= '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (loginValues.TryGetValue(txtUsername.Text, out string pass))
            {
                if (txtPassword.Text == pass)
                {
                    loginSuccess();
                    return;
                }
            }

            loginFailed();
        }

        void loginSuccess()
        {
            form.Show();
            this.Hide();
        }

        void loginFailed()
        {
            txtFail.Text = "Kullanıcı adı veya şifre hatalı girildi.";
        }
    }
}
