using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using InterfaceLaag.IDal;
using InterfaceLaag;
using System.Data.SqlClient;
using InterfaceLaag.DTO;

namespace DAL
{
    public class LocatieMSSQL : ILocatieDal
    {

        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public bool LocatieAanmaken(LocatieDTO locatieDTO)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command Insertlocatie wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand Insertlocatie = new SqlCommand(
                        "INSERT INTO Locatie (MagazijnId, RijNummer, NiveauId, PlekId, ArtikelId, IsBezet, AantalInLocatie) " +
                        "VALUES(@MagazijnId, @RijNummer, @NiveauId, @PlekId, @ArtikelId, @IsBezet, @AantalInLocatie)", con))
                    {
                        // Waarde wordt toegevoegd aan de parameters binnen de query.
                        Insertlocatie.Parameters.Add(new SqlParameter("MagazijnId", locatieDTO.MagazijnId));
                        Insertlocatie.Parameters.Add(new SqlParameter("RijNummer", locatieDTO.RijNummer));
                        Insertlocatie.Parameters.Add(new SqlParameter("NiveauId", locatieDTO.NiveauId));
                        Insertlocatie.Parameters.Add(new SqlParameter("PlekId", locatieDTO.PlekId));
                        Insertlocatie.Parameters.Add(new SqlParameter("ArtikelId", locatieDTO.ArtikelId));
                        Insertlocatie.Parameters.Add(new SqlParameter("IsBezet", locatieDTO.IsBezet));
                        Insertlocatie.Parameters.Add(new SqlParameter("AantalInLocatie", locatieDTO.AantalInLocatie));
                        Insertlocatie.ExecuteNonQuery();
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

        public LocatieDTO SelecteerLocatieOpId(int id)
        {
            LocatieDTO dto = new LocatieDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand select = new SqlCommand(
                        "SELECT * FROM Locatie WHERE LocatieId = @LocatieId", con))
                    {
                        select.Parameters.Add(new SqlParameter("LocatieId", id));
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dto.ArtikelId = Convert.ToInt32(reader["ArtikelId"]);
                                dto.LocatieId = Convert.ToInt32(reader["LocatieId"]);
                                dto.PlekId = Convert.ToInt32(reader["PlekId"]);
                                dto.NiveauId = Convert.ToInt32(reader["NiveauId"]);
                                dto.RijNummer = Convert.ToInt32(reader["RijNummer"]);
                                dto.MagazijnId = Convert.ToInt32(reader["MagazijnId"]);
                                dto.IsBezet = Convert.ToBoolean(reader["IsBezet"]);
                                dto.AantalInLocatie = Convert.ToInt32(reader["AantalInLocatie"]);
                                return dto;
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
            return dto;
        }

        public List<LocatieDTO> SelecteerLocaties()
        {
            List<LocatieDTO> locaties = new List<LocatieDTO>();
            LocatieDTO dto = new LocatieDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand select = new SqlCommand(
                        "SELECT * FROM Locatie", con))
                    {
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dto.ArtikelId = Convert.ToInt32(reader["ArtikelId"]);
                                dto.LocatieId = Convert.ToInt32(reader["LocatieId"]);
                                dto.PlekId = Convert.ToInt32(reader["PlekId"]);
                                dto.NiveauId = Convert.ToInt32(reader["NiveauId"]);
                                dto.RijNummer = Convert.ToInt32(reader["RijNummer"]);
                                dto.MagazijnId = Convert.ToInt32(reader["MagazijnId"]);
                                dto.IsBezet = Convert.ToBoolean(reader["IsBezet"]);
                                dto.AantalInLocatie = Convert.ToInt32(reader["AantalInLocatie"]);
                                locaties.Add(dto);
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
            return locaties;
        }

        public List<LocatieDTO> SelecteerLocatiesOpArtikel(int artikelId)
        {
            List<LocatieDTO> locaties = new List<LocatieDTO>();
            LocatieDTO dto = new LocatieDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand select = new SqlCommand(
                        "SELECT * FROM Locatie WHERE ArtikelId = @ArtikelId", con))
                    {
                        select.Parameters.Add(new SqlParameter("ArtikelId", artikelId));
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dto.ArtikelId = Convert.ToInt32(reader["ArtikelId"]);
                                dto.LocatieId = Convert.ToInt32(reader["LocatieId"]);
                                dto.PlekId = Convert.ToInt32(reader["PlekId"]);
                                dto.NiveauId = Convert.ToInt32(reader["NiveauId"]);
                                dto.RijNummer = Convert.ToInt32(reader["RijNummer"]);
                                dto.MagazijnId = Convert.ToInt32(reader["MagazijnId"]);
                                dto.IsBezet = Convert.ToBoolean(reader["IsBezet"]);
                                dto.AantalInLocatie = Convert.ToInt32(reader["AantalInLocatie"]);
                                locaties.Add(dto);
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
            return locaties;
        }

        public List<LocatieDTO> SelectLaagsteAantalInLocatie(List<int> artikelID)
        {
            List<LocatieDTO> locaties = new List<LocatieDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {

                        con.Open();
                    foreach (int id in artikelID)
                    {
                        using (SqlCommand select = new SqlCommand(
                            "SELECT TOP 1 * FROM Locatie WHERE ArtikelId = @ArtikelID AND AantalInLocatie = (SELECT MIN(AantalInLocatie) FROM Locatie WHERE ArtikelID = @ArtikelID) AND IsBezet = 1", con))
                        {
                            select.Parameters.Add(new SqlParameter("ArtikelID", id));
                            using (SqlDataReader reader = select.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    LocatieDTO locatieDTO = new LocatieDTO();
                                    locatieDTO.ArtikelId = (int)reader["ArtikelId"];
                                    locatieDTO.IsBezet = (bool)reader["IsBezet"];
                                    locatieDTO.LocatieId = (int)reader["LocatieId"];
                                    locatieDTO.MagazijnId = (int)reader["MagazijnId"];
                                    locatieDTO.RijNummer = (int)reader["RijNummer"];
                                    locatieDTO.NiveauId = (int)reader["NiveauId"];
                                    locatieDTO.PlekId = (int)reader["PlekId"];
                                    locaties.Add(locatieDTO);
                                }

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
            List<LocatieDTO> Gesorteerd = locaties.OrderBy(x => x.RijNummer)
                                                  .ThenBy(x => x.PlekId)
                                                  .ToList();
            return Gesorteerd;
        }

        public bool ArtikelIndelenOpLocatie(LocatieDTO locatieDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command insertartikel wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand UpdateAantal = new SqlCommand("UPDATE Locatie SET AantalInLocatie = @AantalInLocatie, IsBezet = @IsBezet, ArtikelId = @ArtikelId WHERE LocatieId = @LocatieId", con))
                    {
                        UpdateAantal.Parameters.AddWithValue("@LocatieId", locatieDTO.LocatieId);
                        UpdateAantal.Parameters.AddWithValue("@AantalInLocatie", locatieDTO.AantalInLocatie);
                        UpdateAantal.Parameters.AddWithValue("@IsBezet", locatieDTO.IsBezet);
                        UpdateAantal.Parameters.AddWithValue("@ArtikelId", locatieDTO.ArtikelId);
                        UpdateAantal.ExecuteNonQuery();
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

        public LocatieDTO LegeLocatieOphalen()
        {
            LocatieDTO dto = new LocatieDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand select = new SqlCommand(
                        "SELECT * FROM Locatie WHERE isBezet = 0", con))
                    {
                        using (SqlDataReader reader = select.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dto.ArtikelId = Convert.ToInt32(reader["ArtikelId"]);
                                dto.LocatieId = Convert.ToInt32(reader["LocatieId"]);
                                dto.PlekId = Convert.ToInt32(reader["PlekId"]);
                                dto.NiveauId = Convert.ToInt32(reader["NiveauId"]);
                                dto.RijNummer = Convert.ToInt32(reader["RijNummer"]);
                                dto.MagazijnId = Convert.ToInt32(reader["MagazijnId"]);
                                dto.IsBezet = Convert.ToBoolean(reader["IsBezet"]);
                                dto.AantalInLocatie = Convert.ToInt32(reader["AantalInLocatie"]);
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
            return dto;
        }
    }
}
