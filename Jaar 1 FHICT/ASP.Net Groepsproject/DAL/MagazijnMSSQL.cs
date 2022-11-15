using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.IDal;

namespace DAL
{
    public class MagazijnMSSQL : IMagazijnDAL
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public bool Aanmaken(MagazijnDTO magazijnDTO)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command Aanmaken wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand Aanmaken = new SqlCommand(
                        "INSERT INTO [dbi429965_axigroep5].[dbo].[Magazijn] (Naam, StraatNaam, HuisNummer, PostCode) VALUES(@Naam, @StraatNaam, @HuisNummer, @PostCode)", con))
                    {
                        Aanmaken.Parameters.Add(new SqlParameter("Naam", magazijnDTO.Naam));
                        Aanmaken.Parameters.Add(new SqlParameter("StraatNaam", magazijnDTO.Straatnaam));
                        Aanmaken.Parameters.Add(new SqlParameter("HuisNummer", magazijnDTO.Huisnummer));
                        Aanmaken.Parameters.Add(new SqlParameter("PostCode", magazijnDTO.Postcode));
                        Aanmaken.ExecuteNonQuery();
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

        public MagazijnDTO Ophalen(int id)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                MagazijnDTO magazijnDTO = new MagazijnDTO();
                
                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbi434575_dbitucity].[dbo].[User] WHERE Id = @Id", con))
                {
                    command.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        magazijnDTO.Id = Convert.ToInt32(reader["ID"]);
                        magazijnDTO.Naam = reader["Naam"].ToString();
                        magazijnDTO.Straatnaam = reader["Straatnaam"].ToString();
                        magazijnDTO.Huisnummer = Convert.ToInt32(reader["Huisnummer"]);
                        magazijnDTO.Postcode = reader["Postcode"].ToString();
                        return magazijnDTO;
                    }
                }
                return magazijnDTO;
            }
        }

        public bool Verwijderen(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command Verwijder wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand Verwijder = new SqlCommand(
                        "DELETE FROM [dbi429965_axigroep5].[dbo].[Magazijn] WHERE Id = @Id", con))
                    {
                        // Waarde wordt verwijderd
                        Verwijder.Parameters.AddWithValue("@Id", id);
                        Verwijder.ExecuteNonQuery();
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

        public List<MagazijnDTO> SelecteerList()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<MagazijnDTO> magazijnDTOs = new List<MagazijnDTO>();
                MagazijnDTO magazijnDTO = new MagazijnDTO();

                con.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbi429965_axigroep5].[dbo].[Magazijn]", con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        magazijnDTO.Id = Convert.ToInt32(reader["ID"]);
                        magazijnDTO.Naam = reader["Naam"].ToString();
                        magazijnDTO.Straatnaam = reader["Straatnaam"].ToString();
                        magazijnDTO.Huisnummer = Convert.ToInt32("Huisnummer");
                        magazijnDTO.Postcode = reader["Postcode"].ToString();
                        magazijnDTOs.Add(magazijnDTO);
                    }
                    return magazijnDTOs;
                }
            }
        }

        public bool Bewerken(MagazijnDTO magazijnDTO)
        {
            throw new NotImplementedException();
        }
    }
}
