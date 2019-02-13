using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class PozycjaZamowienia
    {
        public string nazwaTowaru;
        public float cenaJednostkowa;
        public int stawkaVat;
        public float ilosc;

        public double ObliczBrutto()
        {
            double wartosc = ilosc * (cenaJednostkowa+(cenaJednostkowa*stawkaVat/100));
            return wartosc;
        }

        public double ObliczPodatek()
        {
            double podatek = ilosc * (cenaJednostkowa * stawkaVat / 100);
            return podatek;
        }
    }
}
