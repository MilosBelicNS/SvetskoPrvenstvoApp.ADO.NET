using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8SvetskoPrvenstvo.Utils
{
    class IOPomocnaKlasa
    {

        public static bool ProveraDaLiJeBr(string broj)
        {
            bool retVal = false;
            int br;
            if (int.TryParse(broj, out br) == true)
            {
                retVal = true;
            }
            else
            {
                Console.WriteLine("Vas unos je pogresan!");
            }
            return retVal;
        }
        //citanje promenljive string
        public static string OcitajTekst()
        {
            string tekst = "";
            while (tekst == null || tekst.Equals(""))
                tekst = Console.ReadLine();

            return tekst;
        }

        //citanje promenljive integer
        public static int OcitajCeoBroj()
        {
            int ceoBroj = 0;
            string tekst;
            while (true)
            {
                tekst = Console.ReadLine();
                if (int.TryParse(tekst, out ceoBroj) == true)
                {
                    break;
                }
            }
            return ceoBroj;
        }

        //citanje promenljive double
        public static double OcitajRealanBroj()
        {
            double realanBroj = 0;
            string tekst;
            while (true)
            {
                tekst = Console.ReadLine();
                if (double.TryParse(tekst, out realanBroj) == true)
                {
                    break;
                }
            }
            return realanBroj;
        }

        //citanje promenljive char
        public static char OcitajKarakter()
        {
            char karakter = ' ';
            bool ocitan = false;
            while (ocitan == false)
            {
                karakter = Console.ReadKey().KeyChar;
                if (char.IsLetterOrDigit(karakter) == true)
                {
                    break;
                }
            }
            return karakter;
        }

        //citanje odluke (sme da bude samo Y ili N)
        public static char OcitajOdlukuOPotvrdi(string tekst)
        {
            Console.WriteLine("Da li zelite " + tekst + " [Y/N]:");
            char odluka = ' ';
            while (!(odluka == 'Y' || odluka == 'N'))
            {
                odluka = OcitajKarakter();
                if (!(odluka == 'Y' || odluka == 'N'))
                {
                    Console.WriteLine("Opcije su Y ili N");
                }
            }
            return odluka;
        }
    }
}
