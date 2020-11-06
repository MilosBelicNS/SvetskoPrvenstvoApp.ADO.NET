using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8SvetskoPrvenstvo.Model
{
    class Prvenstvo
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Godina { get; set; }
        public Drzava Domacin { get; set; }
        public Drzava Osvajac { get; set; }


        public Prvenstvo()
        {

        }

        public Prvenstvo(int id, string naziv, int godina, Drzava domacin, Drzava osvajac)
        {
            Id = id;
            Naziv = naziv;
            Godina = godina;
            Domacin = domacin;
            Osvajac = osvajac;
        }

        public override string ToString()
        {
           string ispis = string.Format("\tSVETSKO PRVENSTVO [ID:{0}]\nNaziv:[{1}]\nGodina odrzavanja:[{2}]", Id, Naziv, Godina);
            string ispis1 = string.Format("[Domacin]:\t[Id:{0}]\tIme:{1}", Domacin.Id, Domacin.Naziv);
            string ispis2 = string.Format("[Osvajac]:\t[Id:{0}]\tIme:{1}", Osvajac.Id, Osvajac.Naziv);



            string konacanispis = ispis + "\n" + ispis1 + "\n" + ispis2;

            return konacanispis;
           
        }
    }
}
