using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class ArtikelGroepViewModel
    {
        [DisplayName("Artikelgroep naam")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Artikelgroep naam in")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "De naam moet tussen de {2} en {1} tekens zijn")]
        public string naam { get; set; }

        [DisplayName("Beschrijving")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Beschrijving in")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Je Locatie moet tussen de {2} en {1} tekens zijn")]
        public string Beschrijving { get; set; }

        public int groepID { get; set; }

        public ArtikelGroepViewModel()
        {

        }
    }
}

