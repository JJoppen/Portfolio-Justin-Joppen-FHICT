using InterfaceLaag;
using InterfaceLaag.Interface;
using LogicaLaag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.ArtikelgroepTestOnderdelen
{
    class ArtikelgroepStub : IArtikelGroep
    {

        public bool retbool = true;
        public ArtikelGroepDTO retdto;
        public List<ArtikelGroepDTO> artikelGroepDTOs = new List<ArtikelGroepDTO>();
        public List<ArtikelGroep> artikelGroepen = new List<ArtikelGroep>();
        public int retid;

        public ArtikelgroepStub()
        {
            ArtikelGroepDTO artikelGroep1 = new ArtikelGroepDTO();
            artikelGroep1.GroepId = 1;
            artikelGroep1.Naam = "Koekjes";
            artikelGroep1.Beschrijving = "Van die dingen die je in je mond stopt.";
            artikelGroepDTOs.Add(artikelGroep1);
            
            ArtikelGroepDTO artikelGroep2 = new ArtikelGroepDTO();
            artikelGroep2.GroepId = 2;
            artikelGroep2.Naam = "Hondenbrokjes";
            artikelGroep2.Beschrijving = "Van die dingen die je hond vreet";
            artikelGroepDTOs.Add(artikelGroep2);

            ArtikelGroep artikelGroep3 = new ArtikelGroep(3, "Koekjes", "Van die dingen die je in je mond stopt");
            artikelGroepen.Add(artikelGroep3);
        }
        public bool ArtikelGroepAanmaken(ArtikelGroepDTO artikelgroep)
        {
            artikelGroepDTOs.Add(artikelgroep);
            return retbool;
        }

        public List<ArtikelGroepDTO> ArtikelGroepBekijken() //Naam bekijken
        {
            return artikelGroepDTOs;
        }

        public ArtikelGroepDTO ArtikelGroepDetails(int id) //Naam bekijken
        {
            ArtikelGroepDTO artikelGroep = new ArtikelGroepDTO();
            artikelGroep.GroepId = artikelGroepDTOs[id].GroepId;
            artikelGroep.Naam = artikelGroepDTOs[id].Naam;
            artikelGroep.Beschrijving = artikelGroepDTOs[id].Beschrijving;
            return artikelGroep;
        }

        public bool ArtikelGroepUpdaten(ArtikelGroepDTO artikelgroep) // Naam bekijken

        {
            retdto = artikelgroep;
            return retbool;
        }

        public bool ArtikelGroepVerwijderen(int id)
        {
            artikelGroepDTOs.RemoveAt(id);
            return retbool;
        }
    }
}
