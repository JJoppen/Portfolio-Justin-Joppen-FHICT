using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface ILocatie
    {
        public int LocatieID { get; set; }
        public int ArtikelID { get; set; }
        public int MagazijnID { get; set; }
        public int Rij { get; set; }
        public int Plek { get; set; }
        public int Niveau { get; set; }
        public bool IsLeeg { get; set; }
    }
}
