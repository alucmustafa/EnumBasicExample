using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odevler
{

   
    public class DataBaseMusteri

    {
        private static ArrayList musteriList = new ArrayList();
      
        Musteri m0=new Musteri();//olmayan Müşterinin bilgileri için 
         

        public  KayitBilgi MusteriKonrol(string KullaniciAdi)
        {
            if (musteriList.Contains(KullaniciAdi))
            {
             
                return KayitBilgi.kayitliKullanici;
               
            }
            else return KayitBilgi.kayitsizKullanici;
        }
        public int ındexNumber(string Mail)
        {            
          return musteriList.BinarySearch(Mail);
        }

        public void YeniMusteriEkle(Musteri m)
        {
            if (MusteriKonrol(m.KullaniciAdi) != KayitBilgi.kayitliKullanici)
            {
                musteriList.Add(m);             
            }
            else
            {
                Console.WriteLine("bu Kullanici zaten mevcut.");
            }
        }

        public Musteri MusteriBilgiGoruntule(string mail)
        {
            if (MusteriKonrol(mail)==KayitBilgi.kayitliKullanici)
            {           
                return (Musteri)musteriList[ındexNumber(mail)];
            }
            else
            {
                return m0;
            }

        }

    }
}
