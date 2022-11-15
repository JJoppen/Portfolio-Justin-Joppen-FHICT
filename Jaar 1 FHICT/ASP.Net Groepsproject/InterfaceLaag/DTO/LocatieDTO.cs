using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag
{
    public struct LocatieDTO
    {
        public int LocatieId { get; set; }
        public int MagazijnId { get; set; }
        public int RijNummer { get; set; }
        public int NiveauId { get; set; }
        public int PlekId { get; set; }
        public bool IsBezet { get; set; }
        public int ArtikelId { get; set; }
        public int AantalInLocatie { get; set; }

    }
}
