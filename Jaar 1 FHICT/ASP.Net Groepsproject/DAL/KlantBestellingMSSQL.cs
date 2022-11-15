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
    public class KlantBestellingMSSQL : IKlantBestelling
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader rd;

        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        public List<KlantBestellingDTO> getbestelling()
        {
            List<KlantBestellingDTO> klantBestellingDTOs = new List<KlantBestellingDTO>();
            Connect();
            cmd = new SqlCommand("Select OrderID, DateTime, ArtikelID, GebruikerID, Afgerond FROM [Orders] ORDER BY DateTime ASC", cnn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                int i = 0;
                foreach (KlantBestellingDTO dtos in klantBestellingDTOs.ToList())
                {
                    if((bool)rd["Afgerond"] != true)
                    {
                        if (dtos.BestellingID == (int)rd["OrderID"])
                        {
                            dtos.Artikelaantal++;
                            break;
                        }
                        i++;
                        if (i == klantBestellingDTOs.Count)
                        {
                            KlantBestellingDTO dto = new KlantBestellingDTO();
                            dto.BestellingID = (int)rd["OrderID"];
                            dto.BesteldeArtikelID = (int)rd["ArtikelID"];
                            dto.datetime = (DateTime)rd["DateTime"];
                            klantBestellingDTOs.Add(dto);
                            dto.Artikelaantal++;
                        }
                    }
                }
                if (klantBestellingDTOs.Count == 0 && (bool)rd["Afgerond"] != true)
                {
                    KlantBestellingDTO dto = new KlantBestellingDTO();
                    dto.BestellingID = (int)rd["OrderID"];
                    dto.BesteldeArtikelID = (int)rd["ArtikelID"];
                    dto.datetime = (DateTime)rd["DateTime"];
                    dto.Artikelaantal++;
                    klantBestellingDTOs.Add(dto);
                }
            }
            return klantBestellingDTOs;
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

        public List<KlantBestellingDTO> GetBestellingDetails(KlantBestellingDTO klantBestellingDTO)
        {
            Connect();
            List<KlantBestellingDTO> klantBestellingDTOs = new List<KlantBestellingDTO>();
            List<KlantBestellingDTO> ArtikelIds = new List<KlantBestellingDTO>();
            //query alle artikelid's ophalen die de bestellingid heeft
            cmd = new SqlCommand("Select ArtikelID, Aantal From [Orders] Where OrderID = @bestellingid", cnn);
            cmd.Parameters.AddWithValue("bestellingid", klantBestellingDTO.BestellingID);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                KlantBestellingDTO dto = new KlantBestellingDTO();
                dto.BesteldeArtikelID = (int)rd["ArtikelID"];
                dto.Artikelaantal = (int)rd["Aantal"];
                ArtikelIds.Add(dto);
            }
            rd.Close();
            //query alle namen ophalen van de artikelid's
            foreach(KlantBestellingDTO klantbestellingdto in ArtikelIds)
            {
                cmd = new SqlCommand("Select ArtikelNaam From [Artikel] where id = @Artikelid", cnn);
                cmd.Parameters.AddWithValue("Artikelid", klantbestellingdto.BesteldeArtikelID);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    KlantBestellingDTO dto = new KlantBestellingDTO();
                    dto.ArtikelNaam = (string)rd["ArtikelNaam"];
                    dto.Artikelaantal = klantbestellingdto.Artikelaantal;
                    dto.BesteldeArtikelID = klantbestellingdto.BesteldeArtikelID;
                    klantBestellingDTOs.Add(dto);
                }
                rd.Close();
            }
            return klantBestellingDTOs;
        }

        public void BestellingAfronden(KlantBestellingDTO klantBestellingDTO)
        {
            Connect();
            cmd = new SqlCommand("UPDATE [Orders] SET Afgerond = @Afgerond WHERE Orderid = @Orderid", cnn);
            cmd.Parameters.AddWithValue("@OrderID", klantBestellingDTO.BestellingID);
            cmd.Parameters.AddWithValue("Afgerond", true);
            cmd.ExecuteNonQuery();
        }
    }
}
