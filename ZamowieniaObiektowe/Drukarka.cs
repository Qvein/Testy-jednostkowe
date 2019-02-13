using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Drukarka : INotatka
    {
        public void wydrukPotwierdzenia()
        {
            Console.WriteLine("Drukowanie potwierdzenia na drukarce");
        }
    }
}
