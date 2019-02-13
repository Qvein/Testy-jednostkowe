using System;
using NUnit.Framework;
using ZamowieniaObiektowe;



namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [Test]  
        public void CzyDobrzeLiczyPodatek()// Dla klasy Pozycje Zamowienia metoda Oblicz Podatek
        {

            var poz = new PozycjaZamowienia();
            var wynik = 0.23 * (15 * 20000);
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 15;
            poz.stawkaVat = 23;
            poz.cenaJednostkowa = 20000;

            Assert.That(poz.ObliczPodatek(), Is.EqualTo(wynik));// podatek jesty równy dokładnie zmiennej wynik

        }

        [Test] 
        public void CzyDobrzeLiczyPodatekUjemne()// Dla klasy Pozycje Zamowienia metoda Oblicz Podatek ujemne wartości
        {

            var poz = new PozycjaZamowienia();
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 15;
            poz.stawkaVat = 23;
            poz.cenaJednostkowa = -20000;

            Assert.Greater(poz.ObliczPodatek(), 0); // Brak obsłużonego wyjątku dla ujemej wartości, wynik powinien być większy od 0.

        }



        [Test] 
        public void CzyDodajePozycjeZamowienia()//Dla klasy Zamowienie metoda Dodaj Pozycje Zamowienia
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            poz.cenaJednostkowa = 20000;

            var LiczbaPozycji = zam.pozycjeZamowienia.Count;
            zam.DodajPozycjeZamowienia(poz);

            Assert.That(zam.pozycjeZamowienia.Count, Is.EqualTo(LiczbaPozycji + 1));// Ilośc zamówień powinna być taka jak liczba pozycji +1.

        }


        [Test] 
        public void CzyDobrzeLiczyWartoscZamowienia()//Dla klasy Zamowienie metoda Wartosc Zamowienia czy dobrze liczy
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            double stawkaVat = poz.stawkaVat;
            poz.cenaJednostkowa = 20000;

            zam.DodajPozycjeZamowienia(poz);

            var poz1 = new PozycjaZamowienia();
            poz1.nazwaTowaru = "nazwa1";
            poz1.ilosc = 3;
            poz1.stawkaVat = 7;
            double stawkaVat1 = poz1.stawkaVat;
            poz1.cenaJednostkowa = 150;
            zam.DodajPozycjeZamowienia(poz1);

            //var wynik = 1.23 * (5 * 20000) + 1.07 * (3 * 150);
            var wynik = (1 + stawkaVat / 100) * (poz.ilosc * poz.cenaJednostkowa) + (1 + stawkaVat1 / 100) * (poz1.ilosc * poz1.cenaJednostkowa);

            Assert.That(zam.WartoscZamowienia(), Is.EqualTo(wynik));//dokładne podstawienie czy liczy jak powinno

        }

        [Test] 
        public void CzyDobrzeLiczyWartoscZamowienia1()//Dla klasy Zamowienie metoda Wartosc Zamowienia czy dobrze liczy zamowienie przypadek 2
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            double stawkaVat = poz.stawkaVat;
            poz.cenaJednostkowa = 20000;

            zam.DodajPozycjeZamowienia(poz);

            var poz1 = new PozycjaZamowienia();
            poz1.nazwaTowaru = "nazwa1";
            poz1.ilosc = 4;
            poz1.stawkaVat = 15;
            double stawkaVat1 = poz1.stawkaVat;
            poz1.cenaJednostkowa = 15000;
            zam.DodajPozycjeZamowienia(poz1);

            //var wynik = 1.23 * (5 * 20000) + 1.15 * (4 * 15000);
           var wynik = (1 + stawkaVat / 100 ) * (poz.ilosc * poz.cenaJednostkowa) + (1 + stawkaVat1 / 100) * (poz1.ilosc * poz1.cenaJednostkowa);
           
            Assert.That(zam.WartoscZamowienia(), Is.EqualTo(wynik));// zmiana danych do sprawdzenia wyniku 

        }

        [Test] 
        public void CzyDobrzeLiczyPodatekZamowienia()//Dla klasy Zamowienie metoda Wartosc Podatku czy dobrze liczy
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            double stawkaVat = poz.stawkaVat;
            poz.cenaJednostkowa = 20000;

            zam.DodajPozycjeZamowienia(poz);

            var poz1 = new PozycjaZamowienia();
            poz1.nazwaTowaru = "nazwa1";
            poz1.ilosc = 2;
            poz1.stawkaVat = 9;
            double stawkaVat1 = poz1.stawkaVat;
            poz1.cenaJednostkowa = 100;
            zam.DodajPozycjeZamowienia(poz1);


            //var wynik = 0.23 * (5 * 20000) + 0.09 * (2 * 100);
            var wynik = (stawkaVat / 100 * (poz.ilosc * poz.cenaJednostkowa) + stawkaVat1 / 100 * (poz1.ilosc * poz1.cenaJednostkowa));

            Assert.That(zam.WartoscPodatku(), Is.EqualTo(wynik));

        }

        [Test] 
        public void CzyDobrzeLiczyPodatekZamowienia1()//Dla klasy Zamowienie metoda Wartosc Podatku czy dobrze liczy Przypadek 2
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            double stawkaVat = poz.stawkaVat;
            poz.cenaJednostkowa = 20000;


            zam.DodajPozycjeZamowienia(poz);


            var poz1 = new PozycjaZamowienia();
            poz1.nazwaTowaru = "nazwa1";
            poz1.ilosc = 2;
            poz1.stawkaVat = 18;
            double stawkaVat1 = poz1.stawkaVat;
            poz1.cenaJednostkowa = 120;
            zam.DodajPozycjeZamowienia(poz1);

            //var wynik = 0.23 * (5 * 20000) + 0.18 * (2 * 120);
            var wynik = (stawkaVat / 100 * (poz.ilosc * poz.cenaJednostkowa) + stawkaVat1 / 100 * (poz1.ilosc * poz1.cenaJednostkowa)) ;

            Assert.That(zam.WartoscPodatku(), Is.EqualTo(wynik));//sprawdza wartosc zamówienia czy jest zgodne

        }


        [Test] 
        public void TestZaplac()// Dla klasy Zamowienie metoda Oplac Zamowienie sprawdza czy zaplacone
        {
            var zam = new Zamowienie();
            var poz = new PozycjaZamowienia();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            zam.identyfikatorZamowienia = "jeden";
            zam.potwierdzenieElektroniczne = true;
            poz.nazwaTowaru = "nazwa";
            poz.ilosc = 5;
            poz.stawkaVat = 23;
            poz.cenaJednostkowa = 20000;

            zam.DodajPozycjeZamowienia(poz);

            byte raty = Convert.ToByte(20);
            string bank = "ING";
            float oprocentowanie = (float)Convert.ToDouble(20);
            var platnosc = new Kredyt(raty, bank, oprocentowanie);
            // platnosc.Zaplac(zam);
            Assert.IsTrue(zam.OplacZamowienie(platnosc));// wartośc bookowska czy zaplacone zamówiebnie
        }


        [TestMethod]
        public void TestMethod1()
        {

        }
    }

    internal class TestMethodAttribute : Attribute
    {
    }
}
