using InterfaceLaag.DTO;
using LogicaLaag.KlantBestelling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_tests_.KlantBestellingTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class KlantBestellingContainerTesten
    {
        [TestMethod]
        public void GetKlantBestellingenTest()
        {
            //arrange
            int Artikelaantal = 1;
            DateTime thisstime = DateTime.Now;
            int BestellingID = 1;

            KlantBestellingDTO klantBestellingDTO = new KlantBestellingDTO();
            KlantBestellingStub stub = new KlantBestellingStub();

            klantBestellingDTO.Artikelaantal = Artikelaantal;
            klantBestellingDTO.BestellingID = BestellingID;
            klantBestellingDTO.datetime = DateTime.Now;

            stub.LastBestelling = klantBestellingDTO;
            KlantBestellingContainer klantBestellingContainer = new KlantBestellingContainer(stub);

            //act
            var Result = klantBestellingContainer.GetKlantBestellingen();

            //assert
            Assert.AreEqual(Result[0].Artikelaantal, Artikelaantal);
            Assert.AreEqual(Result[0].BestellingID, BestellingID);
        }

        [TestMethod]
        public void GetBestellingDetailsTest()
        {
            //arrange
            int bestellingid = 1;

            KlantBestellingStub stub = new KlantBestellingStub();
            KlantBestellingContainer klantBestellingContainer = new KlantBestellingContainer(stub);

            //act
            var Result = klantBestellingContainer.GetBestellingDetails(bestellingid);

            //assert
            Assert.AreEqual(bestellingid, stub.LastBestelling.BestellingID);

        }

        [TestMethod]
        public void BestellingAfronden()
        {
            //arrange
            int bestellingid = 1;

            KlantBestellingDTO klantBestellingDTO = new KlantBestellingDTO();
            KlantBestellingStub stub = new KlantBestellingStub();
            KlantBestellingContainer klantBestellingContainer = new KlantBestellingContainer(stub);

            //act
            klantBestellingContainer.BestellingAfronden(bestellingid);

            //assert
            Assert.AreEqual(bestellingid, stub.LastBestelling.BestellingID);
        }
    }
}
