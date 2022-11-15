using LogicaLaag.AlleLocaties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class LocatieViewModel
    {
        [DisplayName("Locatie ID")]
        public int LocatieId { get; set; }
        [DisplayName("Magazijn ID")]
        public int MagazijnId { get; set; }
        [DisplayName("Rij")]
        public int RijNummer { get; set; }
        [DisplayName("Niveau")]
        public int NiveauId { get; set; }
        [DisplayName("Plek")]
        public int PlekId { get; set; }
        [DisplayName("Artikel")]
        public int ArtikelId { get; set; }
        [DisplayName("Is Bezet")]
        public bool IsBezet { get; set; }
        [DisplayName("Aantal")]
        public int AantalInLocatie { get; set; }
    }
}
