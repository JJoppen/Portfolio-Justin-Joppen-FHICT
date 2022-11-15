using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxiGroep_5.Models
{
    public class ArtikelViewModel
    {

        //artikel naam
        [DisplayName("Artikel naam")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Artikel naam in")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Je Naam moet tussen de {2} en {1} tekens zijn")]
        public string Artikelnaam { get; set; }
        // aantal
        [DisplayName("Aantal")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Aantal in")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Je Aantal moet tussen de {2} en {1} tekens zijn")]
        public double TotaalPrijs { get; set; }
        public int Aantal { get; set; }
        //artikelID
        [DisplayName("ArtikelID")]
        public int ArtikelID { get; set; }
        // artikelnummer
        [DisplayName("Artikel nummer")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Artikel nummer in")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Je Artikel nummer moet tussen de {2} en {1} tekens zijn")]
        public int Artikelnummer { get; set; }
        // artikelgroep
        public ArtikelGroepViewModel ArtikelGroepViewmodel { get; set; }
        //locatie
        [DisplayName("Locatie")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Locatie in")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Je Locatie moet tussen de {2} en {1} tekens zijn")]
        public string Locatie { get; set; }
        //prijs
        [DisplayName("Prijs")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Prijs naam in")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Je Prijs nummer moet tussen de {2} en {1} tekens zijn")]
        public double Prijs { get; set; }
        //beschrijving
        [DisplayName("Beschrijving")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een Beschrijving in")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Je Locatie moet tussen de {2} en {1} tekens zijn")]
        public string Beschrijving { get; set; }
        //THTdatum
        [DisplayName("Houdbaarheids datum")]
        public DateTime THT { get; set; }
        //afmeting
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een afmeting in")]
        public string Afmeting { get; set; }
        //kleur
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een kleur in")]
        public string Kleur { get; set; }
        //gewicht
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vul een gewicht in")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Het gewicht nummer moet tussen de {2} en {1} zijn")]
        public int Gewicht { get; set; }


        public ArtikelViewModel()
        {

        }

        public ArtikelViewModel(string artikelNaam, double prijs, string beschrijving, int v, int id)
        {
            Artikelnaam = artikelNaam;
            Prijs = prijs;
            Beschrijving = beschrijving;
            this.Aantal = v;
            this.ArtikelID = id;
        }

    }
}
