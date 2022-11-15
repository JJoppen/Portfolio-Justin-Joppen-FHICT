using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class User
    {
        public string gebruikersnaam { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public int userID { get; set; }
        public Rating rating { get; set; }
        
        public User(int userID)
        {
            this.userID = userID;
        }
        public User(string gebruikersnaam, string email, string wachtwoord)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.email = email;
            this.wachtwoord = wachtwoord;
        }

        public User(string email, string wachtwoord)
        {
            this.email = email;
            this.wachtwoord = wachtwoord;
        }

        public User(string gebruikersnaam, string email, string wachtwoord, int userID) : this(gebruikersnaam, email, wachtwoord)
        {
            this.userID = userID;
        }

        public User(string gebruikersnaam, int userID, Rating rating)
        {
            this.gebruikersnaam = gebruikersnaam;
            this.userID = userID;
            this.rating = rating;
        }

        public User(UserDTO userdto)
        {
            email = userdto.email;
            gebruikersnaam = userdto.gebruikersnaam;
            wachtwoord = userdto.wachtwoord;
            userID = userdto.userID;
            this.rating = new Rating(userdto.rating);
        }
        public UserDTO UserToUserDTO()
        {
            UserDTO dto = new UserDTO
            {
                email = this.email,
                gebruikersnaam = this.gebruikersnaam,
                wachtwoord = this.wachtwoord,
                userID = this.userID
            };
            return dto;
        }
        public bool InsertUser( IUser Iuser)
        {

            return Iuser.InsertUser(UserToUserDTO());
        }
        public bool UpdateUser( IUser Iuser)
        {
            return Iuser.UpdateUser(UserToUserDTO());
        }
    }
}
