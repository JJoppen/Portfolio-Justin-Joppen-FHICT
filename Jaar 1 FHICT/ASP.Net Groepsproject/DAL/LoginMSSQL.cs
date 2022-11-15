using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using InterfaceLaag;
using InterfaceLaag.DTO;

namespace DAL
{
    public class LoginMSSQL : InterfaceLaag.Interface.IGebruiker
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["axiWarehouse"].ConnectionString;

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader rd;
        int ID;
        int PriorityLevel;

        int InterfaceLaag.Interface.IGebruiker.LoginGebruiker(GebruikerDTO gebruikerDTO)
        {

            if (Connect() == false)
            {
                return 0;
            }
            else
            {
                cmd = new SqlCommand("Select * FROM [User] WHERE Email = @Email AND Password = @password ", cnn);
                cmd.Parameters.AddWithValue("@Email", gebruikerDTO.Email);
                cmd.Parameters.AddWithValue("@password", gebruikerDTO.Password);
                try
                {
                    rd = cmd.ExecuteReader();
                }
                catch (Exception )
                {
                    cnn.Close();
                    return 0;
                }
                if (rd.HasRows == true)
                {
                    rd.Close();
                    cmd = new SqlCommand("Select * from [User] where Email = @Email AND Password = @Password", cnn);
                    cmd.Parameters.AddWithValue("@Email", gebruikerDTO.Email);
                    cmd.Parameters.AddWithValue("@Password", gebruikerDTO.Password);
                    ID = (int)cmd.ExecuteScalar();
                    cnn.Close();
                    return ID;
                }
                else
                {
                    cnn.Close();
                    return 0;
                }
            }
        }

        


        public bool Connect()
        {
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }

        public int GetGebruikerPriorityLevel(GebruikerDTO gebruikerDTO)
        {
            Connect();
            cmd = new SqlCommand("Select PriorityLevel from [User] where Id = @ID", cnn);
            cmd.Parameters.AddWithValue("ID", ID);
            PriorityLevel = (int)cmd.ExecuteScalar();
            return PriorityLevel;
        }
    }
}

