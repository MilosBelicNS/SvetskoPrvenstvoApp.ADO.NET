using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin8SvetskoPrvenstvo.Model;

namespace Termin8SvetskoPrvenstvo.DAO
{
    class DrzavaDAO
    {

        public static Drzava GetDrzavaByName(string name)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();

            Drzava drzava = null;
            try
            {
                

                string query = "select id, naziv from Drzave where naziv='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    int id = (int)rdr[0];
                    string nazivD = (string)rdr[1];
                    


                    drzava = new Drzava(id, nazivD);
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
            return drzava;
        }

        public static Drzava GetDrzavaById(int id)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            Drzava drzava = null;
            try
            {
                
                string query = "select naziv from Drzave where id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    string nazivD = (string)rdr["naziv"];
                   
                    drzava = new Drzava(id, nazivD);
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
            return drzava;
        }


        public static List<Drzava> GetAll()
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            List<Drzava> drzave = new List<Drzava>();
            try
            {
               
                string query = "select id, naziv from Drzave";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = (int)rdr[0];
                    string nazivD = (string)rdr[1];
                    
                     Drzava drzava = new Drzava(id, nazivD);
                    drzave.Add(drzava);
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
            return drzave;
        }
        public static bool Add(Drzava drzava)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            bool retVal = false;
            try
            {

                string query = "insert into Drzave (naziv) values (@naziv)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naziv", drzava.Naziv);
              

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

               
                string query = "delete from Drzave where id=" + id;
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

        public static bool Update(Drzava drzava)
        {
            SqlConnection conn = DAOConnection.TraziNovuKonekciju();
            bool retVal = false;
            try
            {


                string query = "update Drzave set naziv=@naziv where id=@id";// + drzava.Id;
                SqlCommand cmd = new SqlCommand(query, conn);

              
                cmd.Parameters.AddWithValue("@naziv", drzava.Naziv);
                cmd.Parameters.AddWithValue("@id", drzava.Id);


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
