using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag;
using LogicaLaag.AlleLocaties;
using DAL;
using InterfaceLaag.IDal;
using InterfaceLaag.DTO;
using LogicaLaag.KlantBestelling;

namespace LogicaLaag.AlleLocaties
{
    public class LocatieContainer
    {
        private int maxRuimteLocatie = 50;
        public List<Locatie> Locaties { get; set; } = new List<Locatie>();

        private ILocatieDal ILocatieDal;

        public LocatieContainer(ILocatieDal iLocatieDAL)
        {
            ILocatieDal = iLocatieDAL;
        }

        public void LocatieAanmaken(Locatie locatie, int aantalNiveaus, int aantalPlekken)
        {
            if (!locatie.IsBezet)
            {
                locatie.AantalInLocatie = 0;
            }
            LocatieDTO locatieDTO = new LocatieDTO
            {
                LocatieId = locatie.LocatieId,
                MagazijnId = locatie.MagazijnId,
                RijNummer = locatie.RijNummer,
                NiveauId = 0,
                PlekId = locatie.PlekId,
                IsBezet = locatie.IsBezet,
                ArtikelId = locatie.ArtikelId
            };
            for (int i = 1; i < aantalNiveaus + 1; i++)
            {
                locatieDTO.NiveauId++;
                locatieDTO.PlekId = 1;
                for (int j = 0; j < aantalPlekken; j++)
                {
                    ILocatieDal.LocatieAanmaken(locatieDTO);
                    locatieDTO.PlekId++;
                }
            }
        }

        public List<Locatie> LocatiesOphalenOpArtikelId(int artikelId)
        {
            List<LocatieDTO> locatieDTOs = ILocatieDal.SelecteerLocatiesOpArtikel(artikelId);
            foreach (LocatieDTO locatieDTO in locatieDTOs)
            {
                Locatie locatie = new Locatie(locatieDTO);
                Locaties.Add(locatie);
            }
            return Locaties;
        }

        public List<Locatie> LocatiesOphalen()
        {
            List<LocatieDTO> locatieDTOs = ILocatieDal.SelecteerLocaties();
            foreach (LocatieDTO locatieDTO in locatieDTOs)
            {
                Locatie locatie = new Locatie(locatieDTO);
                Locaties.Add(locatie);
            }
            return Locaties;
        }

        public List<Locatie> SelectLaagsteAantalInLocatie(int bestellingID)
        {
            KlantBestellingContainer klantBestellingContainer = new KlantBestellingContainer(new KlantBestellingMSSQL());

            List<LogicaLaag.KlantBestelling.KlantBestelling> bestellingen = klantBestellingContainer.GetBestellingDetails(bestellingID);
            List<int> artikelIds = new List<int>();
            foreach(LogicaLaag.KlantBestelling.KlantBestelling klantBestelling in bestellingen)
            {
                artikelIds.Add(klantBestelling.BesteldeArtikelID);
            }


            List<LocatieDTO> locatieDTOs = ILocatieDal.SelectLaagsteAantalInLocatie(artikelIds);

            List<LocatieDTO> LocatieDTOsCorrecteAantal = new List<LocatieDTO>();


            foreach(LocatieDTO DTO in locatieDTOs)
            {
                foreach(LogicaLaag.KlantBestelling.KlantBestelling klantBestelling in bestellingen)
                {
                    if(klantBestelling.BesteldeArtikelID == DTO.ArtikelId)
                    {
                        var locatiedto = DTO;
                        locatiedto.AantalInLocatie = klantBestelling.Artikelaantal;
                        LocatieDTOsCorrecteAantal.Add(locatiedto);
                    }
                    
                }
            }
            List<LocatieDTO> GesorteerdeLocaties = LocatieDTOsCorrecteAantal.OrderBy(x => x.RijNummer)
                                      .ThenBy(x => x.PlekId)
                                      .ToList();


            foreach (LocatieDTO locatieDTO in GesorteerdeLocaties)
            {
                Locatie locatie = new Locatie(locatieDTO);
                Locaties.Add(locatie);
            }
            return Locaties;
        }

        public Locatie SelecteerLocatieOpId(int id)
        {
            LocatieDTO locatieDTO = ILocatieDal.SelecteerLocatieOpId(id);
            return new Locatie(locatieDTO);
        }

        public bool ArtikelIndelenOpLocatie(List<Tuple<Locatie, int>> locaties)
        {
            foreach (Tuple<Locatie, int> locatie in locaties)
            {
                LocatieDTO locatieDTO = new LocatieDTO();
                if (locatie.Item1.LocatieId == 0)
                {
                    locatieDTO = ILocatieDal.LegeLocatieOphalen();
                    locatieDTO.ArtikelId = locatie.Item1.ArtikelId;
                    locatieDTO.AantalInLocatie = locatie.Item2;
                }
                else
                {
                    locatieDTO = ILocatieDal.SelecteerLocatieOpId(locatie.Item1.LocatieId);
                    locatieDTO.AantalInLocatie = locatie.Item2 + locatieDTO.AantalInLocatie;
                }
                if (locatieDTO.AantalInLocatie != 0)
                {
                    locatieDTO.IsBezet = true;
                }
                if (!ILocatieDal.ArtikelIndelenOpLocatie(locatieDTO))
                {
                    return false;
                }
            }
            return true;
        }

