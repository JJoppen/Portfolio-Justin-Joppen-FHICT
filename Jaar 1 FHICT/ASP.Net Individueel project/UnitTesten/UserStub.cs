using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace UnitTesten
{
    public class UserStub : IUser
    {
        public bool RetBool = true;
        public UserDTO RetDTO;
        public int RetID;

        public UserDTO AccountDetails(int userID)
        {
            RetID = userID;
            return RetDTO;
        }

        public bool CompareNewEmail(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public bool CompareNewEmailUpdate(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public bool CompareNewUsername(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public bool CompareNewUsernameUpdate(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public bool InsertUser(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public bool LoginUser(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }

        public List<UserDTO> SelectAllUsers()
        {
            throw new NotImplementedException();
        }

        public int SelectUserID(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetID;
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            RetDTO = userDTO;
            return RetBool;
        }
    }
}
