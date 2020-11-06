using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin8SvetskoPrvenstvo.DAO
{
    class DAOConnection
    {

        public const string connectionString = @"Data Source=DESKTOP-GC0HF6E\SQLEXPRESS;Initial Catalog=DotNetMilos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        /* Kada nekom delu aplikacije bude neophodna konekcija za bazu podataka, taj deo aplikacije je moze zatraziti koristeci ovu metodu */
        public static SqlConnection TraziNovuKonekciju()
        {
            /* Pripremamo objekat za konekciju */
            SqlConnection novaKonekcija = new SqlConnection(connectionString);

            /* Pokusavamo da otvorimo konekciju */
            novaKonekcija.Open();

            /* Otvorenu konekciju vracamo onome ko ju je zahtevao */
            return novaKonekcija;
        }
    }
}
