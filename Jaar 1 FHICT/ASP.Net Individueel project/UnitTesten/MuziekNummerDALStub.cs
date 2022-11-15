using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;


namespace DAL.Layer
{
    public class MuziekNummerDALStub : IMuziekNummer
    {

        public bool retbool = true;
        public MuziekNummerDTO retdto;
        public List<MuziekNummerDTO> retlist;
        public int retid;
        public string retstring;

        public bool InsertNummer(MuziekNummerDTO muzieknummer)
        {
            retdto = muzieknummer;
            return retbool;

        }

        public MuziekNummerDTO SelectNummer(int userID)
        {
            retid = userID;
            return retdto;
        }

        public List<MuziekNummerDTO> SelectNummerList()
        {

            return retlist;
        }

        public List<MuziekNummerDTO> SelectNummersWithQuery(string Query)
        {
            retstring = Query;
            return retlist;
        }

        public List<MuziekNummerDTO> SelectNummersWithUserID(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNummer(MuziekNummerDTO muziekNummerDTO)
        {
            retdto = muziekNummerDTO;
            return retbool;
        }
    }
}
