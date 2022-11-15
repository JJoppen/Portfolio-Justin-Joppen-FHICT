using InterfaceLaag;
using InterfaceLaag.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.LocatieTestOnderdelen
{
    public class LocatieSTUB : ILocatieDal
    {
        public bool ArtikelIndelenOpLocatie(LocatieDTO locatieDTO)
        {
            throw new NotImplementedException();
        }

        public LocatieDTO LegeLocatieOphalen()
        {
            throw new NotImplementedException();
        }

        public bool LocatieAanmaken(LocatieDTO locatieDTO)
        {
            throw new NotImplementedException();
        }

        public LocatieDTO SelecteerLocatieOpId(int id)
        {
            throw new NotImplementedException();
        }

        public List<LocatieDTO> SelecteerLocaties()
        {
            throw new NotImplementedException();
        }

        public List<LocatieDTO> SelecteerLocatiesOpArtikel(int artikelId)
        {
            List<LocatieDTO> locatieDTOs = new List<LocatieDTO>();

            // Deze for loop vult de lijst metmlocaties met standaard artikelen en aantallen.
            // De standaard lijst heeft nog 355 overige ruimte
            // 50 * 10 - (10 + 11 + ... + 19) = 355
            for (int i = 0; i < 10; i++)
            {
                LocatieDTO locatieDTO = new LocatieDTO()
                {
                    ArtikelId = artikelId,
                    MagazijnId = 1,
                    RijNummer = i,
                    NiveauId = 1,
                    PlekId = 1,
                    IsBezet = true,
                    AantalInLocatie = i + 10
                };

                locatieDTOs.Add(locatieDTO);
            }

            return locatieDTOs;
        }

        public List<LocatieDTO> SelectLaagsteAantalInLocatie(List<ArtikelDTO> artikelDTOs)
        {
            throw new NotImplementedException();
        }

        public List<LocatieDTO> SelectLaagsteAantalInLocatie(List<int> artikelID)
        {
            throw new NotImplementedException();
        }
    }
}
