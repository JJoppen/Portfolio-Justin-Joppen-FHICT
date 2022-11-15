using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;

namespace LogicaLaag.Login
{
    public class GebruikerContainer
    {
        readonly private InterfaceLaag.Interface.IGebruiker igebruiker;
        private GebruikerDTO gebruikerDTO = new GebruikerDTO();

        public GebruikerContainer(InterfaceLaag.Interface.IGebruiker igebruiker)
        {
            this.igebruiker = igebruiker;
        }

        public int LoginGebruiker(Gebruiker gebruiker)
        {
            gebruikerDTO.Email = gebruiker.Email;
            gebruikerDTO.Password = gebruiker.Password;
            return igebruiker.LoginGebruiker(gebruikerDTO);
        }

        public int GetGebruikerPriorityLevel(int id)
        {
            gebruikerDTO.ID = id;
            return igebruiker.GetGebruikerPriorityLevel(gebruikerDTO);
        }
    }
}
