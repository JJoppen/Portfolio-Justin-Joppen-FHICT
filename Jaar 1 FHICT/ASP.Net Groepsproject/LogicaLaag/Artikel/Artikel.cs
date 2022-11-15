using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.IDal;



namespace LogicaLaag
{
    public class Artikel
    {
        private IArtikelDal IartikelDal;
        public string Artikelnaam { get; set; }
        public int Aantal { get; set; }
        public int ArtikelNummer { get; set; }
        public int ArtikelID { get; set; }
        public ArtikelGroep Artikelgroep { get; set; }
        public double Prijs { get; set; }
        public string Beschrijving { get; set; }
        public DateTime THT { get; set; }
        public string Afmeting { get; set; }
        public string Kleur { get; set; }
        public int Gewicht { get; set; }
        public bool IsVoedsel { get; set; }

        public Artikel(string artikelnaam, int aantal, int artikelnummer, ArtikelGroep artikelgroep, double prijs, string beschrijving, DateTime tHT)
        {
            Artikelnaam = artikelnaam;
            Aantal = aantal;
            ArtikelNummer = artikelnummer;
            Artikelgroep = artikelgroep;

            Prijs = prijs;
            Beschrijving = beschrijving;
            THT = tHT;
        }

        public Artikel(string artikelnaam, int aantal, int artikelnummer,int artikelid, double prijs, string beschrijving)
        {
            Artikelnaam = artikelnaam;
            Aantal = aantal;
            ArtikelNummer = artikelnummer;
            this.ArtikelID = artikelid;

            Prijs = prijs;
            Beschrijving = beschrijving;
        }

        public Artikel(ArtikelDTO artikeldto)
        {
            ArtikelGroep artikelgroep = new ArtikelGroep(artikeldto.artikelGroep.GroepId,artikeldto.artikelGroep.Naam);
            Artikelnaam = artikeldto.Naam;
            Aantal = artikeldto.Aantal;
            ArtikelID = artikeldto.ArtikelID;
            ArtikelNummer = artikeldto.ArtikelNummer;
            Artikelgroep = artikelgroep;
            Prijs = artikeldto.Prijs;
            Beschrijving = artikeldto.Beschrijving;
            THT = artikeldto.Tht;
            Afmeting = artikeldto.Afmeting;
            Kleur = artikeldto.Kleur;
            Gewicht = artikeldto.Gewicht;
            ArtikelID = artikeldto.ArtikelID;
            IsVoedsel = artikeldto.IsVoedsel;
        }

        public Artikel(string artikelnaam, int aantal, int artikelNummer, ArtikelGroep artikelgroep, double prijs, string beschrijving, DateTime tHT, string afmeting, string kleur, int gewicht) : this(artikelnaam, aantal, artikelNummer, artikelgroep, prijs, beschrijving, tHT)
        {
            Afmeting = afmeting;
            Kleur = kleur;
            Gewicht = gewicht;
        }

        public Artikel( string artikelnaam, int aantal, int artikelNummer, int artikelID, ArtikelGroep artikelgroep, double prijs, string beschrijving, DateTime tHT, string afmeting, string kleur, int gewicht)
        {

            Artikelnaam = artikelnaam;
            Aantal = aantal;
            ArtikelNummer = artikelNummer;
            ArtikelID = artikelID;
            Artikelgroep = artikelgroep;
            Prijs = prijs;
            Beschrijving = beschrijving;
            THT = tHT;
            Afmeting = afmeting;
            Kleur = kleur;
            Gewicht = gewicht;

        }

        public bool ArtikelUpdaten(Artikel artikel, IArtikelDal artikelDal)
        {
            ArtikelGroepDTO artikelgroep = new ArtikelGroepDTO()
            {
                Naam = artikel.Artikelgroep.Naam,
                GroepId = artikel.Artikelgroep.GroepId
            };

            ArtikelDTO artikeldto = new ArtikelDTO()
            {
                Prijs = artikel.Prijs,
                artikelGroep = artikelgroep,
                ArtikelID = artikel.ArtikelID,
                ArtikelNummer = artikel.ArtikelNummer,
                Aantal = artikel.Aantal,
                Beschrijving = artikel.Beschrijving,
                Tht = artikel.THT,
                Naam = artikel.Artikelnaam,
                Kleur = artikel.Kleur,
                Gewicht = artikel.Gewicht,
                Afmeting = artikel.Afmeting,
                IsVoedsel = artikel.IsVoedsel
            };
            IartikelDal = artikelDal;
           return IartikelDal.ArtikelBewerken(artikeldto);

        }
        public bool ArtikelAanmaken(Artikel artikel, IArtikelDal artikelDal)
        {
            ArtikelGroepDTO artikelgroep = new ArtikelGroepDTO()
            {
                Naam = artikel.Artikelgroep.Naam,
                GroepId = artikel.Artikelgroep.GroepId
            };
            ArtikelDTO artikeldto = new ArtikelDTO()
            {
                Prijs = artikel.Prijs,
                artikelGroep = artikelgroep,
                ArtikelID = artikel.ArtikelID,
                ArtikelNummer = artikel.ArtikelNummer,
                Aantal = artikel.Aantal,
                Beschrijving = artikel.Beschrijving,
                Tht = artikel.THT,
                Naam = artikel.Artikelnaam,
                Kleur = artikel.Kleur,
                Gewicht = artikel.Gewicht,
                Afmeting = artikel.Afmeting,
                IsVoedsel = artikel.IsVoedsel
            };
            IartikelDal = artikelDal;
            return IartikelDal.ArtikelAanmaken(artikeldto);

        }


    }
}
