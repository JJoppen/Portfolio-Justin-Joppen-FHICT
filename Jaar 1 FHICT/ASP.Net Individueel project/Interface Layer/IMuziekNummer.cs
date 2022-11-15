using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public interface IMuziekNummer
    {
        public bool InsertNummer(MuziekNummerDTO muzieknummer);
        public bool UpdateNummer(MuziekNummerDTO muziekNummerDTO);
        public MuziekNummerDTO SelectNummer(int userID);
        public List<MuziekNummerDTO> SelectNummerList();
        public List<MuziekNummerDTO> SelectNummersWithQuery(string Query);
        public List<MuziekNummerDTO> SelectNummersWithUserID(int id);

    }
}
