using InterfaceLaag.DTO;
using InterfaceLaag.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_tests_.KlantBestellingTestOnderdelen
{
    [TestClass]
    public class KlantBestellingStub : IKlantBestelling
    {
        public KlantBestellingDTO LastBestelling { get; set; }
        public void BestellingAfronden(KlantBestellingDTO klantBestellingDTO)
        {
            LastBestelling = klantBestellingDTO;
        }

        public List<KlantBestellingDTO> getbestelling()
        {
            DateTime dateTime = DateTime.Now;
            List<KlantBestellingDTO> klantBestellingDTOs = new List<KlantBestellingDTO>();
            KlantBestellingDTO dto = new KlantBestellingDTO();
            dto.Artikelaantal = 1;
            dto.datetime = dateTime;
            dto.BestellingID = 1;
            klantBestellingDTOs.Add(dto);
            return klantBestellingDTOs;
        }

        public List<KlantBestellingDTO> GetBestellingDetails(KlantBestellingDTO klantBestellingDTO)
        {
            List<KlantBestellingDTO> klantBestellingDTOs = new List<KlantBestellingDTO>();
            klantBestellingDTOs.Add(klantBestellingDTO);
            LastBestelling = klantBestellingDTO;
            return klantBestellingDTOs;
        }
    }
}
