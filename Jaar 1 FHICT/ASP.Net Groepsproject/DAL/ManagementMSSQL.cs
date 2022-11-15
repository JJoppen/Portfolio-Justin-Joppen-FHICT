using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;
using InterfaceLaag.IDal;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{

    public class ManagementMSSQL : IManagementDal
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader rd;

        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        List<ManagementDTO> IManagementDal.SelecteerAccountList()
        {
            List<ManagementDTO> dTOs = new List<ManagementDTO>();
            if (Connect() == false)
            {
                return dTOs;
            }
            else
            {
                cmd = new SqlCommand("SELECT id, Email, Password, PriorityLevel FROM [User]", cnn);
                try
                {
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ManagementDTO dto = new ManagementDTO();
                        dto.id = (int)rd["id"];
                        dto.Email = rd["Email"].ToString();
                        dto.Password = rd["Password"].ToString();
                        dto.PriorityLevel = (int)rd["PriorityLevel"];
                        dTOs.Add(dto);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                cnn.Close();
            }
            return dTOs;
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

        public bool AccountWijzigen(ManagementDTO managementDTO)
        {
            try
            {
                Connect();
                cmd = new SqlCommand("UPDATE [USER] SET Email = email, Password = @password, Prioritylevel = @prioritylevel where Id = @id", cnn);
                cmd.Parameters.AddWithValue("email", managementDTO.Email);
                cmd.Parameters.AddWithValue("password", managementDTO.Password);
                cmd.Parameters.AddWithValue("prioritylevel", managementDTO.PriorityLevel);
                cmd.Parameters.AddWithValue("id", managementDTO.id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void VerwijderAccount(ManagementDTO managementDTO)
        {
            try
            {
                Connect();
                cmd = new SqlCommand("DELETE [USER] Where Id = @id", cnn);
                cmd.Parameters.AddWithValue("id", managementDTO.id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
        }
    }
}
