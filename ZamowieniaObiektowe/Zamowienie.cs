using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Zamowienie
    {
        public DateTime dataRealizacji;
        public bool statusZamowienia;
        public string identyfikatorZamowienia;
        public bool potwierdzenieElektroniczne;
        public List<PozycjaZamowienia> pozycjeZamowienia;

        public Zamowienie()
        {
            pozycjeZamowienia = new List<PozycjaZamowienia>();
        }

        public double WartoscZamowienia()
        {
            double wartosc = pozycjeZamowienia.Sum(x => x.ObliczBrutto());
            return wartosc;
        }

        public double WartoscPodatku()
        {
            double wartosc = pozycjeZamowienia.Sum(x => x.ObliczPodatek());
            return wartosc;
        }

        public bool DodajPozycjeZamowienia(PozycjaZamowienia pozycja)
        {
            pozycjeZamowienia.Add(pozycja);
            return true;
        }

        public void DrukujPotwierdzenie()
        {
            INotatka potwierdzenie;
            if(potwierdzenieElektroniczne)
            {
                Console.WriteLine("Podaj adres email dla potwierdzenia");
                string email = Console.ReadLine();
                potwierdzenie = new Email(email);
            }
            else
            {
                potwierdzenie = new Drukarka();
            }
            potwierdzenie.wydrukPotwierdzenia();
        }

        public bool OplacZamowienie(Platnosc platnosc)
        {
            bool result = platnosc.Zaplac(this);
            return result;
        }
    }
}
