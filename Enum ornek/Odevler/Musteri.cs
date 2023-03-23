using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Odevler
{
    public class Musteri
    {
        
        public string ad { get; set; }
        public string soyad { get; set; }

        private int ıd = 101;
        private string adres, telno;
        private string mail, kullaniciadi, sifre;

        Random rnd = new Random();
        private string rastgele;

        public Musteri()
        {
            ıd++;
          rastgele=  rnd.Next(1, 100).ToString();
        }

        public int Id { get { return ıd; } set { ıd = value; } }
        public string Adres { get { return adres; } set { adres = value; } }
        public string Telno { get { return telno; } set { telno = value; } }
        public string Mail { get { return mail; } set { mail = value; } }
        public string Sifre { get { return sifre; } set { sifre = value; } }
        public string KullaniciAdi
        {
            get { return kullaniciadi; }
            set
            {
                string[] deger= mail.Split('@');
                kullaniciadi= deger[0]+rastgele; 

            }
        }

    }
}
