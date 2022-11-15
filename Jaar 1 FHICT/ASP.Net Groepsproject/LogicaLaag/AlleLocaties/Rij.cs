using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.AlleLocaties
{
    public class Rij
    {
        public int RijId { get; set; }
        public int RijNummer { get; set; }


        public Rij(int rijId, int rijNummer)
        {
            RijId = rijId;
            RijNummer = rijNummer;
        }

        public Rij(RijDTO rijDTO)
        {
            RijId = rijDTO.RijId;
            RijNummer = rijDTO.RijNummer;
        }

        public Rij()
        {

        }
    }
}
