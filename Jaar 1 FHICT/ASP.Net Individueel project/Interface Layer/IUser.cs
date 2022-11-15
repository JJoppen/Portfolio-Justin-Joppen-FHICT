using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public interface IUser
    {
        public bool InsertUser(UserDTO userDTO);
        public bool UpdateUser(UserDTO userDTO);
        public bool CompareNewEmail(UserDTO userDTO);
        public bool CompareNewUsername(UserDTO userDTO);
        public UserDTO AccountDetails(int userID);

        public bool LoginUser(UserDTO userDTO);
        public int SelectUserID(UserDTO userDTO);
        public bool CompareNewUsernameUpdate(UserDTO userDTO);
        public bool CompareNewEmailUpdate(UserDTO userDTO);
        public List<UserDTO> SelectAllUsers();
    }
}
