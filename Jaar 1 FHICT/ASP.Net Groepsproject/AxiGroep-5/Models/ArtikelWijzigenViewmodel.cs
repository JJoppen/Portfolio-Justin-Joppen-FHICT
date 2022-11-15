using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class ArtikelWijzigenViewmodel
    {
        public ArtikelViewModel artikelViewModel { get; set; }
        public List<ArtikelGroepViewModel> ArtikelGroepViewModels { get; set; }
        public int GroepID { get; set; }
    }
}
