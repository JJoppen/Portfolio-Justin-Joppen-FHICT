using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Inter.Layer;
using System.Configuration;

namespace DAL.Layer
{
    public class MuziekNummerDAL :IMuziekNummer 
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;

        public bool InsertNummer(MuziekNummerDTO muzieknummer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Insert = new SqlCommand(
                        "INSERT INTO Nummers(Naam, Tab, UserID, Type, Beschrijving,Youtubelink) VALUES(@naam, @tab, @userID, @type, @beschrijving, @YoutubeLink)", con))
                    {
                        Insert.Parameters.Add(new SqlParameter("naam", muzieknummer.Naam));
                        Insert.Parameters.Add(new SqlParameter("tab", muzieknummer.Tab));
                        Insert.Parameters.Add(new SqlParameter("userID", muzieknummer.UserID));
                        Insert.Parameters.Add(new SqlParameter("type", muzieknummer.Type));
                        Insert.Parameters.Add(new SqlParameter("beschrijving", muzieknummer.Beschrijving));
                        Insert.Parameters.Add(new SqlParameter("YoutubeLink", muzieknummer.YoutubeLink));
                        Insert.ExecuteNonQuery();
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
        public bool UpdateNummer(MuziekNummerDTO muziekNummerDTO)
        {
            if(string.IsNullOrEmpty(muziekNummerDTO.YoutubeLink))
            {
                muziekNummerDTO.YoutubeLink = "NoLink";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Update = new SqlCommand(
                        "UPDATE Nummers SET Naam = @Naam, Beschrijving = @Beschrijving, Tab = @Tab, Type = @Type, Youtubelink = @YoutubeLink WHERE NummerID = @NummerID ",con))
                    {
                        Update.Parameters.Add(new SqlParameter("Naam", muziekNummerDTO.Naam));
                        Update.Parameters.Add(new SqlParameter("Beschrijving", muziekNummerDTO.Beschrijving));
                        Update.Parameters.Add(new SqlParameter("Tab", muziekNummerDTO.Tab));
                        Update.Parameters.Add(new SqlParameter("Type", muziekNummerDTO.Type));
                        Update.Parameters.Add(new SqlParameter("NummerID", muziekNummerDTO.NummerID));
                        Update.Parameters.Add(new SqlParameter("YoutubeLink", muziekNummerDTO.YoutubeLink));

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
        public MuziekNummerDTO SelectNummer(int NummerID)
        {
            MuziekNummerDTO Values = new MuziekNummerDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Select = new SqlCommand(
                        "SELECT Nummers.Naam, Nummers.Beschrijving, Nummers.Type, CAST(nummers.Tab AS varchar(max)) AS tab, Nummers.Youtubelink, Nummers.UserID, AVG(NummerRatings.Rating) AS rating FROM Nummers INNER JOIN NummerRatings  ON NummerRatings.NummerID = Nummers.nummerID WHERE nummers.NummerID = @nummerID GROUP BY Nummers.Naam, Nummers.Beschrijving, Nummers.Type, Nummers.UserID, Nummers.Youtubelink, CAST(nummers.Tab AS varchar(max))", con))
                    {
                        Select.Parameters.Add(new SqlParameter("nummerID", NummerID));
                        using (SqlDataReader reader = Select.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    Values.Naam = reader["Naam"].ToString();
                                    Values.Beschrijving = reader["Beschrijving"].ToString();
                                    Values.Type = reader["Type"].ToString();
                                    Values.Tab = reader["Tab"].ToString();
                                    Values.UserID = Convert.ToInt32(reader["UserID"]);
                                    Values.YoutubeLink = Convert.ToString(reader["Youtubelink"]);
                                    RatingDTO ratingdto = new RatingDTO
                                    {
                                        rating = (int)reader["rating"]
                                    };
                                    Values.rating = ratingdto;
                                    Values.NummerID = NummerID;
                                }
                            }
                            else
                            {
                                con.Close();
                                con.Open();
                                using (SqlCommand NoDataFound = new SqlCommand(
                                    "SELECT Naam, Beschrijving,Type,Youtubelink,UserID,Tab FROM Nummers WHERE NummerID = @nummerID", con))
                                {
                                    NoDataFound.Parameters.Add(new SqlParameter("nummerID",NummerID ));
                                    using (SqlDataReader NoDataReader = NoDataFound.ExecuteReader())
                                    {
                                        while (NoDataReader.Read())
                                        {
                                            Values.Naam = NoDataReader["Naam"].ToString();
                                            Values.Beschrijving = NoDataReader["Beschrijving"].ToString();
                                            Values.Type = NoDataReader["Type"].ToString();
                                            Values.Tab = NoDataReader["Tab"].ToString();
                                            Values.UserID = Convert.ToInt32(NoDataReader["UserID"]);
                                            Values.YoutubeLink = Convert.ToString(NoDataReader["Youtubelink"]);
                                            RatingDTO ratingdto = new RatingDTO
                                            {
                                                rating = 0
                                            };
                                            Values.rating = ratingdto;
                                            Values.NummerID = NummerID;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return Values;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<MuziekNummerDTO> SelectNummerList()
        {
            List<MuziekNummerDTO> dto = new List<MuziekNummerDTO>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using(SqlCommand Select = new SqlCommand(
                        "SELECT Naam, Beschrijving,NummerID,Type,Tab,UserID FROM Nummers",con))
                    {
                        using(SqlDataReader reader = Select.ExecuteReader())
                        {

                            while(reader.Read())
                            {
                                MuziekNummerDTO muziekNummerDTO = new MuziekNummerDTO();    
                                muziekNummerDTO.Naam = reader["Naam"].ToString();
                                muziekNummerDTO.Beschrijving = reader["Beschrijving"].ToString();
                                muziekNummerDTO.Type = reader["Type"].ToString();
                                muziekNummerDTO.Tab = reader["Tab"].ToString();
                                muziekNummerDTO.NummerID = (int)reader["NummerID"];
                                muziekNummerDTO.UserID = (int)reader["userID"];
                                dto.Add(muziekNummerDTO);
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

            return dto;
             
        }

        public List<MuziekNummerDTO> SelectNummersWithQuery(string Query)
        {
            List<MuziekNummerDTO> dto = new List<MuziekNummerDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Select = new SqlCommand(
                        "SELECT Naam, Beschrijving,NummerID, Type, Tab FROM Nummers WHERE Naam LIKE @searchterm", con))
                    {
                        Select.Parameters.Add(new SqlParameter("searchterm", $"{Query}%"));
                        using (SqlDataReader reader = Select.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                MuziekNummerDTO muziekNummerDTO = new MuziekNummerDTO();
                                muziekNummerDTO.Naam = reader["Naam"].ToString();
                                muziekNummerDTO.Beschrijving = reader["Beschrijving"].ToString();
                                muziekNummerDTO.Type = reader["Type"].ToString();
                                muziekNummerDTO.Tab = reader["Tab"].ToString();
                                muziekNummerDTO.NummerID = (int)reader["NummerID"];
                                dto.Add(muziekNummerDTO);
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

            return dto;
        }

        public List<MuziekNummerDTO> SelectNummersWithUserID(int id)
        {
            List<MuziekNummerDTO> dto = new List<MuziekNummerDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Select = new SqlCommand(
                        "SELECT Naam, Beschrijving, Type, NummerID FROM Nummers WHERE UserID = @userID ", con))
                    {
                        Select.Parameters.Add(new SqlParameter("userID", id));
                        using (SqlDataReader reader = Select.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                MuziekNummerDTO muziekNummerDTO = new MuziekNummerDTO();
                                muziekNummerDTO.Naam = reader["Naam"].ToString();
                                muziekNummerDTO.Beschrijving = reader["Beschrijving"].ToString();
                                muziekNummerDTO.Type = reader["Type"].ToString();
                                muziekNummerDTO.NummerID = (int)reader["NummerID"];
                                dto.Add(muziekNummerDTO);
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

            return dto;
        }
    }
}
