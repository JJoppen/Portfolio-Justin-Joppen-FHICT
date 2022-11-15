using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace UnitTesten
{
    public class ReactieStub : IReactie
    {
        public bool retbool = true;
        public int retid;
        public List<ReactieDTO> retlist;
        public ReactieDTO retdto;

        public bool DeleteComment(int id)
        {
            retid = id;
            return retbool;
        }

        public bool InsertReactie(ReactieDTO dto)
        {
            retdto = dto;
            return retbool;
        }

        public List<ReactieDTO> SelectCommentsVanNummer(int nummerID)
        {
            retid = nummerID;
            return retlist;
        }

        public bool UpdateReactie(ReactieDTO dto)
        {
            retdto = dto;
            return retbool;
        }
    }
}
