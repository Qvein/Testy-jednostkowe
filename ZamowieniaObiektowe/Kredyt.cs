using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Kredyt:Platnosc
    {
        public byte liczbaRat;
        public string bank;
        public float oprocentowanieRoczne;
        public Kredyt(byte ileRat,string jakiBank, float oprocontowanie)
        {
            liczbaRat = ileRat;
            bank = jakiBank;
            oprocentowanieRoczne = oprocontowanie;
        }
        public override bool Zaplac(Zamowienie zamowienie)
        {
            if (liczbaRat != 0 && bank != null)
            {
                return base.Zaplac(zamowienie);
                
            }
            else
            {
                Console.WriteLine("Przy kredycie należy podać liczbę rat, bank oraz oprocentowanie");
                return false;
            }
        }
    }
}
