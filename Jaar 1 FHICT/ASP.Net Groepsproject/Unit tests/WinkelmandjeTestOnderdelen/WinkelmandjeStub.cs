using InterfaceLaag;
using InterfaceLaag.Interface;
using LogicaLaag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.WinkelmandjeTestOnderdelen
{
    public class WinkelmandjeStub : IWinkelmandje
    {
        public List<ArtikelDTO> winkelmandje { get; set; }
        public int LastUser { get; set; }
        public void BestelWinkelmandje(List<ArtikelDTO> artikelDTOs, int GebruikerID)
        {
            winkelmandje = artikelDTOs;
            LastUser = GebruikerID;
        }
    }
}
