using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObisDesktop.Entities
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; } //Şifrelenmiş formatta tutulur
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int BolumId { get; set; }
    }
}
