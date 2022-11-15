using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IGebruiker
    {
        int LoginGebruiker(GebruikerDTO gebruikerDTO);

        int GetGebruikerPriorityLevel(GebruikerDTO gebruikerDTO);
    }
}
