using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.IDal;
using LogicaLaag;

namespace LogicaLaag
{
    public class Magazijn
    {

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Straatnaam { get; set; }
        public int Huisnummer { get; set; }
        public string Postcode { get; set; }

        public Magazijn(int id, string naam, string straatnaam, int huisnummer, string postcode)
        {
            Id = Id;
            Naam = naam;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
        }

        public Magazijn(string naam, string straatnaam, int huisnummer, string postcode)
        {
            Naam = naam;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
        }

        public Magazijn(MagazijnDTO magazijnDTO)
        {
            Id = magazijnDTO.Id;
            Naam = magazijnDTO.Naam;
            Straatnaam = magazijnDTO.Straatnaam;
            Huisnummer = magazijnDTO.Huisnummer;
            Postcode = magazijnDTO.Postcode;
        }
        public Magazijn()
        {

        }
        //public bool ArtikeltIndelen(Artikel artikel)
        //{
        //    foreach (Locatie locatie in Locaties)
        //    {
        //        if (locatie.IsLeeg == false)
        //        {
        //            locatie.ArtikelID = artikel.ArtikelID;
        //            locatie.IsLeeg = true;
        //            return true;
        //        }
        //    }
        //    return false;
        //}

 
    }
}

