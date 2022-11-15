using InterfaceLaag.DTO;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.AccountTestOnderdelen
{
    public class AccountStub : IGebruiker
    {
        public bool RetVal { get; set; }
        public GebruikerDTO LastAccount = new GebruikerDTO();

        public int GetGebruikerPriorityLevel(GebruikerDTO gebruikerDTO)
        {
            LastAccount.ID = gebruikerDTO.ID;
            return 4;
        }

        public int LoginGebruiker(GebruikerDTO gebruikerDTO)
        {
            LastAccount.Email = gebruikerDTO.Email;
            LastAccount.Password = gebruikerDTO.Password;
            return 1;
        }
    }
}
