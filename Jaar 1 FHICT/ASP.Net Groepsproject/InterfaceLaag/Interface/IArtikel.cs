using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IArtikel
    {
        //public List<Locatie> Locatie { get; set; }
        public int ArtikelID { get; set; }
        public int ArtikelNummer { get; set; }
        public int GroepID { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public int Prijs { get; set; }
        public int Aantal { get; set; }
        public DateTime Tht { get; set; }
        public string Afmeting { get; set; }
        public string Kleur { get; set; }
        public int Gewicht { get; set; }


        public bool ArtikelUpdaten(ArtikelDTO artikelDTO);
        public bool ArtikelAanmaken();
    }
}
