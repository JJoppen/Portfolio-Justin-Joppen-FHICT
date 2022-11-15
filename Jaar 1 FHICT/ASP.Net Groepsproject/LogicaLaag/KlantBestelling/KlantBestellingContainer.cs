using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.Interface;
using InterfaceLaag.DTO;

namespace LogicaLaag.KlantBestelling
{
    public class KlantBestellingContainer
    {
        private IKlantBestelling IklantBestelling;
        
        public KlantBestellingContainer(IKlantBestelling klantBestelling)
        {
            IklantBestelling = klantBestelling;
        }

        public List<KlantBestelling> GetKlantBestellingen()
        {
            List<KlantBestelling> klantbestellingen = new List<KlantBestelling>();
            foreach(KlantBestellingDTO klantbestellingdto in IklantBestelling.getbestelling())
            {
                KlantBestelling klantBestelling = new KlantBestelling(klantbestellingdto.Artikelaantal, klantbestellingdto.BestellingID, klantbestellingdto.datetime);
                klantbestellingen.Add(klantBestelling);
            }
            return klantbestellingen;
        }

        public List<KlantBestelling> GetBestellingDetails(int bestellingid)
        {
            List<KlantBestelling> klantbestellingen = new List<KlantBestelling>();
            KlantBestellingDTO klantbestellingDTO = new KlantBestellingDTO();
            klantbestellingDTO.BestellingID = bestellingid;
            foreach (KlantBestellingDTO klantbestellingdto in IklantBestelling.GetBestellingDetails(klantbestellingDTO))
            {
                KlantBestelling klantBestelling = new KlantBestelling(klantbestellingdto.Artikelaantal, klantbestellingdto.ArtikelNaam, klantbestellingdto.BesteldeArtikelID);
                klantbestellingen.Add(klantBestelling);
            }
            return klantbestellingen;
        }

        public void BestellingAfronden(int bestellingid)
        {
            KlantBestellingDTO klantBestellingDTO = new KlantBestellingDTO();
            klantBestellingDTO.BestellingID = bestellingid;
            IklantBestelling.BestellingAfronden(klantBestellingDTO);
        }
    }
}
