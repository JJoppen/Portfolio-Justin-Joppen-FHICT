using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class MagazijnViewModel
    {
        [DisplayName("Magazijn ID")]
        public int Id { get; set; }
        [DisplayName("Magazijn Naam")]
        public string Naam { get; set; }
        [DisplayName("Straat")]
        public string Straatnaam { get; set; }
        [DisplayName("Huisnummer")]
        public int Huisnummer { get; set; }
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
    }
}
