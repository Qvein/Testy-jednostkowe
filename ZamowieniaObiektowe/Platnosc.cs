using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public abstract class Platnosc
    {
        public double kwotaPlatnosci;
        public virtual bool Zaplac(Zamowienie zamowienie)
        {
            zamowienie.statusZamowienia = true;
            return true;
        }
        public virtual void WydrukPotwierdzenia()
        {
            return;
        }
    }
}
