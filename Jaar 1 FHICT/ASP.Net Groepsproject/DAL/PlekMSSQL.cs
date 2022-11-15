using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlekMSSQL
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public bool PlekAanmaken(PlekDTO plekDTO)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command insertartikel wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand InsertPlek = new SqlCommand(
                        "INSERT INTO [dbi429965_axigroep5].[dbo].[Plek] (ArtikelId, NiveauId, IsBezet) " +
                        "VALUES(@ArtikelId, @NiveauId, @IsBezet)", con))
                    {
                        // Waarde wordt toegevoegd aan de parameters binnen de query.
                        InsertPlek.Parameters.Add(new SqlParameter("ArtikelId", plekDTO.ArtikelId));
                        InsertPlek.Parameters.Add(new SqlParameter("NiveauID", plekDTO.NiveauId));
                        InsertPlek.Parameters.Add(new SqlParameter("IsBezet", plekDTO.IsBezet));
                        InsertPlek.ExecuteNonQuery();
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

        public PlekDTO ZoekArtikelLocatie(int artikelId)
        {
            PlekDTO plekDTO = new PlekDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand("SELECT * FROM Plek WHERE ArtikelId = @ArtikelId", con))
                {
                    select.Parameters.Add(new SqlParameter("ArtikelId", artikelId));

                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plekDTO.NiveauId = Convert.ToInt32(reader["ArtikelId"]);
                            plekDTO.Id = Convert.ToInt32(reader["Id"]);
                            plekDTO.IsBezet = reader["IsBezet"].GetType() == typeof(bool);
                        }
                    }
                }
            }
            return plekDTO;
        }

        public List<PlekDTO> SelecteerList()
        {
            List<PlekDTO> plekken = new List<PlekDTO>();
            PlekDTO plekDTO = new PlekDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand("SELECT * FROM Plek", con))
                {

                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plekDTO.NiveauId = Convert.ToInt32(reader["ArtikelId"]);
                            plekDTO.Id = Convert.ToInt32(reader["Id"]);
                            plekDTO.IsBezet = reader["IsBezet"].GetType() == typeof(bool);
                            plekken.Add(plekDTO);
                        }
                    }
                }
            }
            return plekken;
        }
    }
}
