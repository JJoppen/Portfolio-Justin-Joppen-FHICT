using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class UserContainer
    {
        private IUser Iuser { get; set; }

        public UserContainer(IUser iuser)
        {
            Iuser = iuser;
        }
        public UserDTO UserNaarDTO(User user)
        {
            UserDTO userDTO = new UserDTO
            {
                userID = user.userID,
                email = user.email,
                gebruikersnaam = user.gebruikersnaam,
                wachtwoord = user.wachtwoord
            };
            return userDTO;
        }
        public bool CompareNewEmail(User user)
        {
            return Iuser.CompareNewEmail(UserNaarDTO(user));
        }
        public bool CompareNewUsername(User user)
        {
            return Iuser.CompareNewUsername(UserNaarDTO(user));
        }
        public User UserDetails(int id)
        {
            User user = new User(Iuser.AccountDetails(id));
            return user;
        }
        public bool loginUser(User user)
        {
            return Iuser.LoginUser(UserNaarDTO(user));
        }
        public int SelectUserID(User user)
        {

            return Iuser.SelectUserID(UserNaarDTO(user));
        }
        public bool CompareNewEmailUpdate(User user)
        {
            return Iuser.CompareNewEmailUpdate(UserNaarDTO(user));
        }
        public bool CompareNewUsernameUpdate(User user)
        {
            return Iuser.CompareNewUsernameUpdate(UserNaarDTO(user));
        }
        public List<User> SelectAllUsers()
        {
            List<User> users = new List<User>();
            var userdtos = Iuser.SelectAllUsers();
            foreach(UserDTO userDTO in userdtos)
            {
                User user = new User(userDTO);
                users.Add(user);
            }
            return users;
        }
    }
}
