using System.Numerics;

public class Kisi
{
   public string ad, soyad;
   public int dogumyili;
    public long tc;
     
    public void KisiBilgisi(string ad1 , string soyad1,int dogumyili1,long tc1)
    {
        this.ad = ad1;
        this.soyad = soyad1;
        this.dogumyili= dogumyili1;
        this.tc = tc1;


    }

    public void KisiBilgisiYazdir()
    {
        string yil = this.dogumyili.ToString();
        string kimlik = new string('*', 10);
        Console.WriteLine("İsim:" + this.ad + " " + "soyisim:" + this.soyad+" "+"doğum yili:"+yil+" "+"tc:"+kimlik);

    }

}

public class Kitap
{
    string kitapadi, yazar, oncekikisi ;
    DateTime odunctarihi, gerigetirmetarihi;
    int ISBN, yayınyılı;
    bool kitapkontrol = true;
    List <string> kitaplistesi = new List <string>();

    public void KitapBilgisi(string kitapadi , string yazar , int ISBN , int yayınyılı )
    {
        this.kitapadi = kitapadi;
        this.yazar = yazar;
        this.ISBN = ISBN;
        this.yayınyılı = yayınyılı;
      
         
    }

    public bool KitapKontrol(string aranankitap)
    {
     
        if (this.kitapadi == aranankitap)
        {
            Console.WriteLine("Aranan kitap var.");
            if (this.oncekikisi != null)
            {
                Console.WriteLine("Kitap Adi :"+this.kitapadi+" ISBN: "+this.ISBN+" Kitabı önceden alan kişi: " + oncekikisi +" Ödünç alma tarihi: " + this.odunctarihi.ToString("dd.MM.yyyy") +
                                  " Kitap iade tarihi: " + this.gerigetirmetarihi.ToString("dd.MM.yyyy"));
            }
            return kitapkontrol;
        }
        else
        {
            Console.WriteLine("Aranan kitap mevcut değil.");
            return false;
        }

    }

    public void OduncAlma(string kisiadi,DateTime yenikitapalmatarihi,DateTime yeniidaetarihi )
    {

        if (kitapkontrol)
        {
            this.oncekikisi = kisiadi;
            kitapkontrol = false; 
            this.odunctarihi = yenikitapalmatarihi;
            this.gerigetirmetarihi = yeniidaetarihi;
            Console.WriteLine("Kitabı yeni alan kişi: " + kisiadi + " Kitabı ödünç alma tarihi: " + yenikitapalmatarihi.ToString("dd.MM.yyyy") +
                              " Kitabı geri getirme tarihi: " + yeniidaetarihi.ToString("dd.MM.yyyy"));
            kitaplistesi.Add(kitapadi + " " + yenikitapalmatarihi + " " + yeniidaetarihi);
        }
        else
        {
            Console.WriteLine("Kitap şu an başka bir kullanıcıda. Bu kitabı alamazsınız.");
        }

    }

   
    public void OduncVer(string kitapadi , string kisiadi , DateTime oduncvermetarihi)
    {
        
        kitaplistesi.Add(kitapadi + " " + kisiadi + " " + oduncvermetarihi.ToString("dd.MM.yyyy"));
        kitapkontrol = true; 
        Console.WriteLine("Kitap geri alındı ve tekrar mevcut.");
    }


    

}

class Program
{
    static void Main(string[] args)
    {
        Kisi kisi1 = new Kisi();
        kisi1.KisiBilgisi("Rümeysa", "Doğan", 2003, 123456789);
        kisi1.KisiBilgisiYazdir();

        
        Kitap kitap1 = new Kitap();
        kitap1.KitapBilgisi("Gurur ve Önyargı", "Jane Austen", 1234567890, 1813);

        if (kitap1.KitapKontrol("Gurur ve Önyargı"))
        {
            kitap1.OduncAlma("Aleyna Doğan", new DateTime(2024, 7, 7), new DateTime(2024, 8, 8));
        }

        kitap1.OduncVer("Gurur ve Önyargı", "Aleyna Doğan", new DateTime(2024, 8, 8));
        kitap1.KitapKontrol("Gurur ve Önyargı");

    }


}

