using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Gotowka:Platnosc
    {
        public override bool Zaplac(Zamowienie zamowienie)
        {
            return base.Zaplac(zamowienie);
        }
    }
}
