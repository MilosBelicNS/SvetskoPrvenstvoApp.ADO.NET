using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8SvetskoPrvenstvo.Model
{
    class Drzava
    {

        public int Id { get; set; }
        public string Naziv { get; set; }


        public Drzava()
        {

        }

        public Drzava(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }


        public override string ToString()
        {
            return "Drzava [" + "Id: " + Id + "]" + " " + "[ Naziv: " + Naziv + "]"; 
        }
    }
}
