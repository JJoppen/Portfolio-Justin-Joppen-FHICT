using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public interface IReactie
    {
        public bool InsertReactie(ReactieDTO dto);
        public bool UpdateReactie(ReactieDTO dto);
        public List<ReactieDTO> SelectCommentsVanNummer(int nummerID);
        public bool DeleteComment(int id);
    }
}
