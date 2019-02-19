using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    class Program
    {
        static List<Zamowienie> zamowienia = new List<Zamowienie>();
        static void Main(string[] args)
        {
            Console.WriteLine("--------------- APLIKACJA ZAMOWIENIA ----------------");
    
            bool wyjscie = false;
            while(!wyjscie)
            {
                Console.WriteLine("Wybierz operacje");
                Console.WriteLine("1. Nowe zamówienie");
                Console.WriteLine("2. Wyswietl zamówienia");
                Console.WriteLine("3. Opłać zamówienie");
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.KeyChar == '1')
                {
                    NoweZamowienie();
                }
                if (info.KeyChar == '2')
                {
                    WyswietlZamowienia();
                }
                if(info.KeyChar == '3')
                {
                    OplacZamowienie();
                }
            }
        }

        static void OplacZamowienie()
        {
            Console.WriteLine("Podaj identyfikator zamówienia");
            string identyfikator = Console.ReadLine();
            Zamowienie zam = zamowienia.Where(x => x.identyfikatorZamowienia == identyfikator).FirstOrDefault();
            if(zam != null)
            {
                Console.WriteLine("Wybierz metodę płatności");
                Console.WriteLine("1. Gotówka");
                Console.WriteLine("2. Przelew");
                Console.WriteLine("3. Kredyt");
                ConsoleKeyInfo info = Console.ReadKey();
                Platnosc platnosc;
                bool czyOplacono = false;
                if (info.KeyChar == '1')
                {
                    platnosc = new Gotowka();
                    czyOplacono = zam.OplacZamowienie(platnosc);
                }
                if (info.KeyChar == '2')
                {
                    Console.WriteLine("Podaj konto bankowe");
                    string konto = Console.ReadLine();
                    Console.WriteLine("Podaj Tytuł przelewu");
                    string tytul = Console.ReadLine();
                    platnosc = new Przelew(konto,tytul);
                    czyOplacono = zam.OplacZamowienie(platnosc);
                }
                if (info.KeyChar == '3')
                {
                    Console.WriteLine("Podaj ilość rat");
                    byte raty = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Podaj nazwę banku");
                    string bank = Console.ReadLine();
                    Console.WriteLine("Podaj oprocentowanie");
                    float oprocentowanie = (float)Convert.ToDouble(Console.ReadLine());
                    platnosc = new Kredyt(raty,bank, oprocentowanie);
                    czyOplacono = zam.OplacZamowienie(platnosc);
                }
                if(czyOplacono)
                {
                    zam.DrukujPotwierdzenie();
                }
               
            }
            else
            {
                Console.WriteLine("Nie znaleziono zamówienia o podanym identyfikatorze");
            }
        }

        static void WyswietlZamowienia()
        {
            Console.WriteLine("--------------- LISTA ZAMOWIEŃ W SYSTEMIE ------------------");
            foreach(Zamowienie z in zamowienia)
            {
                Console.WriteLine("Zamówienie " + z.identyfikatorZamowienia + ", Data realizacji: " + z.dataRealizacji + ", Status:" + (z.statusZamowienia == true ? "Opłacone" : "Nieopłacone") + " Wartość:" + z.WartoscZamowienia() + " Podatek:" + z.WartoscPodatku());
            }
            Console.WriteLine("-------------------------------------------------------------");
        }

        static void NoweZamowienie()
        {
            Zamowienie zam = new Zamowienie();
            zam.dataRealizacji = DateTime.Now;
            zam.statusZamowienia = false;
            Console.WriteLine("Podaj identyfikator zamówienia");
            string identyfikator = Console.ReadLine();
            if(zamowienia.Where(x=>x.identyfikatorZamowienia == identyfikator).Count()>0)
            {
                Console.WriteLine("Jest już taki identyfikator zamówienia");
                return;
            }
            zam.identyfikatorZamowienia = identyfikator;
            Console.WriteLine("Czy potwierdzenie elektroniczne? t/n");
            string tn = "";
            while(tn!="t" && tn!="n")
            {
                ConsoleKeyInfo info = Console.ReadKey();
                tn = info.KeyChar.ToString();
            }
            if (tn == "t") zam.potwierdzenieElektroniczne = true;
            else zam.potwierdzenieElektroniczne = false;
            bool zakoncz = false;
            do
            {
                Console.WriteLine("Dodawanie pozycji zamówienia");
                DodajPozycje(zam);
                Console.WriteLine("Czy chcesz dodać jeszcze jedną pozycję? t/n");
                tn = "";
                while (tn != "t" && tn != "n")
                {
                    ConsoleKeyInfo info = Console.ReadKey();
                    tn = info.KeyChar.ToString();
                }
                if (tn == "n") zakoncz = true;

            } while (!zakoncz);
            if(zam.pozycjeZamowienia.Count()>0) zamowienia.Add(zam);
            else
            {
                Console.WriteLine("Nie można dodać zamówienia bez pozycji");
            }
        }

        static void DodajPozycje(Zamowienie zam)
        {
            PozycjaZamowienia poz = new PozycjaZamowienia();
            try
            {
                Console.WriteLine("Podaj indeks towaru:");
                poz.nazwaTowaru = Console.ReadLine();
                Console.WriteLine("Podaj ilość:");
                poz.ilosc = (float)Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj stawkę vat:");
                poz.stawkaVat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Podaj cenę jednostkową:");
                string cena =  Console.ReadLine();
                poz.cenaJednostkowa = (float)Convert.ToDouble(cena);
               zam.DodajPozycjeZamowienia(poz);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Podałeś niepoprawną wartość");
            }
        }
    }
}
