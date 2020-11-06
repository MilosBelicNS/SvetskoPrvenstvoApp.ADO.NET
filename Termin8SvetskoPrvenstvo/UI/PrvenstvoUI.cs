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
    class PrvenstvoUI
    {


        public static void IspisiMeni()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Prvenstva - opcije:");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tOpcija 1 - Ispisi sva prvenstva");
            Console.WriteLine("\tOpcija 2 - Unesi novo prvenstvo");
            Console.WriteLine("\tOpcija 3 - Obrisi prvenstvo");
            Console.WriteLine("\tOpcija 4 - Izmeni prvenstvo");
            Console.WriteLine("\tOpcija 5 - Pretraga prvenstva po godini");
            Console.WriteLine("\t\t ...");
            Console.WriteLine("\tOpcija 0 - Izlaz");
            Console.WriteLine("-----------------------------------------------------");
        }
        public static void MeniPrvenstva()
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
                        IspisiSvaPrvenstva();
                        break;
                    case 2:
                        UnesiPrvenstvo();
                        break;
                    case 3:
                        BrisanjepPrvenstva();
                        break;
                    case 4:
                        IzmenaPrvenstva();
                        break;
                    case 5:
                        IspisiFiltriranaPrvenstva();
                            break;
                    default:
                        break;
                }

            }
        }


        //METODA ZA ISPIS Prvenstva
        public static void IspisiSvaPrvenstva()
        {
            List<Prvenstvo> prvenstva = PrvenstvoDAO.GetAll();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("\tSVA PRVENSTVA:");
            Console.WriteLine("-----------------------------------------------------");
           foreach (Prvenstvo prvenstvo in prvenstva.OrderBy(x => x.Godina))
            {
                Console.WriteLine(prvenstvo);
                Console.WriteLine("-----------------------------------------------------");
            }
        }


        //metoda za pretragu po godini odrzavanja
      /*  public static void PretragaPoGodini()
        {


            Console.Write("Unesite pocetnu godinu pretrage: ");
            int pocetak = IOPomocnaKlasa.OcitajCeoBroj();
            Console.Write("Unesite krajnju godinu pretrage: ");
            int kraj = IOPomocnaKlasa.OcitajCeoBroj();

            List<Prvenstvo> prvenstva = PrvenstvoDAO.GetAll();

           

            var list = prvenstva.FindAll(x => x.Godina > pocetak && x.Godina < kraj).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }


        }*/

        public static List<Prvenstvo> SearchByGodina()
        {
            Console.Write("Unesi pocetnu godinu prvenstva: ");
            int a = IOPomocnaKlasa.OcitajCeoBroj();
            Console.Write("Unesi krajnju godinu prvenstva: ");
            int b = IOPomocnaKlasa.OcitajCeoBroj();

            List<Prvenstvo> filtriranaPrvenstva = PrvenstvoDAO.SerarchAll(a, b);


            return filtriranaPrvenstva;

        }

        public static void IspisiFiltriranaPrvenstva()
        {
                List<Prvenstvo> prvenstva = SearchByGodina();

                Console.WriteLine("-------------------PRVENSTVA------------------\n");

            foreach(Prvenstvo p in prvenstva)
            {
                Console.WriteLine("-----------------************-----------------\n");
                Console.WriteLine(p);
                Console.WriteLine("----------------------------------------------\n");
            }
        }
       /* public static void PreuzmiFiltriranaPrvenstva()
        {
            List<Prvenstvo> prvenstva = null;
            Console.Write("Unesi pocetnu godinu pretrage: ");
            int pocetak = IOPomocnaKlasa.OcitajCeoBroj();

        }*/

        //METODE ZA PRETRAGU Prvenstva 
        public static Prvenstvo PronadjiPrvenstvoPoId(int id)
        {
            Prvenstvo retVal = PrvenstvoDAO.GetPrvenstvoById(id);
            return retVal;

        }
        public static Prvenstvo PreuzmiPrvenstvoPoId()
        {
            Prvenstvo retVal = null;
            Console.Write("Unesi id prvenstva :");
            int id = IOPomocnaKlasa.OcitajCeoBroj();
            retVal = PronadjiPrvenstvoPoId(id);
            if (retVal == null)
            {
                Console.WriteLine("Prvenstvo sa id:" + id + " ne porstoji!");
            }

            return retVal;

        }


        public static Prvenstvo PronajdiPrvenstvoPoNazivu(string naziv)
        {
            Prvenstvo prvenstvo = PrvenstvoDAO.GetPrvenstvoByName(naziv);
            return prvenstvo;
        }


        //metode za unos i brisanje
        public static void UnesiPrvenstvo()
        {
            IspisiSvaPrvenstva();

            Prvenstvo prvenstvo = new Prvenstvo();
            prvenstvo.Id = 0;
            Console.Write("Unesi naziv prvenstva: ");
            string aName = Console.ReadLine();
            while(PronajdiPrvenstvoPoNazivu(aName) !=null)
            {
                Console.WriteLine("Prvensto sa imenom:" + aName + " vec postoji!");
                aName = IOPomocnaKlasa.OcitajTekst();
            }
            prvenstvo.Naziv = aName;

            Console.Write("Unesi godinu odrzavanja: ");
            int aGodina = IOPomocnaKlasa.OcitajCeoBroj();
            prvenstvo.Godina = aGodina;

            DrzavaUI.IspisiSveDrzave();
            Console.WriteLine("Izaberi postojecu drzavu kao domacina ili unesi novu drzavu domacina(1 ili 2):");
            int answer = IOPomocnaKlasa.OcitajCeoBroj();
            if (answer == 1)
            {
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi drzavu domacina: ");
                string drzavaId = Console.ReadLine();
                int drzavaDomacinId;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    drzavaDomacinId = int.Parse(drzavaId);
                    prvenstvo.Domacin = DrzavaDAO.GetDrzavaById(drzavaDomacinId);
                }
            }
             else if (answer == 2)
            {
                DrzavaUI.UnosNoveDrzave();
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Uspesno dodavanje! Sada izaberite id drzave domacina: ");
                string drzavaId = Console.ReadLine();
                int domacinId;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    domacinId = int.Parse(drzavaId);
                    prvenstvo.Domacin = DrzavaDAO.GetDrzavaById(domacinId);
                }


            }
          
            
            DrzavaUI.IspisiSveDrzave();
            Console.WriteLine("Izaberi postojecu drzavu kao osvajaca ili unesi novu drzavu osvajaca(1 ili 2):");
            int answer1 = IOPomocnaKlasa.OcitajCeoBroj();
            if (answer1 == 1)
            {
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi id drzave osvajaca: ");
                string drzavaId = Console.ReadLine();
                int OsvajacId1;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    OsvajacId1 = int.Parse(drzavaId);
                    prvenstvo.Osvajac = DrzavaDAO.GetDrzavaById(OsvajacId1);
                }
            }
            else if (answer1 == 2)
            {
                DrzavaUI.UnosNoveDrzave();
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Uspesno dodavanje drzave! Izaberi id drzave osvajaca: ");
                string drzavaId = Console.ReadLine();
                int osvajacId1;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    osvajacId1 = int.Parse(drzavaId);
                    prvenstvo.Osvajac = DrzavaDAO.GetDrzavaById(osvajacId1);
                }


            }
           

            PrvenstvoDAO.Add(prvenstvo);
            Console.WriteLine("Uspesno dodavanje prvenstva!");
            IspisiSvaPrvenstva();



        }


        public static void BrisanjepPrvenstva()
        {
            IspisiSvaPrvenstva();
            Prvenstvo prvenstvo = PreuzmiPrvenstvoPoId();
            if (prvenstvo != null)
            {
                PrvenstvoDAO.Delete(prvenstvo.Id);
            }
        }


        //update metoda

        public static void IzmenaPrvenstva()
        {
            IspisiSvaPrvenstva();
            Prvenstvo prvenstvo = PreuzmiPrvenstvoPoId();


            Console.WriteLine("Unesi novi naziv prvenstva");
            string nazivD = IOPomocnaKlasa.OcitajTekst();

            while (PronajdiPrvenstvoPoNazivu(nazivD) != null)
            {
                Console.WriteLine("Prvenstvo sa imenom:" + nazivD + " vec postoji!");
                nazivD = IOPomocnaKlasa.OcitajTekst();
            }
            prvenstvo.Naziv = nazivD;//nov naziv

            Console.Write("Unesi novu godinu odrzavanja: ");
            int aGodina = IOPomocnaKlasa.OcitajCeoBroj();
            prvenstvo.Godina = aGodina;//nova godina odrzavanja

            DrzavaUI.IspisiSveDrzave();
            Console.WriteLine("Izaberi postojecu drzavu domacina ili unesi novu drzavu domacina(1 ili 2):");
            int answer = IOPomocnaKlasa.OcitajCeoBroj();
            if (answer == 1)
            {
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi drzavu domacina: ");
                string drzavaId = Console.ReadLine();
                int drzavaDomacinId;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    drzavaDomacinId = int.Parse(drzavaId);
                    prvenstvo.Domacin = DrzavaDAO.GetDrzavaById(drzavaDomacinId);//postojeca nova drzava domacin
                }
            }
            else if (answer == 2)
            {
                DrzavaUI.UnosNoveDrzave();
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi id drzavu domacina: ");
                string drzavaId = Console.ReadLine();
                int domacinId;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    domacinId = int.Parse(drzavaId);
                    prvenstvo.Domacin = DrzavaDAO.GetDrzavaById(domacinId);//nova drzava domacin
                }


            }
            DrzavaUI.IspisiSveDrzave();
            Console.WriteLine("Izaberi postojecu drzavu osvajaca ili unesi novu drzavu osvajaca(1 ili 2):");
            int answer1 = IOPomocnaKlasa.OcitajCeoBroj();
            if (answer1 == 1)
            {
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi id drzave osvajaca: ");
                string drzavaId = Console.ReadLine();
                int OsvajacId1;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    OsvajacId1 = int.Parse(drzavaId);
                    prvenstvo.Osvajac = DrzavaDAO.GetDrzavaById(OsvajacId1);//nov postojeci osvajac
                }
            }
            else if (answer1 == 2)
            {
                DrzavaUI.UnosNoveDrzave();
                DrzavaUI.IspisiSveDrzave();
                Console.WriteLine("Izaberi id drzave osvajaca: ");
                string drzavaId = Console.ReadLine();
                int osvajacId1;
                bool provera = IOPomocnaKlasa.ProveraDaLiJeBr(drzavaId);
                if (provera == true)
                {
                    osvajacId1 = int.Parse(drzavaId);
                    prvenstvo.Osvajac = DrzavaDAO.GetDrzavaById(osvajacId1);//nov osvajac
                }


            }

            
            PrvenstvoDAO.Update(prvenstvo);
            Console.WriteLine("Uspesna izmena prvenstva!");
            IspisiSvaPrvenstva();


        }


        
    }
}
