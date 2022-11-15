using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag
{
    public struct ArtikelDTO
    {
        public double Prijs { get; set; }
        public ArtikelGroepDTO artikelGroep { get; set; }
        public int ArtikelID { get; set; }
        public int ArtikelNummer { get; set; }
        public int Aantal { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Tht { get; set; }
        public string Naam { get; set; }
        public string Afmeting { get; set; }
        public string Kleur { get; set; }
        public int Gewicht { get; set; }
        public bool IsVoedsel { get; set; }
    }
}
