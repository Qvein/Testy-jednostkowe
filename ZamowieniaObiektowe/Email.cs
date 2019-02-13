using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamowieniaObiektowe
{
    public class Email : INotatka
    {
        public string adresEmail;
        public Email(string email)
        {
            adresEmail = email;
        }
        public void wydrukPotwierdzenia()
        {

            if(adresEmail==null || adresEmail == "")
            {
                Console.WriteLine("Nie podano adresu email");
                return;
            }
            Console.WriteLine("Wysylanie potwierdzenia na adres email "+adresEmail);
        }
    }
}
