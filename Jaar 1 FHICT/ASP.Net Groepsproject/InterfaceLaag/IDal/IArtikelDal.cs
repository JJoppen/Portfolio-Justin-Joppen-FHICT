using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.Interface;
using InterfaceLaag.IDal;

namespace InterfaceLaag.IDal
{
    public interface IArtikelDal
    {
        public List<ArtikelDTO> SelecteerArtikelList();
        public List<ArtikelDTO> SelecteerArtikelListMetZoekterm(string zoekterm);
        public bool ArtikelAanmaken(ArtikelDTO artikel);

        public bool ArtikelBewerken(ArtikelDTO artikel);

        public bool ArtikelVerwijderen(int id);

        public ArtikelDTO ArtikelOphalen(int id);
    }
}
