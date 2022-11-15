using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Login
{
    public class Gebruiker
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int ID { get; private set; }
        public int PriorityLevel { get; private set; }

        public Gebruiker(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
