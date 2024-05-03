using System.Drawing;

namespace Gunluk
{
    class Gunluk
    {
        public DateTime tarih { get; set; }
        
    }
    internal class Program
    {
        static List<string>gunlukler=new List<string>();
        static List<string>kullanicilar=new List<string>();
        static List<string>sifreler=new List<string>();

        static void GirisYap()
        {
            Console.WriteLine("Hoş geldiniz");
            Console.WriteLine("1-Giriş yap:");
            Console.WriteLine("2-Kayıt ol:");
            Console.WriteLine("3-Çıkış:");
            string inputSecilenIslem = Sor("Seçtiğiniz işlemi girin:  ");
             if (inputSecilenIslem == "1")
            {
                GirisEkranı();
            }
             else
            {
                string kullaniciAdi = Sor("Kullanıcı Adı Giriniz: ");
                string yeniSifre = Sor("Şifre Giriniz: ");

                if (kullanicilar.Contains(kullaniciAdi))
                {
                    Console.WriteLine("Kullancı Adı Alınmış");
                    GirisYap();
                }
                else
                {
                    Console.WriteLine($"Başarıyla Kayıt Olundu.");
                    kullanicilar.Add(kullaniciAdi);
                    sifreler.Add(yeniSifre);
                    GirisEkranı();

                }
            }


        }
        //static void TxtKullaniciKaydet() 
        //{
        //    using StreamWriter writer = new StreamWriter("kullanıcılar.txt");
        //    foreach (var gunluk in gunlukler)
        //    {
        //        writer.WriteLine(kullanicilar);
        //    }
        //    Console.WriteLine("Başarıyla kaydedildi.");
        //    Console.ReadKey();

        //}
        static void GirisEkranı()
        {
            string KayitliKullaniciAdi = Sor("Kullanıcı adını girin:  ");
            string KayitliSifre = Sor("Şifrenizi girin:  ");
            bool kullaniciVarMi = false;
            string bulananKullaniciAdi = "";
            for (int i = 0; i < kullanicilar.Count; i++)
            {
                if (kullanicilar[i] == KayitliKullaniciAdi && sifreler[i] == KayitliSifre)
                {
                    kullaniciVarMi = true;
                    bulananKullaniciAdi += kullanicilar[i];
                    break;
                }
            }
            if (kullaniciVarMi)
            {
                Console.WriteLine($"Hoş geldiniz{bulananKullaniciAdi}");
                MenuGoster();
            }
            else
            {
                Console.WriteLine("Kullanıcı bulunamadı.");
                GirisYap();
            }
        }

        static string Sor(string soru)
        {
            Console.WriteLine(soru);
            return Console.ReadLine();
        }
        static void MenuyeDon()
        {
            Console.WriteLine("\nMenüye dönmek için bir tuşa basın");
            Console.ReadKey(true);
            MenuGoster();

        }

        static void YeniKayitEkle()
        {
            //if (gunlukler.Count > 0)
            //{
            //    Console.WriteLine("Her gün 1 adet günlük kaydı girebilirisiniz");
            //    MenuyeDon();
            //    return;

            //}
            Console.Clear();
            DateTime tarih = DateTime.Now;
            string yeniGunluk = Sor("Yeni günlük metni girin:  ");
            gunlukler.Add($"{tarih}\n{yeniGunluk}");
            TxtKaydet();
            MenuyeDon();
        }
        static void KayitlariListele() 
        { 
            Console.Clear();
            if(gunlukler.Count == 0 )
            {
                Console.WriteLine("Kayıtlı günlük bulunamadı");

            }
            else 
            {
                foreach(var gunluk in gunlukler)
                {
                    Console.WriteLine(gunluk);
                } 
            }
            MenuyeDon();
        }
        static void MenuGoster()
        {
            Console.Clear();
            Console.WriteLine("Günlük uygulamsına Hoş geldiniz.");
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1-Yeni kayıt ekle");
            Console.WriteLine("2-Kayıtları listele");
            Console.WriteLine("3-Ana menüye dön");
            Console.WriteLine("4-Çıkış yap");
            Console.WriteLine("----------------------------------");
            Console.Write("Seçiminiz:  ");
            char inputSecim = Console.ReadKey().KeyChar;

            switch (inputSecim)
            {
                case '1':
                    YeniKayitEkle();
                    break;
                case '2':
                    GunlukleriListele();
                    break;
                case '3':
                    MenuyeDon();
                    break;

                case '4':
                    break;
            }
        }
        static void TxtKaydet()
        {
            using StreamWriter writer = new StreamWriter("gunluk.txt");
            foreach(var gunluk in gunlukler)
            {
                writer.WriteLine(gunluk);
            }
            Console.WriteLine("Başarıyla kaydedildi.");
            Console.ReadKey();
        }
        static void GunlukleriYukle()
        {
            using StreamReader reader = new StreamReader("gunluk.txt");
            string TumMetin=reader.ReadToEnd();
            string[] satirlar = TumMetin.Split('\n');
            gunlukler.AddRange(satirlar);

        }

        static void GunlukleriListele()
        {
            Console.Clear();

            if(gunlukler.Count == 0)
            {
                Console.WriteLine("Günlük bulunamadı");
            }
            for(int i = 0; i < gunlukler.Count; i++)
            {
                Console.WriteLine($"{i+1} - {gunlukler[i]}");
            }

            Console.WriteLine("*************************************");
            Console.WriteLine("\n\n Sonraki kayıda (G)eç | (D)üzenle |  (S)il  |  (Ç)ıkış");
            Console.Write("Seçiminiz:  ");
            char yapılacakSecim= Console.ReadKey().KeyChar;

            switch(yapılacakSecim) 
            { 
                case 'G':

                    break;
                case 'D':
                    Duzenle();

                    break ;
                case 'S':
                    GunlukleriSil();

                    break;
                case 'Ç':

                    break;
            }


            MenuyeDon();
        }
        static void GunlukleriSil()
        {    
            Console.Clear ();
            Console.Write("Silinecek günlüğün numarasını giriniz:   ");
            int index =int.Parse(Console.ReadLine());

            string silinecekGunluk = gunlukler[index-1];
            Console.WriteLine(silinecekGunluk);
            Console.WriteLine("\nSilmek istediğinize eminmisiniz.(E/H)");
            char cevap= Console.ReadKey().KeyChar;
            switch(cevap)
            {
                case 'E':
                    gunlukler.RemoveAt(index-1);
                    TxtKaydet();
                    Console.WriteLine("Başarıyla silindi");
                    GunlukleriListele();
                    break;

                case 'H':
                    Console.WriteLine("Silme işlemi iptal ediliyor...");
                    GunlukleriListele();
                    break;
            }
        }
        static void Duzenle()
        {
            Console.WriteLine("Düzenlemek istediğiniz günlüğün index numarasını girin:");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < gunlukler.Count)
            {
                Console.WriteLine($"Eski günlük: {gunlukler[index-1]}");
                Console.Write("Yeni günlük metni girin: ");
                gunlukler[index] = Console.ReadLine();
                Console.WriteLine("Günlük başarıyla düzenlendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz index numarası.");
            }
        }

        static void GunlukleriDuzenle()
        {

        }
        static void Main(string[] args)
        {
            //GunlukleriYukle();
            // MenuGoster();
            GirisYap();


        }
    }
}
