using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.IDal
{
    public interface IRijDAL
    {
        public bool RijAanmaken(int rijNummer);
        public RijDTO OphalenOpRijNummer(int rijNummer);
    }
}
