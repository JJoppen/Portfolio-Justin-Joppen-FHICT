using LogicaLaag;
using LogicaLaag.Winkelmandje;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_tests_.WinkelmandjeTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class WinkelmandjeContainerTesten 
    {
        [TestMethod]
        public void BestelWinkelmandje()
        {
            //arrange
            int GebruikerID = 1;
            string ArtikelNaam = "pizza";
            double Prijs = 1;
            int Aantal = 1;
            string Beschrijving = "worst met kaas en tomaat";
            int ArtikelID = 1;
            int ArtikelNummer = 471817;
            List<Artikel> artikels = new List<Artikel>();
            Artikel artikel = new Artikel(ArtikelNaam, Aantal, ArtikelNummer, ArtikelID, Prijs, Beschrijving);
            artikels.Add(artikel);

            WinkelmandjeStub stub = new WinkelmandjeStub();
            WinkelmandjeContainer klantBestellingContainer = new WinkelmandjeContainer(stub);

            //act
            klantBestellingContainer.BestelWinkelmandje(artikels, GebruikerID);

            //arrange
            Assert.AreEqual(GebruikerID, stub.LastUser);
            Assert.AreEqual(Prijs, stub.winkelmandje[0].Prijs);
            Assert.AreEqual(Aantal, stub.winkelmandje[0].Aantal);
            Assert.AreEqual(Beschrijving, stub.winkelmandje[0].Beschrijving);
            Assert.AreEqual(ArtikelID, stub.winkelmandje[0].ArtikelID);
            Assert.AreEqual(ArtikelNummer, stub.winkelmandje[0].ArtikelNummer);


        }

    }
}
