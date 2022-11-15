using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public struct UserDTO
    {
        public string gebruikersnaam { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public int userID { get; set; }
        public RatingDTO rating { get; set; }
    }
}
