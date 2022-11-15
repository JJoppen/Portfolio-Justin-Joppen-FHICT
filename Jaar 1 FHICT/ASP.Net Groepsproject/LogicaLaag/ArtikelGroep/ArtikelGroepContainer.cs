using InterfaceLaag;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag
{
    public class ArtikelGroepContainer
    {
        private IArtikelGroep _IAGCcontext;

        public ArtikelGroepContainer(IArtikelGroep artikelgroepcontainer)
        {
            _IAGCcontext = artikelgroepcontainer;
        }

        public bool ArtikelGroepAanmaken(ArtikelGroep artikelgroep)
        {
            ArtikelGroepDTO artikelgroepDTO = new ArtikelGroepDTO();
            artikelgroepDTO.Naam = artikelgroep.Naam;
            artikelgroepDTO.Beschrijving = artikelgroep.Beschrijving;

            return _IAGCcontext.ArtikelGroepAanmaken(artikelgroepDTO);
        }

        public bool ArtikelGroepUpdaten(ArtikelGroep artikelgroep)
        {
            ArtikelGroepDTO artikelgroepDTO = new ArtikelGroepDTO();
            artikelgroepDTO.GroepId = artikelgroep.GroepId;
            artikelgroepDTO.Naam = artikelgroep.Naam;
            artikelgroepDTO.Beschrijving = artikelgroep.Beschrijving;

            return _IAGCcontext.ArtikelGroepUpdaten(artikelgroepDTO);
        }

        public bool ArtikelGroepVerwijderen(int id)
        {
            return _IAGCcontext.ArtikelGroepVerwijderen(id);
        }

        public List<ArtikelGroep> ArtikelGroepBekijken()
        {
            List<ArtikelGroep> artikelgroepen = new List<ArtikelGroep>();
            foreach (ArtikelGroepDTO item in _IAGCcontext.ArtikelGroepBekijken())
            {
                ArtikelGroep artikelgroep = new ArtikelGroep(item.GroepId, item.Naam, item.Beschrijving);
                artikelgroepen.Add(artikelgroep);
            }
            return artikelgroepen;
        }

        public ArtikelGroep ArtikelGroepDetails(int id)
        {
            ArtikelGroepDTO ArtikelGroepDTO = _IAGCcontext.ArtikelGroepDetails(id);
            ArtikelGroep artikelgroep = new ArtikelGroep(ArtikelGroepDTO.GroepId, ArtikelGroepDTO.Naam, ArtikelGroepDTO.Beschrijving);
            return artikelgroep;
        }
    }
}