        public bool VoorraadBijwerkenNaBestelling(List<Tuple<Locatie, int>> locaties)
        {
            foreach (Tuple<Locatie, int> locatie in locaties)
            {
                bool isBezet = true;
                if(locatie.Item1.AantalInLocatie == 0)
                {
                    isBezet = false;
                }
                LocatieDTO locatieDTO = new LocatieDTO
                {
                    AantalInLocatie = locatie.Item1.AantalInLocatie - locatie.Item2,
                    IsBezet = isBezet,
                    LocatieId = locatie.Item1.LocatieId,
                    ArtikelId = locatie.Item1.ArtikelId
                };
                if (!ILocatieDal.ArtikelIndelenOpLocatie(locatieDTO))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sorteert een lijst met locaties op lege ruimte. 
        /// </summary>
        /// <param name="locaties">De nog niet gesorteerde lijst met locaties</param>
        /// <returns>Geeft een lijst terug met dezelfde locaties, gesorteerd op gevulde ruimte met de minste ruimte over als eerst.</returns>
        public List<Locatie> SorteerLocatieLijstOpRuimte(List<Locatie> locaties)
        {
            List<Locatie> sorteerdLocaties = new List<Locatie>();

            while (locaties.Count > 0)
            {
                int hoogsteAantal = 0;
                Locatie volsteLocatie = new Locatie();

                foreach (Locatie locatie in locaties)
                {
                    if (locatie.AantalInLocatie > hoogsteAantal)
                    {
                        hoogsteAantal = locatie.AantalInLocatie;
                        volsteLocatie = locatie;
                    }
                }

                // Verwijder de gevonden locatie uit de oude lijst zodat hier niet meer naar gekeken wordt.
                locaties.Remove(volsteLocatie);
                // Voeg de gevonden locatie toe aan de nieuwe lijst.
                sorteerdLocaties.Add(volsteLocatie);
            }
            return sorteerdLocaties;
        }

        public List<Tuple<Locatie, int>> VerdeelArtikel(Artikel artikel)
        {
            // Haal een lijst op met alle bestaande locaties van het gekozen product.
            List<Locatie> artikelLocaties = LocatiesOphalenOpArtikelId(artikel.ArtikelID);
            artikelLocaties = SorteerLocatieLijstOpRuimte(artikelLocaties); // Sorteer de lijst met locaties op overgebleven ruimte.
            List<Tuple<Locatie, int>> locatieVerdeling = new List<Tuple<Locatie, int>>();

            foreach (Locatie locatie in artikelLocaties)
            {
                // Bereken de vrije ruimte in de locatie.
                int maxArtikelAantal = maxRuimteLocatie - locatie.AantalInLocatie;

                // Wanneer het aantal artikelen lager is dan de lege ruimte,
                // verander het maximaal in te delen artikelen naar het aantal artikelen.
                if (artikel.Aantal < maxArtikelAantal) maxArtikelAantal = artikel.Aantal;

                Tuple<Locatie, int> locatieAantal = new Tuple<Locatie, int>(locatie, maxArtikelAantal);
                locatieVerdeling.Add(locatieAantal);

                // Haal de ingedeelde artikelen van het aantal artikelen af.
                artikel.Aantal -= maxArtikelAantal;

                // Wanneer de artikelen allemaal verdeeld zijn moet deze methode stoppen. 
                if (artikel.Aantal <= 0)
                {
                    return locatieVerdeling;
                }
            }

            // Wanneer alle bestande locaties gebruikt zijn en er nogsteeds artikelen over zijn start deze while loop.
            // De overige artikelen worden verdeeld over nieuwe locaties. 
            while (artikel.Aantal > 0)
            {
                Locatie nieuweLocatie = new Locatie(0, artikel.ArtikelID);

                if (artikel.Aantal > 50) // Wanneer het aantal artikelen niet in een locatie gaat passen.
                {
                    Tuple<Locatie, int> locatieAantal = new Tuple<Locatie, int>(nieuweLocatie, 50);
                    locatieVerdeling.Add(locatieAantal);
                    artikel.Aantal -= 50;
                }
                else // Wanneer het aantal artikelen wel in een locatie gaat passen.
                {
                    Tuple<Locatie, int> locatieAantal = new Tuple<Locatie, int>(nieuweLocatie, artikel.Aantal);
                    locatieVerdeling.Add(locatieAantal);
                    artikel.Aantal = 0;
                }
            }

            return locatieVerdeling;
        }
    }
}
