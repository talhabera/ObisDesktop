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
    public partial class FormApp : Form
    {
        public Ogrenci LoginOgrenci = null;
        public FormApp()
        {
            InitializeComponent();
        }

        private void FormApp_Load(object sender, EventArgs e)
        {
            txtWelcome.Text += String.Join(" ", LoginOgrenci.Ad, LoginOgrenci.Soyad);
            btnDuyurular_Click(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            FormLogin logForm = new FormLogin();

            logForm.Show();
            this.Hide();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panelDuyuru.Show();
            lbDuyurular.Items.Clear();
            VirtualDb.Duyurular.Where(x => x.BolumId == LoginOgrenci.BolumId).ToList().ForEach(x => lbDuyurular.Items.Add(x.Mesaj.Substring(0, 45) + "..."));
        }
        private void lbDuyurular_SelectedIndexChanged(object sender, EventArgs e)
        {
            Duyuru duyuru = VirtualDb.Duyurular.FirstOrDefault(x => x.Mesaj.Substring(0, 45) + "..." == lbDuyurular.SelectedItem.ToString());
            if (duyuru is null)
                return;

            txtDuyuruMesaj.Text = duyuru.Mesaj;
            txtDuyuruTarih.Text = duyuru.Tarih.ToShortDateString();
        }

        private void btnNotlar_Click(object sender, EventArgs e)
        {
            hideAllPanels();
            panelNotlar.Show();
            lbNotDersler.Items.Clear();
            List<Not> notlar = VirtualDb.Notlar.Where(x => x.OgrenciId == LoginOgrenci.Id).ToList();
            VirtualDb.Dersler.Where(x => notlar.Any(y => y.DersId == x.Id)).ToList().ForEach(x => lbNotDersler.Items.Add(x.Kod + " | " + x.Ad));
        }
        private void lbNotDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dersNotlari = VirtualDb.Notlar.Where(x => x.DersId == VirtualDb.Dersler.FirstOrDefault(y => string.Equals(y.Kod + " | " + y.Ad,
                                                                                                                  lbNotDersler.SelectedItem.ToString()))?.Id).ToList();
            if (dersNotlari is null)
                return;
            var vizeNotu = dersNotlari.FirstOrDefault(x => x.NotTipiId == 1)?.Deger;
            txtVizeNotu.Text = (vizeNotu ?? 0).ToString();
            var finalNotu = dersNotlari.FirstOrDefault(x => x.NotTipiId == 2)?.Deger;
            txtFinalNotu.Text = (finalNotu ?? 0).ToString();
            var butNotu = dersNotlari.FirstOrDefault(x => x.NotTipiId == 3)?.Deger;
            txtButNotu.Text = (butNotu ?? 0).ToString();

            if ((butNotu > finalNotu ? butNotu : finalNotu) < 40)
            {
                txtHarfNotu.Text = "FF";
                return;
            }
            var ortalama = vizeNotu * 0.4f + (butNotu > finalNotu ? butNotu * 0.6f : finalNotu * 0.6f);
            switch (ortalama)
            {
                case var expression when ortalama >= 90:
                    txtHarfNotu.Text = "AA";
                    break;
                case var expression when ortalama >= 85:
                    txtHarfNotu.Text = "BA";
                    break;
                case var expression when ortalama >= 75:
                    txtHarfNotu.Text = "BB";
                    break;
                case var expression when ortalama >= 65:
                    txtHarfNotu.Text = "CB";
                    break;
                case var expression when ortalama >= 60:
                    txtHarfNotu.Text = "CC";
                    break;
                case var expression when ortalama >= 50:
                    txtHarfNotu.Text = "DC";
                    break;
                case var expression when ortalama >= 45:
                    txtHarfNotu.Text = "DD";
                    break;
                case var expression when ortalama >= 40:
                    txtHarfNotu.Text = "FD";
                    break;
                default:
                    txtHarfNotu.Text = "FF";
                    break;
            }
        }

        private void btnSinavlar_Click(object sender, EventArgs e)
        {
            hideAllPanels();

        }
        private void btnProgram_Click(object sender, EventArgs e)
        {
            hideAllPanels();

        }
        private void btnDevamsizlik_Click(object sender, EventArgs e)
        {
            hideAllPanels();

        }
        private void btnAldigimDersler_Click(object sender, EventArgs e)
        {
            hideAllPanels();

        }
        private void btnAlacagimDersler_Click(object sender, EventArgs e)
        {
            hideAllPanels();

        }
        private void hideAllPanels()
        {
            panelDuyuru.Hide();
            panelNotlar.Hide();
        }

    }
}
