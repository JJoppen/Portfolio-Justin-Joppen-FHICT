using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using InterfaceLaag.Interface;

namespace LogicaLaag
{
    public class ArtikelGroep
    {
        public int GroepId { get; private set; }
        public string Naam { get; private set; }
        public string Beschrijving { get; private set; }

        public ArtikelGroep(string naam, string beschrijving)
        {
            Naam = naam;
            Beschrijving = beschrijving;
        }

        public ArtikelGroep(int groepId, string naam, string beschrijving)
        {
            GroepId = groepId;
            GroepId = groepId;
            Naam = naam;
            Beschrijving = beschrijving;
        }
        public ArtikelGroep(int groepId, string naam)
        {
            GroepId = groepId;
            Naam = naam;
        }

        public ArtikelGroep(int groepId)
        {
            GroepId = groepId;
        }

        public bool ArtikelGroepUpdaten(ArtikelGroep artikelgroep)
        {

            throw new NotImplementedException();
        }
        public bool ArtikelGroepAanmaken(ArtikelGroep artikelgroep)
        {

            throw new NotImplementedException();

        }
    }
}
