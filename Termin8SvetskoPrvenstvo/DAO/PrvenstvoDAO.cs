using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8SvetskoPrvenstvo.Model;

namespace Termin8SvetskoPrvenstvo.DAO
{
    class PrvenstvoDAO
    {
        public static Prvenstvo GetPrvenstvoByName(string name)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();

            Prvenstvo prvenstvo = null;
            try
            {


                string query = "select id, naziv, godinaOdrzavanja, drzavaDomacin, drzavaOsvajac from Prvenstva where naziv='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = (int)rdr["id"];
                    string nazivP = (string)rdr["naziv"];
                    int godina = (int)rdr["godinaOdrzavanja"];
                    Drzava domacinP = DrzavaDAO.GetDrzavaById(id);
                    Drzava osvajacP = DrzavaDAO.GetDrzavaById(id);



                    prvenstvo = new Prvenstvo(id, nazivP, godina, domacinP, osvajacP);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return prvenstvo;
        }


        public static Prvenstvo GetPrvenstvoById(int id)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();

            Prvenstvo prvenstvo = null;
            try
            {


                string query = "select naziv, godinaOdrzavanja, drzavaDomacin, drzavaOsvajac from Prvenstva where id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    
                    string nazivP = (string)rdr["naziv"];
                    int godina = (int)rdr["godinaOdrzavanja"];
                    int id_drzavaDomacin = (int)rdr["drzavaDomacin"];
                    Drzava domacinP = DrzavaDAO.GetDrzavaById(id_drzavaDomacin);
                    int id_drzavaOsvajac = (int)rdr["drzavaOsvajac"];
                    Drzava osvajacP = DrzavaDAO.GetDrzavaById(id_drzavaOsvajac);



                    prvenstvo = new Prvenstvo(id, nazivP, godina, domacinP, osvajacP);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return prvenstvo;
        }


        public static List<Prvenstvo> GetAll()
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            List<Prvenstvo> prvenstva = new List<Prvenstvo>();
            try
            {

                string query = "select id, naziv, godinaOdrzavanja, drzavaDomacin, drzavaOsvajac from Prvenstva";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["id"];
                    string nazivD = (string)rdr["naziv"];
                    int godinaOdrzavanja = (int)rdr["godinaOdrzavanja"];
                    int id_domacin = (int)rdr["drzavaDomacin"];
                    Drzava domacin = DrzavaDAO.GetDrzavaById(id_domacin);
                    int id_osvajac = (int)rdr["drzavaOsvajac"];
                    Drzava osvajac = DrzavaDAO.GetDrzavaById(id_osvajac);

                    Prvenstvo prvenstvo = new Prvenstvo(id, nazivD, godinaOdrzavanja, domacin, osvajac);
                    prvenstva.Add(prvenstvo);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();

            }
            return prvenstva;
        }

        public static List<Prvenstvo> SerarchAll(int a, int b)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            List<Prvenstvo> prvenstva = new List<Prvenstvo>();
            try
            {

                string query = "select * from Prvenstva where godinaOdrzavanja >= " + a + "and godinaOdrzavanja <=" + b;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr["id"];
                    string nazivD = (string)rdr["naziv"];
                    int godinaOdrzavanja = (int)rdr["godinaOdrzavanja"];
                    int id_domacin = (int)rdr["drzavaDomacin"];
                    Drzava domacin = DrzavaDAO.GetDrzavaById(id_domacin);
                    int id_osvajac = (int)rdr["drzavaOsvajac"];
                    Drzava osvajac = DrzavaDAO.GetDrzavaById(id_osvajac);

                    Prvenstvo prvenstvo = new Prvenstvo(id, nazivD, godinaOdrzavanja, domacin, osvajac);
                    prvenstva.Add(prvenstvo);
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();

            }
            return prvenstva;
        }


        public static bool Add(Prvenstvo prvenstvo)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            bool retVal = false;
            try
            {

                string query = "insert into Prvenstva (naziv, godinaOdrzavanja, drzavaDomacin, drzavaOsvajac) "
                    +"values (@naziv, @godinaOdrzavanja,@drzavaDomacin, @drzavaOsvajac)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naziv", prvenstvo.Naziv);
                cmd.Parameters.AddWithValue("@godinaOdrzavanja", prvenstvo.Godina);
                cmd.Parameters.AddWithValue("@drzavaDomacin", prvenstvo.Domacin.Id);
                cmd.Parameters.AddWithValue("@drzavaOsvajac", prvenstvo.Osvajac.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return retVal;
        }



        public static bool Delete(int id)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            bool retVal = false;
            try
            {


                string query = "delete from Prvenstva where id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return retVal;
        }


        public static bool Update(Prvenstvo prvenstvo)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            bool retVal = false;
            try
            {


                string query = "update Prvenstva set naziv=@naziv, godinaOdrzavanja=@godinaOdrzavanja, drzavaDomacin=@drzavaDomacin, drzavaOsvajac=@drzavaOsvajac where id=@id";// + drzava.Id;
                SqlCommand cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@naziv", prvenstvo.Naziv);
                cmd.Parameters.AddWithValue("@id", prvenstvo.Id);
                cmd.Parameters.AddWithValue("@godinaOdrzavanja", prvenstvo.Godina);
                cmd.Parameters.AddWithValue("@drzavaDomacin", prvenstvo.Domacin.Id);
                cmd.Parameters.AddWithValue("@drzavaOsvajac", prvenstvo.Osvajac.Id);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return retVal;
        }



    }
}
