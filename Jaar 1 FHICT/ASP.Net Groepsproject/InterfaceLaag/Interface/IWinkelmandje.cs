using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IWinkelmandje
    {
        public void BestelWinkelmandje(List<ArtikelDTO> artikelDTOs, int GebruikerID);
    }
}
