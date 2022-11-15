using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using System.Configuration;
using InterfaceLaag.Interface;

namespace DAL
{
    public class ArtikelGroepMSSQL: IArtikelGroep
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public bool ArtikelGroepAanmaken(ArtikelGroepDTO artikelgroep)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand InsertArtikelGroep = new SqlCommand("INSERT INTO ArtikelGroep (Naam, Beschrijving) VALUES(@naam, @beschrijving)", con))
                    {
                        InsertArtikelGroep.Parameters.Add(new SqlParameter("naam", artikelgroep.Naam));
                        InsertArtikelGroep.Parameters.Add(new SqlParameter("beschrijving", artikelgroep.Beschrijving));
                        InsertArtikelGroep.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public List<ArtikelGroepDTO> ArtikelGroepBekijken()
        {
            List<ArtikelGroepDTO> artikelgroepen = new List<ArtikelGroepDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand ArtikelGroepOphalen = new SqlCommand("SELECT * FROM ArtikelGroep", con);

                SqlDataReader rdr = ArtikelGroepOphalen.ExecuteReader();

                while (rdr.Read())
                {
                    ArtikelGroepDTO artikelgroep = new ArtikelGroepDTO();

                    artikelgroep.GroepId = (int)rdr["groepid"];
                    artikelgroep.Naam = (string)rdr["naam"];
                    artikelgroep.Beschrijving = (string)rdr["beschrijving"];

                    artikelgroepen.Add(artikelgroep);
                }
                return artikelgroepen;
            }
        }

        public ArtikelGroepDTO ArtikelGroepDetails(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand ArtikelGroepOphalen = new SqlCommand("SELECT * FROM ArtikelGroep WHERE GroepID = @groepid", con);

                ArtikelGroepOphalen.Parameters.AddWithValue("@groepid", id);
                SqlDataReader rdr = ArtikelGroepOphalen.ExecuteReader();

                ArtikelGroepDTO artikelgroep = new ArtikelGroepDTO();
                while (rdr.Read())
                {
                    artikelgroep.GroepId = (int)rdr["groepid"];
                    artikelgroep.Naam = (string)rdr["naam"];
                    artikelgroep.Beschrijving = (string)rdr["beschrijving"];
                }
                return artikelgroep;
            }
        }

        public bool ArtikelGroepUpdaten(ArtikelGroepDTO artikelgroep)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand UpdateArtikelGroep = new SqlCommand("UPDATE ArtikelGroep SET Naam = @naam, Beschrijving = @beschrijving WHERE GroepId = @groepid", con))
                    {
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("groepid", artikelgroep.GroepId));
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("naam", artikelgroep.Naam));
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("beschrijving", artikelgroep.Beschrijving));
                        UpdateArtikelGroep.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public bool ArtikelGroepVerwijderen(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand UpdateArtikelGroep = new SqlCommand("DELETE FROM ArtikelGroep WHERE GroepId = @groepid;", con))
                    {
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("groepid", id));
                        UpdateArtikelGroep.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public bool Bewerken(ArtikelGroepDTO artikelgroep)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand UpdateArtikelGroep = new SqlCommand(
                        "UPDATE ArtikelGroep SET Naam = @naam, Beschrijving = @beschrijving WHERE GroepID = @groepid", con))
                    {
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("naam", artikelgroep.Naam));
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("beschrijving", artikelgroep.Beschrijving));
                        UpdateArtikelGroep.Parameters.Add(new SqlParameter("groepid", artikelgroep.GroepId));
                        UpdateArtikelGroep.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public ArtikelGroepDTO Ophalen(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand ArtikelGroepOphalen = new SqlCommand("SELECT * FROM ArtikelGroep WHERE GroepID = @groepid", con);

                ArtikelGroepOphalen.Parameters.AddWithValue("@groepid", id);
                SqlDataReader rdr = ArtikelGroepOphalen.ExecuteReader();

                ArtikelGroepDTO artikelgroepdto = new ArtikelGroepDTO();
                while (rdr.Read())
                {
                    artikelgroepdto.Naam = (string)rdr["naam"];
                    artikelgroepdto.Beschrijving = (string)rdr["beschrijving"];
                }
                return artikelgroepdto;
            }
        }

        public List<ArtikelGroepDTO> SelecteerList()
        {
            List<ArtikelGroepDTO> artikelgroepen = new List<ArtikelGroepDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand ArtikelGroepenOphalen = new SqlCommand("SELECT * FROM ArtikelGroep", con);

                SqlDataReader rdr = ArtikelGroepenOphalen.ExecuteReader();
                while (rdr.Read())
                {
                    ArtikelGroepDTO artikelgroep = new ArtikelGroepDTO();
                    artikelgroep.Naam = (string)rdr["naam"];
                    artikelgroep.Beschrijving = (string)rdr["beschrijving"];

                    artikelgroepen.Add(artikelgroep);
                }
            }
            return artikelgroepen;
        }

        public bool Verwijderen(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand DeleteArtikelGroep = new SqlCommand(
                        "DELETE FROM Artikel WHERE GroupID = @groupID; DELETE FROM ArtikelGroup WHERE GroupID = @groupID", con))
                    {
                        DeleteArtikelGroep.Parameters.Add(new SqlParameter("groupID", id));
                        DeleteArtikelGroep.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
    }
}
