using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.IDal;

namespace Unit_tests_.ArtikelTestOnderdelen
{
    public class ArtikelStub : IArtikelDal
    {
        public bool retbool;
        public ArtikelDTO retdto;
        public List<ArtikelDTO> retlist;
        public int retid;

        public bool ArtikelAanmaken(ArtikelDTO artikel)
        {
            retdto = artikel;
            return retbool;
        }

        public bool ArtikelBewerken(ArtikelDTO artikel)
        {
            retdto = artikel;
            return retbool;
        }

        public ArtikelDTO ArtikelOphalen(int id)
        {
            retid = id;
            return retdto;
        }

        public bool ArtikelVerwijderen(int id)
        {
            retid = id;
            return retbool;
        }

        public List<ArtikelDTO> SelecteerArtikelList()
        {

            
            return retlist;

        }

        public List<ArtikelDTO> SelecteerArtikelListMetZoekterm(string zoekterm)
        {
            throw new NotImplementedException();
        }
    }
}
