using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class ArtikelAanmakenViewModel
    {
        public ArtikelViewModel artikelViewModel { get; set; }
        public List<ArtikelGroepViewModel> artikelGroepViewModels { get; set; }
        public int GroepID { get; set; }
    }
}
