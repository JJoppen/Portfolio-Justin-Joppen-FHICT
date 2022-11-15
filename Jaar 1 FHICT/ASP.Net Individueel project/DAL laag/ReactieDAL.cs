using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace DAL_laag
{
    public class ReactieDAL : IReactie
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;

        public bool DeleteComment(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Update = new SqlCommand(
                        "DELETE FROM Reacties WHERE ReactieID = @ReactieID", con))
                    {
                        Update.Parameters.Add(new SqlParameter("ReactieID",id));

                        Update.ExecuteNonQuery();
                        con.Close();
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool InsertReactie(ReactieDTO dto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO Reacties(UserID,NummerID,Reactie,Plaatstijd) VALUES(@userID, @nummerID,@comment,@plaatstijd)", con))
                    {
                        command.Parameters.Add(new SqlParameter("userID", dto.userDTO.userID));
                        command.Parameters.Add(new SqlParameter("nummerID", dto.NummerID));
                        command.Parameters.Add(new SqlParameter("comment", dto.Comment));
                        command.Parameters.Add(new SqlParameter("plaatstijd", dto.PlaatsTijd));
                        command.ExecuteNonQuery();
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

        public List<ReactieDTO> SelectCommentsVanNummer(int nummerID)
        {
            List<ReactieDTO> DTOs = new List<ReactieDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Command = new SqlCommand(
                        "SELECT Reacties.NummerID, Reacties.Reactie,Reacties.ReactieID, Reacties.PlaatsTijd, Users.userID, Users.Gebruikersnaam FROM Reacties INNER JOIN Users ON Reacties.userID = Users.userID WHERE NummerID = @NummerID", con))
                    {
                        Command.Parameters.Add(new SqlParameter("NummerID", nummerID));
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                UserDTO userDTO = new UserDTO
                                {
                                    gebruikersnaam = (string)reader["Gebruikersnaam"],
                                    userID = (int)reader["userID"]
                                };
                                ReactieDTO dto = new ReactieDTO();
                                dto.userDTO = userDTO;
                                dto.NummerID = (int)reader["NummerID"];
                                dto.ReactieID = (int)reader["ReactieID"];
                                dto.Comment = (string)reader["Reactie"];
                                dto.PlaatsTijd = (DateTime)reader["PlaatsTijd"];
                                DTOs.Add(dto);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                con.Close();
            }

            return DTOs;

        }

        public bool UpdateReactie(ReactieDTO dto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Update = new SqlCommand(
                        "UPDATE Reacties SET UserID = @userID, NummerID = @nummerID, Reactie = @Comment, Plaatstijd = @Plaatstijd WHERE ReactieID = @ReactieID ", con))
                    {
                        Update.Parameters.Add(new SqlParameter("UserID", dto.userDTO.userID));
                        Update.Parameters.Add(new SqlParameter("NummerID", dto.NummerID));
                        Update.Parameters.Add(new SqlParameter("Comment", dto.Comment));
                        Update.Parameters.Add(new SqlParameter("Plaatstijd", dto.PlaatsTijd));
                        Update.Parameters.Add(new SqlParameter("ReactieID", dto.ReactieID));

                        Update.ExecuteNonQuery();
                        con.Close();
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
