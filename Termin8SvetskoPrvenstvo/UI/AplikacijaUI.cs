using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8SvetskoPrvenstvo.Utils;

namespace Termin8SvetskoPrvenstvo.UI
{
    class AplikacijaUI
    {

        public static void IspisiMenu()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\t SVETSKO PRVENSTVO - OPCIJE:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOpcija  1 - Drzave");
            Console.WriteLine("\tOpcija  2 - Prvenstva");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija  0 - Izlaz.");
            Console.WriteLine("-----------------------------------------------------");

        }
        public static void Meni()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMenu();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Izlaz");
                        break;
                    case 1:
                        DrzavaUI.Meni();
                        break;
                    case 2:
                        PrvenstvoUI.MeniPrvenstva();
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}
