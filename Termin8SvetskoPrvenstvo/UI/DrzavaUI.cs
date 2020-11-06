using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8SvetskoPrvenstvo.DAO;
using Termin8SvetskoPrvenstvo.Model;
using Termin8SvetskoPrvenstvo.Utils;

namespace Termin8SvetskoPrvenstvo.UI
{
    class DrzavaUI
    {

        public static void IspisiMeni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Drzave - opcije:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOpcija 1 - Ispisi sve drzave");
            Console.WriteLine("\tOpcija 2 - Unesi novu drzavu");
            Console.WriteLine("\tOpcija 3 - Obrisi drzavu");
            Console.WriteLine("\tOpcija 4 - Izmeni drzavu");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija 0 - Izlaz");
            Console.WriteLine("-----------------------------------------------------");
        }
        public static void Meni()
        {
            int odluka = -1;
            while (odluka != 0)
            {
                IspisiMeni();
                Console.Write("Opcija:");
                odluka = IOPomocnaKlasa.OcitajCeoBroj();
                Console.Clear();
                switch (odluka)
                {
                    case 0:
                        Console.WriteLine("Out!");
                        break;
                    case 1:
                        IspisiSveDrzave();
                        break;
                    case 2:
                        UnosNoveDrzave();
                        break;
                    case 3:
                        BrisanjeDrzave();
                        break;
                    case 4:
                        IzmenaDrzave();
                            break;
                    default:
                        break;
                }

            }
        }
        //METODA ZA ISPIS Drzava
        public static void IspisiSveDrzave()
        {
            List<Drzava> drzave = DrzavaDAO.GetAll();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tSVE DRZAVE:");
            Console.WriteLine("-----------------------------------------------------");
            foreach (Drzava drzava in drzave.OrderBy(x => x.Id))
            {
                Console.WriteLine(drzava);
                Console.WriteLine("-----------------------------------------------------");
            }
        }
        //METODE ZA PRETRAGU Drzava 
        public static Drzava PronadjiDrzavuPoId(int id)
        {
            Drzava retVal = DrzavaDAO.GetDrzavaById(id);
            return retVal;

        }
        public static Drzava PreuzmiiDrzavuPoId()
        {
            Drzava retVal = null;
            Console.Write("Unesi id drzave :");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiDrzavuPoId(id);
            if (retVal == null)
            {
                Console.WriteLine("Drzava sa id:" + id + " ne porstoji!");
            }
            
            return retVal;
           
        }
        public static Drzava PronajdiDrzavuPoNazivu(string naziv)
        {
            Drzava drzava = DrzavaDAO.GetDrzavaByName(naziv);
            return drzava;
        }
        //public static Drzava PreuzmiDrzavuPoNazivu()
        //{
        //    Drzava retVal = null;
        //    Console.WriteLine("Unesi naziv drzave:");
        //    string name = IOPomocnaKlasa.OcitajTekst();
        //    retVal = PronajdiDrzavuPoNazivu(name);
        //    if (retVal == null)
        //    {
        //        Console.WriteLine("Drzava sa imenom: " + name + " ne postoji!");
        //    }
        //    return retVal;
        //}
        //METODE ZA UNOS I BIRSANJE Drzava
        public static void UnosNoveDrzave()
        {
            Console.WriteLine("Unesi naziv drzave:");
            string stName = IOPomocnaKlasa.OcitajTekst();
            
            while (PronajdiDrzavuPoNazivu(stName) != null)
            {
                Console.WriteLine("Drzava sa imenom:" + stName + " vec postoji!");
                stName = IOPomocnaKlasa.OcitajTekst();
            }
           
            Drzava drzava = new Drzava(0, stName);
            DrzavaDAO.Add(drzava);

            Console.WriteLine("Uspesno dodavanje!");
        }
        public static void BrisanjeDrzave()
        {
            IspisiSveDrzave();
            Drzava drzava = PreuzmiiDrzavuPoId();
            if (drzava != null)
            {
                DrzavaDAO.Delete(drzava.Id);
                Console.WriteLine("Uspesno brisanje!");
            }
        }

        public static void IzmenaDrzave()
        {
            IspisiSveDrzave();
            Drzava drzava = PreuzmiiDrzavuPoId();
            
            
                Console.WriteLine("Unesi novi naziv drzave");
                string nazivD = IOPomocnaKlasa.OcitajTekst();

            while (PronajdiDrzavuPoNazivu(nazivD) != null)
            {
                Console.WriteLine("Drzava sa imenom:" + nazivD + " vec postoji!");
                nazivD = IOPomocnaKlasa.OcitajTekst();
            }
            drzava.Naziv = nazivD;

                //drzava = new Drzava(0, nazivD);
                DrzavaDAO.Update(drzava);
                Console.WriteLine("Uspesna izmena!");





        }
    }
}
