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
    public class NiveauMSSQL
    {

        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public bool NiveauToevoegen(NiveauDTO niveauDTO)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command insertartikel wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand InsertNiveau = new SqlCommand(
                        "INSERT INTO Niveau (RijId) " +
                        "VALUES(@RijId)", con))
                    {
                        // Waarde wordt toegevoegd aan de parameters binnen de query.
                        InsertNiveau.Parameters.Add(new SqlParameter("ArtikelId", niveauDTO.RijId));
                        InsertNiveau.ExecuteNonQuery();
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

        public NiveauDTO NiveauOphalen(int niveauId)
        {
            NiveauDTO niveauDTO = new NiveauDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand("SELECT * FROM Niveau WHERE NiveauId = @NiveauId", con))
                {
                    select.Parameters.Add(new SqlParameter("NiveauId", niveauId));

                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            niveauDTO.RijId = Convert.ToInt32(reader["RijId"]);
                            niveauDTO.NiveauId = Convert.ToInt32(reader["NiveauId"]);
                        }
                    }
                }
            }
            return niveauDTO;
        }
    }
}
