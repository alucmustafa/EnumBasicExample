using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Odevler
{
    class Program
    {
        static DataBaseMusteri db = new DataBaseMusteri();
        static void Main(string[] args)
        {

            Musteri yeni;
            Musteri m1 = new Musteri()
            {
                ad = "Mustafa",
                soyad = "ALUÇ",
                Adres = "Sultanbeyli",
                Telno = "546546",
                Mail = "mustafa@gmail.com",
                Sifre = "m1234"

            }; db.YeniMusteriEkle(m1);

            Musteri m2 = new Musteri()
            {
                ad = "Furkan",
                soyad = "ALUÇ",
                Adres = "Sultanbeyli",
                Telno = "57846546",
                Mail = "furkan@gmail.com",
                Sifre = "m1234"
            }; db.YeniMusteriEkle(m2);
        secimEkrani:
            Console.Clear();
            Console.WriteLine("Merhaba sistemden Müşteriler ile ilgili işlem yapmak için aşağıdaki yönergeleri takip edebilirsiniz");
            Console.WriteLine("1-yeni müşteri girişi ");
            Console.WriteLine("2-Müşteri bilgileri güncelleme ");
            Console.WriteLine("3-Müşteri kaydı kontol etme");
            Console.WriteLine("4-Müşteri bilgilerini ekrana getirme ");
            Console.WriteLine("Lütfen seçiminizi yapınız....");
            string secim = Console.ReadLine().ToLower();
            switch (secim)
            {

                case "1":
                YeniKayit:
                    yeni = new Musteri();
                    Console.Write("Yeni müşteri adı giriniz: ");
                    yeni.ad = Console.ReadLine();
                    Console.Write("Yeni müşteri soyadi giriniz: ");
                    yeni.soyad = Console.ReadLine().ToUpper();
                    Console.Write("Yeni müşteri adresi giriniz: ");
                    yeni.Adres = Console.ReadLine();
                    Console.Write("Yeni müşteri telefon numarası giriniz:  ");
                    yeni.Telno = Console.ReadLine();
                    Console.Write("Yeni müşteri mail adersi giriniz:  ");
                    yeni.Mail = Console.ReadLine();
                    Console.WriteLine("Yeni müşteri kullanıcı adı mail adersinden oluşurulacaktır..");
                    Console.Write("Yeni müşteri şifre giriniz:  ");
                    yeni.Sifre = Console.ReadLine();

                    Console.WriteLine("Müşteri Bilgileri şu şekilde kaydedilecek {0}-{1}-{2}-{3}-{4}-{5}  ", yeni.ad, yeni.soyad, yeni.Adres, yeni.Telno, yeni.Mail, yeni.Sifre);
                    Console.WriteLine("onaylıyor musunuz? [evet: e ,hayır : h]");
                    string onay = Console.ReadLine().ToLower();
                    if (onay == "e")
                    {
                        db.YeniMusteriEkle(yeni);
                        Console.WriteLine("Sisteme başarıyla kayıt yapılmıştır...");
                        Thread.Sleep(2000);
                        goto YeniKayit;
                    }
                    else
                    {
                        Console.WriteLine("yeniden giriş ekranına yönlendiriliyorsunuz......");
                        Thread.Sleep(2000);                     
                        goto YeniKayit;
                    }


                case "2":
                    Console.Write("Lütfen güncellemek istediğiniz müşterinin mail adresini giriniz:  ");
                    string girilenEmail = Console.ReadLine();
                    KayitBilgi gelenbilgi = db.MusteriKonrol(girilenEmail);
                    if (gelenbilgi == KayitBilgi.kayitliKullanici)
                    {
                        int index_kontol = db.ındexNumber(girilenEmail);
                        Musteri m = (Musteri)db[index_kontol];//!index sorununu çöz..

                        Console.Write(" müşteri adı giriniz: ");
                        m.ad = Console.ReadLine();
                        Console.Write(" müşteri soyadi giriniz: ");
                        m.soyad = Console.ReadLine().ToUpper();
                        Console.Write(" müşteri adresi giriniz: ");
                        m.Adres = Console.ReadLine();
                        Console.Write(" müşteri telefon numarası giriniz:  ");
                        m.Telno = Console.ReadLine();
                        Console.Write(" müşteri mail adersi giriniz:  ");
                        m.Mail = Console.ReadLine();
                        Console.WriteLine(" müşteri kullanıcı adı mail adersinden oluşurulacaktır..");
                        Console.Write(" müşteri şifre giriniz:  ");
                        m.Sifre = Console.ReadLine();

                        Console.WriteLine("Güncelleme işlemi başarıyla tamamlanmıştır.....");
                        Thread.Sleep(2000);                     
                        goto secimEkrani;
                    }
                    else if (gelenbilgi == KayitBilgi.kayitsizKullanici)
                    {
                        Console.WriteLine("Böyle bir kullanıcı bulunamadı...");
                        Thread.Sleep(2000);
                        goto secimEkrani;
                    }
                    break;
                case "3":
                    Console.Write("Mail adresi üzerinden müşterinin olup olmadığını kontrol etmek içi bir mail adresi giriniz...");
                    string girilenEmailVar_mi = Console.ReadLine();
                    KayitBilgi gelenbilgiar_mi = db.MusteriKonrol(girilenEmailVar_mi);
                    if (gelenbilgiar_mi == KayitBilgi.kayitliKullanici)
                    {
                        Console.WriteLine("Bu Mail adresinde bir kullanıcı kayıtlıdır..");
                        Thread.Sleep(3000);
                        goto secimEkrani;
                    }
                    else if (gelenbilgiar_mi == KayitBilgi.kayitsizKullanici)
                    {
                        Console.WriteLine("Bu Mail adresinde bir kullanıcı kayıtlı değildir....");
                        Thread.Sleep(3000);
                        goto secimEkrani;
                    }
                    break;

                case "4"://index sorununu çözdükten sonra bakılacak...
                    //Console.WriteLine("Müşteri Bilgileri şu şekilde  {0}-{1}-{2}-{3}-{4}-{5}  ", yeni.ad, yeni.soyad, yeni.Adres, yeni.Telno, yeni.Mail, yeni.Sifre);
                    break;


                default:
                    Console.WriteLine(".......Yanlış bir seçim yaptınız....");
                    Thread.Sleep(3000);
                    goto secimEkrani;
                   
            }


        }
    }
}
