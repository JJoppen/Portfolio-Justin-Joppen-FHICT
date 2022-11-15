using InterfaceLaag.DTO;
using InterfaceLaag.IDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RijMSSQL : IRijDAL
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public RijDTO OphalenOpRijNummer(int rijNummer)
        {
            RijDTO rijDTO = new RijDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand("SELECT * FROM Rij WHERE RijNummer = @RijNummer", con))
                {
                    select.Parameters.Add(new SqlParameter("RijNummer", rijNummer));

                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rijDTO.RijId = Convert.ToInt32(reader["RijId"]);
                            rijDTO.RijNummer = Convert.ToInt32(reader["RijNummer"]);
                        }
                    }
                }
            }
            return rijDTO;
        }

        public bool RijAanmaken(int rijNummer)
        {
            //Variabele con wordt als SQL connectie aangeroepen met de static private string connectionstring.
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Connectie met database wordt open gemaakt.
                con.Open();
                try
                {
                    //SQL command insertartikel wordt aangemaakt met een query die gebruikt maakt van con.
                    using (SqlCommand InsertRij = new SqlCommand(
                        "INSERT INTO Rij", con))
                    {
                        // Waarde wordt toegevoegd aan de parameters binnen de query.
                        InsertRij.ExecuteNonQuery();
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

        public RijDTO RijOphalen(int rijId)
        {
            RijDTO rijDTO = new RijDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand("SELECT * FROM Rij WHERE RijId = @RijId", con))
                {
                    select.Parameters.Add(new SqlParameter("RijId", rijId));

                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rijDTO.RijId = Convert.ToInt32(reader["RijId"]);
                        }
                    }
                }
            }
            return rijDTO;
        }
    }
}
