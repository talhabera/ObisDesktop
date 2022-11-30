using ObisDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObisDesktop.Helpers
{
    public static class VirtualDb
    {
        public static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        public static List<Ders> Dersler = new List<Ders>();
        public static List<Bolum> Bolumler = new List<Bolum>();
        public static List<Devamsizlik> Devamsizliklar = new List<Devamsizlik>();
        public static List<NotTipi> NotTipleri = new List<NotTipi>();
        public static List<Not> Notlar = new List<Not>();
        public static List<Duyuru> Duyurular = new List<Duyuru>();
        public static List<Sinav> Sinavlar = new List<Sinav>();

        /// <summary>
        /// Program başlatıldığında çalıştırılacak, sanal bir database oluşturur. Oluşturulan bu database ile uygulama test edilir.
        /// </summary>
        public static void DatabaseOlustur()
        {
            if (Ogrenciler.Count > 0)
                return;
            ogrencileriDoldur();
            dersleriDoldur();
            bolumleriDoldur();
            devamsizliklariDoldur();
            notTipleriniDoldur();
            notlariDoldur();
            duyurulariDoldur();
            sinavlariDoldur();
        }

        private static void ogrencileriDoldur()
        {
            Ogrenciler.AddRange(new List<Ogrenci>
            {
                new Ogrenci
                {
                    Id = 1,
                    KullaniciAdi = "talha.bera",
                    Sifre = Md5Converter.CreateMD5("talha123"),
                    Ad = "Talha",
                    Soyad = "Bera",
                    BolumId = 1
                },
                new Ogrenci
                {
                    Id = 2,
                    KullaniciAdi = "emir.karci",
                    Sifre = Md5Converter.CreateMD5("emir123"),
                    Ad = "Emir Taha",
                    Soyad = "Karcı",
                    BolumId = 1
                },
                new Ogrenci
                {
                    Id = 3,
                    KullaniciAdi = "cagatay.gundogdu",
                    Sifre = Md5Converter.CreateMD5("cagatay123"),
                    Ad = "Çağatay",
                    Soyad = "Gündoğdu",
                    BolumId = 2
                }
            });
        }
        private static void dersleriDoldur()
        {
            Dersler.AddRange(new List<Ders>
            {
                new Ders
                {
                    Id = 1,
                    Kod = "BBP201",
                    Kredi = 3,
                    Ad = "GÖRSEL PROGRAMLAMA"
                },
                new Ders
                {
                    Id = 2,
                    Kod = "MAT117",
                    Kredi = 2,
                    Ad = "MATEMATİK"
                },
                new Ders
                {
                    Id = 3,
                    Kod = "BTP104",
                    Kredi = 2,
                    Ad = "AÇIK KAYNAK İŞLETİM SİSTEMLERİ"
                }
            });
        }
        private static void bolumleriDoldur()
        {
            Bolumler.AddRange(new List<Bolum>
            {
                new Bolum
                {
                    Id = 1,
                    Ad = "Bilgisayar Programcılığı"
                },
                new Bolum
                {
                    Id = 2,
                    Ad = "Bilgisayar Teknolojisi"
                }
            });
        }
        private static void devamsizliklariDoldur()
        {
            Devamsizliklar.AddRange(new List<Devamsizlik>
            {
                new Devamsizlik
                {
                    Id = 1,
                    DersId = 1,
                    OgrenciId = 1,
                    Miktar = 4
                },
                new Devamsizlik
                {
                    Id = 2,
                    DersId = 2,
                    OgrenciId = 1,
                    Miktar = 3
                },
                new Devamsizlik
                {
                    Id = 4,
                    DersId = 2,
                    OgrenciId = 2,
                    Miktar = 3
                },
                new Devamsizlik
                {
                    Id = 3,
                    DersId = 3,
                    OgrenciId = 3,
                    Miktar = 6
                }
            });
        }
        private static void notTipleriniDoldur()
        {
            NotTipleri.AddRange(new List<NotTipi>
            {
                new NotTipi
                {
                    Id = 1,
                    Ad = "Vize"
                },
                new NotTipi
                {
                    Id = 2,
                    Ad = "Final"
                },
                new NotTipi
                {
                    Id = 3,
                    Ad = "Büt"
                }
            });
        }
        private static void notlariDoldur()
        {
            Notlar.AddRange(new List<Not>
            {
                new Not
                {
                    Id = 1,
                    DersId = 1,
                    OgrenciId = 1,
                    NotTipiId = 1,
                    Deger = 80
                },
                new Not
                {
                    Id = 2,
                    DersId = 2,
                    OgrenciId = 1,
                    NotTipiId = 1,
                    Deger = 75
                },
                new Not
                {
                    Id = 3,
                    DersId = 2,
                    OgrenciId = 1,
                    NotTipiId = 2,
                    Deger = 90
                },
                new Not
                {
                    Id = 4,
                    DersId = 1,
                    OgrenciId = 2,
                    NotTipiId = 1,
                    Deger = 90
                },
                new Not
                {
                    Id = 5,
                    DersId = 2,
                    OgrenciId = 2,
                    NotTipiId = 1,
                    Deger = 65
                },
                new Not
                {
                    Id = 6,
                    DersId = 3,
                    OgrenciId = 3,
                    NotTipiId = 1,
                    Deger = 55
                },
                new Not
                {
                    Id = 7,
                    DersId = 2,
                    OgrenciId = 3,
                    NotTipiId = 1,
                    Deger = 85
                },
            });
        }
        private static void duyurulariDoldur()
        {
            Duyurular.AddRange(new List<Duyuru>
            {
                new Duyuru
                {
                    Id = 1,
                    BolumId = 1,
                    DersId = 2,
                    Tarih = Convert.ToDateTime("22.11.2022"),
                    Mesaj = "25.11.2022 tarihli MATEMATİK dersi daha sonra yapılmak üzere ertelenmiştir."
                },
                new Duyuru
                {
                    Id = 2,
                    BolumId = 0,
                    DersId = 2,
                    Tarih = Convert.ToDateTime("21.11.2022"),
                    Mesaj = "24.11.2022 tarihli MATEMATİK dersi daha sonra yapılmak üzere ertelenmiştir."
                },
                new Duyuru
                {
                    Id = 3,
                    BolumId = 2,
                    DersId = 3,
                    Tarih = Convert.ToDateTime("24.11.2022"),
                    Mesaj = "28.11.2022 tarihli AÇIK KAYNAK İŞLETİM SİSTEMLERİ dersi daha sonra yapılmak üzere ertelenmiştir."
                }
            });
        }
        private static void sinavlariDoldur()
        {
            Sinavlar.AddRange(new List<Sinav>
            {
                new Sinav
                {
                    Id = 1,
                    BolumId = 1,
                    DersId = 1,
                    Tarih = Convert.ToDateTime("03.12.2022 13:00")
                },
                new Sinav
                {
                    Id = 2,
                    BolumId = 1,
                    DersId = 2,
                    Tarih = Convert.ToDateTime("03.12.2022 18:00")
                },
                new Sinav
                {
                    Id = 3,
                    BolumId = 2,
                    DersId = 2,
                    Tarih = Convert.ToDateTime("03.12.2022 14:00")
                },
                new Sinav
                {
                    Id = 4,
                    BolumId = 2,
                    DersId = 3,
                    Tarih = Convert.ToDateTime("03.12.2022 19:00")
                },
            });
        }

    }
}
