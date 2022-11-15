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
    public class UserDAL : IUser
    {
        static private string connectionString = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;

        public UserDTO AccountDetails(int userID)
        {
            UserDTO userDTO = new UserDTO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT users.Email, users.Gebruikersnaam,users.userID,AVG(UserRatings.Rating) AS rating FROM Users INNER JOIN UserRatings ON UserRatings.TargetID = Users.UserID WHERE UserID = @userID GROUP BY Users.Gebruikersnaam, Users.UserID, Users.Email", con))
                    {
                        command.Parameters.Add(new SqlParameter("userID", userID));
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) 
                            {
                                while (reader.Read())
                                {
                                    userDTO.email = (string)reader["Email"];
                                    userDTO.gebruikersnaam = (string)reader["gebruikersnaam"];
                                    userDTO.userID = userID;
                                    userDTO.rating = new RatingDTO { rating = (int)reader["rating"] };
                                }
                            }
                            else
                            {
                                con.Close();
                                con.Open();
                                using (SqlCommand NoDataFound = new SqlCommand(
                                    "SELECT Email, Gebruikersnaam,userID FROM Users WHERE UserID = @userID", con))
                                {
                                    NoDataFound.Parameters.Add(new SqlParameter("userID", userID));
                                    using (SqlDataReader NoDataReader = NoDataFound.ExecuteReader())
                                    {
                                        while (NoDataReader.Read())
                                        {
                                            userDTO.email = (string)NoDataReader["Email"];
                                            userDTO.gebruikersnaam = (string)NoDataReader["gebruikersnaam"];
                                            userDTO.userID = userID;
                                            userDTO.rating = new RatingDTO { rating = 0 };
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                    return userDTO;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool CompareNewEmail(UserDTO userDTO)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM Users WHERE Email = @Email", con))
                    {
                        command.Parameters.Add(new SqlParameter("email", userDTO.email));
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

        public bool CompareNewEmailUpdate(UserDTO userDTO)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM Users WHERE Email = @Email AND NOT UserID = @userID", con))
                    {
                        command.Parameters.Add(new SqlParameter("email", userDTO.email));
                        command.Parameters.Add(new SqlParameter("userID", userDTO.userID));
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

        public bool CompareNewUsername(UserDTO userDTO)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM Users WHERE Gebruikersnaam = @gebruikersnaam", con))
                    {
                        command.Parameters.Add(new SqlParameter("gebruikersnaam", userDTO.gebruikersnaam));
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

        public bool CompareNewUsernameUpdate(UserDTO userDTO)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM Users WHERE Gebruikersnaam = @gebruikersnaam AND NOT UserID = @userID", con))
                    {
                        command.Parameters.Add(new SqlParameter("gebruikersnaam", userDTO.gebruikersnaam));
                        command.Parameters.Add(new SqlParameter("userID", userDTO.userID));
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

        public bool InsertUser(UserDTO userDTO)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO users(Gebruikersnaam,Wachtwoord,Email) VALUES(@gebruikersnaam, @wachtwoord,@email)",con))
                    {
                        command.Parameters.Add(new SqlParameter("gebruikersnaam", userDTO.gebruikersnaam));
                        command.Parameters.Add(new SqlParameter("wachtwoord", userDTO.wachtwoord));
                        command.Parameters.Add(new SqlParameter("email", userDTO.email));
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

        public bool LoginUser(UserDTO userDTO)
        {
            bool retbool;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM Users WHERE Gebruikersnaam = @gebruikersnaam AND Wachtwoord = @wachtwoord", con))
                    {
                        command.Parameters.Add(new SqlParameter("gebruikersnaam", userDTO.gebruikersnaam));
                        command.Parameters.Add(new SqlParameter("wachtwoord", userDTO.wachtwoord));
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

        public List<UserDTO> SelectAllUsers()
        {
            List<UserDTO> dto = new List<UserDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Select = new SqlCommand(
                        "SELECT Gebruikersnaam,userID FROM Users", con))
                    {
                        using (SqlDataReader reader = Select.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                UserDTO userDTO = new UserDTO();
                                userDTO.gebruikersnaam = (string)reader["Gebruikersnaam"];
                                userDTO.userID = (int)reader["userID"];
                                dto.Add(userDTO);
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

        public int SelectUserID(UserDTO userDTO)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int id = 0;
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "SELECT UserID FROM Users WHERE Gebruikersnaam = @gebruikersnaam AND Wachtwoord = @wachtwoord", con))
                    {
                        command.Parameters.Add(new SqlParameter("gebruikersnaam", userDTO.gebruikersnaam));
                        command.Parameters.Add(new SqlParameter("wachtwoord", userDTO.wachtwoord));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                id = (int)reader["UserID"];
                            }
                        }
                    }
                    return id;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public bool UpdateUser(UserDTO userDTo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand Update = new SqlCommand(
                        "UPDATE Users SET Gebruikersnaam = @gebruikersnaam,Email = @email, Wachtwoord = @wachtwoord WHERE UserID = @userID ", con))
                    {
                        Update.Parameters.Add(new SqlParameter("gebruikersnaam", userDTo.gebruikersnaam));
                        Update.Parameters.Add(new SqlParameter("email",userDTo.email));
                        Update.Parameters.Add(new SqlParameter("wachtwoord",userDTo.wachtwoord));
                        Update.Parameters.Add(new SqlParameter("userID", userDTo.userID));
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
