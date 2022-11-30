using ObisDesktop.Entities;
using ObisDesktop.Helpers;
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
            VirtualDb.DatabaseOlustur();

            txtPassword.PasswordChar = '*';
            txtUsername.KeyDown += new KeyEventHandler(pressEnterForLogin);
            txtPassword.KeyDown += new KeyEventHandler(pressEnterForLogin);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Ogrenci ogrenci = VirtualDb.Ogrenciler.FirstOrDefault(x => x.KullaniciAdi == txtUsername.Text);
            if (ogrenci is null || !string.Equals(ogrenci.Sifre, Md5Converter.CreateMD5(txtPassword.Text)))
            {
                loginFailed();
                return;
            }

            loginSuccess(ogrenci);
        }

        private void loginSuccess(Ogrenci ogrenci)
        {
            form.LoginOgrenci = ogrenci;
            form.Show();
            this.Hide();
        }

        private void loginFailed()
        {
            txtPassword.Clear();
            txtFail.Text = "Kullanıcı adı veya şifre hatalı girildi.";
        }

        private void pressEnterForLogin(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
