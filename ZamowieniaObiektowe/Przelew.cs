using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Przelew:Platnosc
    {
        public string kontoBankowe;
        public string tytulPrzelewu;
        public Przelew(string konto, string tytul)
        {
            kontoBankowe = konto;
            tytulPrzelewu = tytul;
        }
        public override bool Zaplac(Zamowienie zamowienie)
        {
            if (kontoBankowe != null || tytulPrzelewu != null)
            {
                return base.Zaplac(zamowienie);
            }
            else
            {
                Console.WriteLine("Przy przelewie należy podać konto oraz tytuł przelewu");
                return false;
            }
        }
    }
}
