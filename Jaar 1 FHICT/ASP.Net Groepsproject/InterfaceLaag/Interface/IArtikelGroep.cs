using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IArtikelGroep
    {
        public bool ArtikelGroepAanmaken(ArtikelGroepDTO artikelgroep);
        public bool ArtikelGroepUpdaten(ArtikelGroepDTO artikelgroep);
        public bool ArtikelGroepVerwijderen(int id);
        public List<ArtikelGroepDTO> ArtikelGroepBekijken();
        public ArtikelGroepDTO ArtikelGroepDetails(int id);
    }
}
