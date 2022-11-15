using InterfaceLaag;
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
    public class Winkelmandjemssql : IWinkelmandje
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader rd;

        public void BestelWinkelmandje(List<ArtikelDTO> artikelDTOs, int GebruikerID)
        {
            DateTime datetime = DateTime.Now;

            List<int> orderids = new List<int>();
            int neworderid;
            Connect();
            cmd = new SqlCommand("SELECT orderid FROM [Orders]", cnn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                orderids.Add((int)rd["orderid"]);
            }
            neworderid = orderids.Count + 1;
            rd.Close();
            for(int i = 0; i < artikelDTOs.Count; i++)
            {
                cmd = new SqlCommand("INSERT INTO [Orders] (OrderID, GebruikerID, ArtikelID, Aantal, Afgerond, DateTime) VALUES(@OrderID, @GebruikerID, @ArtikelID, @ArtikelAantal, @Afgerond, @DateTime)", cnn);
                cmd.Parameters.AddWithValue("OrderID", neworderid);
                cmd.Parameters.AddWithValue("GebruikerID", GebruikerID );
                cmd.Parameters.AddWithValue("ArtikelID", artikelDTOs[i].ArtikelID);
                cmd.Parameters.AddWithValue("Afgerond", false);
                cmd.Parameters.AddWithValue("DateTime", datetime);
                cmd.Parameters.AddWithValue("ArtikelAantal", artikelDTOs[i].Aantal);
                cmd.ExecuteNonQuery();
            }
        }

        public bool Connect()
        {
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
