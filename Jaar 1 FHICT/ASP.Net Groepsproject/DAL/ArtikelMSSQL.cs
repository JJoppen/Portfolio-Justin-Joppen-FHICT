using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.IDal;
using System.Configuration;

namespace DAL
{
    public class ArtikelMSSQL : IArtikelDal
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;
        public List<ArtikelDTO> SelecteerArtikelList()
        {
            List<ArtikelDTO> DTOs = new List<ArtikelDTO>();
            List<ArtikelDTO> artikelDTOs = new List<ArtikelDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand select = new SqlCommand(
                        "SELECT Artikel.ArtikelNaam, Artikel.ArtikelNummer,Artikel.Id, Artikel.Prijs, Artikel.Aantal, Artikel.Beschrijving, Artikel.THT, ArtikelGroep.GroepID, Artikel.Afmeting, Artikel.Kleur, Artikel.Gewicht, ArtikelGroep.Naam FROM Artikel INNER JOIN ArtikelGroep ON Artikel.GroepID=ArtikelGroep.GroepID", con))
                    {
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ArtikelGroepDTO retdto = new ArtikelGroepDTO();
                                ArtikelDTO dto = new ArtikelDTO();
                                retdto.Naam = (string)reader["Naam"];
                                retdto.GroepId = Convert.ToInt32(reader["GroepID"]);
                                dto.artikelGroep = retdto;
                                dto.Naam = reader["ArtikelNaam"].ToString();
                                dto.ArtikelID = (int)reader["Id"];
                                dto.ArtikelNummer = Convert.ToInt32(reader["ArtikelNummer"]);
                                dto.Prijs = Convert.ToDouble(reader["Prijs"]);
                                dto.Aantal = Convert.ToInt32(reader["Aantal"]);
                                dto.Beschrijving = reader["Beschrijving"].ToString();
                                dto.Tht = (DateTime)reader["THT"];
                                dto.Afmeting = reader["Afmeting"].ToString();
                                dto.Kleur = reader["Kleur"].ToString();
                                dto.Gewicht = Convert.ToInt32(reader["Gewicht"]);
                                DTOs.Add(dto);

                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                con.Close();
            }
            return DTOs;

        }

        public bool ArtikelAanmaken(ArtikelDTO artikel)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command insertartikel wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand InsertArtikel = new SqlCommand(
                        "INSERT INTO [dbi429965_axigroep5].[dbo].[Artikel] (ArtikelNaam, ArtikelNummer, Prijs, Aantal, Beschrijving, THT, GroepID, Afmeting, Kleur, Gewicht) " +
                        "VALUES(@ArtikelNaam, @ArtikelNummer, @Prijs, @Aantal, @Beschrijving, @THT, @GroepID, @Afmeting, @Kleur, @Gewicht)", con))
                    {
                        // Waarde wordt toegevoegd aan de parameters binnen de query.
                        InsertArtikel.Parameters.Add(new SqlParameter("ArtikelNaam", artikel.Naam));
                        InsertArtikel.Parameters.Add(new SqlParameter("ArtikelNummer", artikel.ArtikelNummer));
                        InsertArtikel.Parameters.Add(new SqlParameter("Prijs", artikel.Prijs));
                        InsertArtikel.Parameters.Add(new SqlParameter("Aantal", artikel.Aantal));
                        InsertArtikel.Parameters.Add(new SqlParameter("Beschrijving", artikel.Beschrijving));
                        if(artikel.Tht !< DateTime.MinValue)
                        {
                            InsertArtikel.Parameters.Add(new SqlParameter("THT", artikel.Tht));
                        }
                        else
                        {
                            InsertArtikel.Parameters.Add(new SqlParameter("THT", DateTime.MaxValue));
                        }
                        InsertArtikel.Parameters.Add(new SqlParameter("GroepID", artikel.artikelGroep.GroepId));
                        InsertArtikel.Parameters.Add(new SqlParameter("Afmeting", artikel.Afmeting));
                        InsertArtikel.Parameters.Add(new SqlParameter("Kleur", artikel.Kleur));
                        InsertArtikel.Parameters.Add(new SqlParameter("Gewicht", artikel.Gewicht));

                        InsertArtikel.ExecuteNonQuery();
                        con.Close();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public bool ArtikelBewerken(ArtikelDTO artikel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand UpdateArtikel = new SqlCommand(
                        "UPDATE Artikel SET Artikelnaam = @Artikelnaam, Afmeting = @Afmeting, ArtikelNummer = @ArtikelNummer, Kleur = @Kleur, Gewicht = @gewicht, Aantal = @Aantal, GroepID = @groepid, Prijs = @Prijs, Beschrijving = @Beschrijving, THT = @tht WHERE Id = @ArtikelID", con))
                    {
                        UpdateArtikel.Parameters.Add(new SqlParameter("Artikelnaam", artikel.Naam));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Aantal", artikel.Aantal));
                        UpdateArtikel.Parameters.Add(new SqlParameter("groepid", artikel.artikelGroep.GroepId));
                        UpdateArtikel.Parameters.Add(new SqlParameter("ArtikelID", artikel.ArtikelID));
                        UpdateArtikel.Parameters.Add(new SqlParameter("ArtikelNummer", artikel.ArtikelNummer));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Prijs", artikel.Prijs));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Beschrijving", artikel.Beschrijving));
                        UpdateArtikel.Parameters.Add(new SqlParameter("tht", artikel.Tht));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Afmeting", artikel.Afmeting));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Kleur", artikel.Kleur));
                        UpdateArtikel.Parameters.Add(new SqlParameter("Gewicht", artikel.Gewicht));
                        UpdateArtikel.ExecuteNonQuery();
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

        public bool ArtikelVerwijderen(int id)
        {
            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                Con.Open();
                try
                {
                    using (SqlCommand CheckAfgerondeBestellingen = new SqlCommand(
                          "SELECT * FROM [ORDERS] WHERE ArtikelID = @ArtikelID AND Afgerond = @Afgerond", Con))
                    {
                        CheckAfgerondeBestellingen.Parameters.AddWithValue("ArtikelID", id);
                        CheckAfgerondeBestellingen.Parameters.AddWithValue("Afgerond", false);
                        SqlDataReader reader = CheckAfgerondeBestellingen.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            return false;
                        }
                        reader.Close();
                    }

                    using (SqlCommand DeleteOrders = new SqlCommand(
                        "DELETE FROM [Orders] WHERE ArtikelId = @ArtikelID", Con))
                    {
                        DeleteOrders.Parameters.Add(new SqlParameter("ArtikelID", id));
                        DeleteOrders.ExecuteNonQuery();
                    }

                    using (SqlCommand DeleteArtikel = new SqlCommand(
                        "DELETE FROM Artikel WHERE Id = @ArtikelID", Con))
                    {
                        DeleteArtikel.Parameters.Add(new SqlParameter("ArtikelID", id));
                        DeleteArtikel.ExecuteNonQuery();
                        Con.Close();
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

        public ArtikelDTO ArtikelOphalen(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand ArtikelOphalen = new SqlCommand("SELECT Artikel.ArtikelNaam, Artikel.ArtikelNummer,Artikel.Id, Artikel.Prijs, Artikel.Aantal, Artikel.Beschrijving, Artikel.THT, ArtikelGroep.GroepID, Artikel.Afmeting, Artikel.Kleur, Artikel.Gewicht, ArtikelGroep.Naam FROM Artikel INNER JOIN ArtikelGroep ON Artikel.GroepID = ArtikelGroep.GroepID WHERE Artikel.Id = @artikelid", con);

                ArtikelOphalen.Parameters.AddWithValue("@artikelid", id);
                SqlDataReader reader = ArtikelOphalen.ExecuteReader();

                ArtikelDTO dto = new ArtikelDTO();
                while (reader.Read())
                {
                    ArtikelGroepDTO retdto = new ArtikelGroepDTO();
                    retdto.Naam = (string)reader["Naam"];
                    retdto.GroepId = (int)reader["GroepID"];
                    dto.Naam = reader["ArtikelNaam"].ToString();
                    dto.ArtikelID = (int)reader["Id"];
                    dto.ArtikelNummer = (int)reader["ArtikelNummer"];
                    dto.Prijs = (double)reader["Prijs"];
                    dto.Aantal = (int)reader["Aantal"];
                    dto.Beschrijving = (string)reader["Beschrijving"];
                    dto.Tht = (DateTime)reader["THT"];
                    dto.artikelGroep = retdto;
                    dto.Afmeting = (string)reader["Afmeting"];
                    dto.Kleur = (string)reader["Kleur"];
                    dto.Gewicht = (int)reader["Gewicht"];
                }
                return dto;
            }
        }

        public List<ArtikelDTO> SelecteerArtikelListMetZoekterm(string zoekterm)
        {
            List<ArtikelDTO> DTOs = new List<ArtikelDTO>();
            List<ArtikelDTO> artikelDTOs = new List<ArtikelDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand select = new SqlCommand(
                        "SELECT Artikel.ArtikelNaam, Artikel.ArtikelNummer,Artikel.Id, Artikel.Prijs, Artikel.Aantal, Artikel.Beschrijving, Artikel.THT, ArtikelGroep.GroepID, Artikel.Afmeting, Artikel.Kleur, Artikel.Gewicht FROM Artikel WHERE Artikelnaam LIKE @zoekterm% INNER JOIN ArtikelGroep ON Artikel.GroepID = ArtikelGroep.GroepID", con))

                    {
                        select.Parameters.Add(new SqlParameter("zoekterm", zoekterm));
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ArtikelGroepDTO retdto = new ArtikelGroepDTO();
                                ArtikelDTO dto = new ArtikelDTO();
                                retdto.GroepId = (int)reader["GroepID"];
                                retdto.Naam = (string)reader["Naam"];
                                dto.Naam = reader["ArtikelNaam"].ToString();
                                dto.ArtikelID = (int)reader["Id"];
                                dto.ArtikelNummer = Convert.ToInt32(reader["ArtikelNummer"]);
                                dto.Prijs = Convert.ToDouble(reader["Prijs"]);
                                dto.Aantal = Convert.ToInt32(reader["Aantal"]);
                                dto.Beschrijving = reader["Beschrijving"].ToString();
                                dto.Tht = (DateTime)reader["THT"];
                                dto.artikelGroep = retdto;
                                dto.Afmeting = reader["Afmeting"].ToString();
                                dto.Kleur = reader["Kleur"].ToString();
                                dto.Gewicht = Convert.ToInt32(reader["Gewicht"]);
                                DTOs.Add(dto);

                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                con.Close();
            }
            return DTOs;

        }
    }
}