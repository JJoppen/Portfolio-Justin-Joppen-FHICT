using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.AlleLocaties
{
    public class Niveau
    {
        public int NiveauId { get; set; }
        public int RijId { get; set; }
        public List<Plek> Plekken { get; set; }


        public Niveau(int niveauId, int rijId, List<Plek> plekken)
        {
            NiveauId = niveauId;
            RijId = rijId;
            Plekken = plekken;
        }

        public Niveau(int rijId)
        {
            RijId = rijId;
        }

        public Niveau(NiveauDTO niveauDTO)
        {
            NiveauId = niveauDTO.NiveauId;
            RijId = niveauDTO.RijId;
        }
    }
}
