using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class ReactieContainer
    {
        private IReactie Ireactie { get; set; }
        public ReactieContainer(IReactie reactie)
        {
            Ireactie = reactie;
        }
        

        public List<Reactie> SelectCommentsVanNummer(int Id)
        {
            List<ReactieDTO> DTOs = Ireactie.SelectCommentsVanNummer(Id);
            List<Reactie> reacties = new List<Reactie>();
            foreach(ReactieDTO reactieDTO in DTOs)
            {
                Reactie reactie = new Reactie(reactieDTO);
                reacties.Add(reactie);
            }

            return reacties;
        }
        public bool DeleteComment(int id)
        {
            return Ireactie.DeleteComment(id);
        }
    }
}
