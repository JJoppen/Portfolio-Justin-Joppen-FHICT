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
    public class RatingDAL : IRating
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;

        public List<RatingDTO> AllNummerRatings(int userID)
        {
            List<RatingDTO> ratingDTOs = new List<RatingDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM NummerRatings WHERE TargetID = @targetID", con))
                    {
                        command.Parameters.Add(new SqlParameter("targetID", userID));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RatingDTO rating = new RatingDTO();
                                rating.rating = (int)reader["rating"];
                            }
                        }
                    }
                    return ratingDTOs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool HasUserRatedNummerYet(int userid, int nummerid)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM NummerRatings WHERE NummerID = @nummerID AND ExecuterID = @UserID", con))
                    {
                        command.Parameters.Add(new SqlParameter("NummerID", nummerid));
                        command.Parameters.Add(new SqlParameter("UserID", userid));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            retbool = reader.HasRows;
                        }
                    }
                    return retbool;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool HasUserRatedUserYet(int loggedInUser, int selectedUser)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM UserRatings WHERE TargetID = @targetUserID AND ExecuterID = @ExecutingUserID", con))
                    {
                        command.Parameters.Add(new SqlParameter("ExecutingUserID", loggedInUser));
                        command.Parameters.Add(new SqlParameter("targetUserID", selectedUser));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            retbool = reader.HasRows;
                        }
                    }
                    return retbool;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool InsertNummerRating(RatingDTO ratingDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO NummerRatings(Rating,ExecuterID,NummerID) VALUES(@rating, @executerID,@nummerID)", con))
                    {
                        command.Parameters.Add(new SqlParameter("rating", ratingDTO.rating));
                        command.Parameters.Add(new SqlParameter("executerID", ratingDTO.userID));
                        command.Parameters.Add(new SqlParameter("nummerID", ratingDTO.id));
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

        public bool InsertUserRating(RatingDTO ratingDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO UserRatings(Rating,ExecuterID,TargetID) VALUES(@rating, @executerID,@targetID)", con))
                    {
                        command.Parameters.Add(new SqlParameter("rating", ratingDTO.rating));
                        command.Parameters.Add(new SqlParameter("executerID", ratingDTO.userID));
                        command.Parameters.Add(new SqlParameter("targetID", ratingDTO.id));
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

        public List<RatingDTO> NummerRatings(int nummerID)
        {
            List<RatingDTO> ratingDTOs = new List<RatingDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM NummerRatings WHERE NummerID = @nummerID", con))
                    {
                        command.Parameters.Add(new SqlParameter("NummerID", nummerID));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RatingDTO rating = new RatingDTO();
                                rating.rating = (int)reader["rating"];
                            }
                        }
                    }
                    return ratingDTOs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool UpdateNummerRating(RatingDTO ratingDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "UPDATE NummerRatings SET Rating = @rating WHERE NummerID = @nummerID AND ExecuterID = @executerID", con))
                    {
                        command.Parameters.Add(new SqlParameter("rating", ratingDTO.rating));
                        command.Parameters.Add(new SqlParameter("nummerID", ratingDTO.id));
                        command.Parameters.Add(new SqlParameter("executerID", ratingDTO.userID));
                        command.ExecuteNonQuery();
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

        public bool UpdateUserRating(RatingDTO ratingDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "UPDATE UserRatings SET Rating = @rating WHERE TargetID = @targetID AND ExecuterID = @executerID", con))
                    {
                        command.Parameters.Add(new SqlParameter("rating", ratingDTO.rating));
                        command.Parameters.Add(new SqlParameter("targetID", ratingDTO.id));
                        command.Parameters.Add(new SqlParameter("executerID", ratingDTO.userID));
                        command.ExecuteNonQuery();
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

        public List<RatingDTO> UserRatings(int userID)
        {
            List<RatingDTO> ratingDTOs = new List<RatingDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM UserRatings WHERE UserID = @userID", con))
                    {
                        command.Parameters.Add(new SqlParameter("userID", userID));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RatingDTO rating = new RatingDTO();
                                rating.rating = (int)reader["rating"];
                            }
                        }
                    }
                    return ratingDTOs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }
    
    }
}
