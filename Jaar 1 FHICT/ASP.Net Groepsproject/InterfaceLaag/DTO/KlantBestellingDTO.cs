using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class KlantBestellingDTO
    {
        public int BestellingID { get; set; }
        public int BesteldeArtikelID { get; set; }
        public int Artikelaantal { get; set; }
        public string ArtikelNaam { get; set; }
        public DateTime datetime { get; set; }
    }
}
