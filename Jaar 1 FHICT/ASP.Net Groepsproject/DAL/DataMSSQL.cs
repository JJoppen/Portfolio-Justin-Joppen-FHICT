using InterfaceLaag.DTO;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataMSSQL : IData
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;
        public List<DataDTO> DataDezeMaand()
        {
            List<DataDTO> datas = new List<DataDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                DateTime dt = DateTime.Now;

                SqlCommand DataOphalen = new SqlCommand("SELECT SUM(o.Aantal) AS Aantal, ag.Naam AS GroepNaam FROM Orders o LEFT JOIN Artikel a ON o.ArtikelID = a.Id LEFT JOIN ArtikelGroep ag ON a.GroepID = ag.GroepId WHERE MONTH(DateTime) = @maand GROUP BY ag.Naam", con);

                DataOphalen.Parameters.AddWithValue("@maand", dt.Month);
                SqlDataReader rdr = DataOphalen.ExecuteReader();
                while (rdr.Read())
                {
                    DataDTO data = new DataDTO();
                    data.Aantal = (int)rdr["Aantal"];
                    data.Naam = (string)rdr["GroepNaam"];

                    datas.Add(data);
                }
            }
            return datas;
        }

        public List<DataDTO> AantalPerProductDezeMaand()
        {
            List<DataDTO> datas = new List<DataDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                DateTime dt = DateTime.Now;

                SqlCommand DataOphalen = new SqlCommand("SELECT SUM(o.Aantal) AS Aantal, a.ArtikelNaam AS ArtikelNaam FROM Orders o LEFT JOIN Artikel a ON o.ArtikelID = a.Id WHERE MONTH(DateTime) = @maand GROUP BY a.ArtikelNaam", con);

                DataOphalen.Parameters.AddWithValue("@maand", dt.Month);
                SqlDataReader rdr = DataOphalen.ExecuteReader();
                while (rdr.Read())
                {
                    DataDTO data = new DataDTO();
                    data.Aantal = (int)rdr["Aantal"];
                    data.Naam = (string)rdr["ArtikelNaam"];

                    datas.Add(data);
                }
            }
            return datas;
        }
    }
}
