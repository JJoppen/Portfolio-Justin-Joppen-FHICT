using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.IDal;
using InterfaceLaag;

namespace LogicaLaag
{
    public class ArtikelContainer
    {
        private IArtikelDal IartikelDal;
        public Artikel OmzettenNaarArtikel(ArtikelDTO artikeldto)
        {
            Artikel artikel = new Artikel(artikeldto);

            return artikel;
        }
        public ArtikelDTO OmzettenNaarArtikelDTO(Artikel artikel)
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

            return artikeldto;
        }

        public List<Artikel> SelecteerArtikels()
        {
            List<ArtikelDTO> artikelDTOs;
            artikelDTOs = IartikelDal.SelecteerArtikelList();
            List<Artikel> artikels = new List<Artikel>();
            foreach(ArtikelDTO artikeldto in artikelDTOs)
            {
                Artikel artikel = OmzettenNaarArtikel(artikeldto);
                artikels.Add(artikel);
            }
            return artikels;
        }

        public List<Artikel> SelecteerArtikelMetZoekTerm(string zoekterm)
        {
            List<ArtikelDTO> artikelDTOs = IartikelDal.SelecteerArtikelListMetZoekterm(zoekterm);
            List<Artikel> artikels = new List<Artikel>();
            foreach(ArtikelDTO artikeldto in artikelDTOs)
            {
                Artikel artikel = OmzettenNaarArtikel(artikeldto);
                artikels.Add(artikel);
            }
            return artikels;
        }
        public bool VerwijderArtikel(int ID)
        {
            return IartikelDal.ArtikelVerwijderen(ID);

        }
        public Artikel SelecteerArtikel(int ID)
        {
            ArtikelDTO artikeldto = IartikelDal.ArtikelOphalen(ID);

            return OmzettenNaarArtikel(artikeldto);
        }

        public bool LeveringToevoegen(List<Artikel> levering)
        {
            foreach (Artikel artikel in levering)
            {
                ArtikelDTO artikelDTO = OmzettenNaarArtikelDTO(artikel);
                bool x = IartikelDal.ArtikelBewerken(artikelDTO);

                if (x != true)
                {
                    return false;
                }
            }

            return true;
        }

        public ArtikelContainer(IArtikelDal Iartikeldal)
        {
            IartikelDal = Iartikeldal;
        }
    }
}
