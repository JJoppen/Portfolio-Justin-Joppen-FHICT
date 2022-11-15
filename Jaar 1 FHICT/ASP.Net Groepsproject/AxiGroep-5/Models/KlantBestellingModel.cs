using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class KlantBestellingModel
    {
        public int BestellingID { get; set; }
        public int Artikelaantal { get; set; }
        public int GebruikerNaam { get; set; }
        public int GebruikerID { get; set; }
        public string ArtikelNaam { get; set; }
        public int ArtikelID { get; set; }
        public DateTime DagTijd { get; set; }
    }
}
