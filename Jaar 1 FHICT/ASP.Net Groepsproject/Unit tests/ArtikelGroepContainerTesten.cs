
using InterfaceLaag;
using LogicaLaag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Unit_tests_.ArtikelgroepTestOnderdelen
{
    [TestClass]
    public class ArtikelGroepContainerTesten
    {
        [TestMethod]
        public void ArtikelGroepAanmaken()
        {
            //arrange
            ArtikelgroepStub stub = new ArtikelgroepStub();
            ArtikelGroepContainer container = new ArtikelGroepContainer(stub);
            ArtikelGroep test = new ArtikelGroep(3, "Kaasjes", "Harde melk");

            //act
            bool retval = container.ArtikelGroepAanmaken(test);

            //assert
            Assert.AreEqual(3, stub.artikelGroepDTOs.Count);
            Assert.AreEqual("Kaasjes", stub.artikelGroepDTOs[2].Naam);
            Assert.AreEqual("Harde melk", stub.artikelGroepDTOs[2].Beschrijving);
            Assert.IsTrue(retval);

        }

        [TestMethod]
        public void ArtikelgroepBekijken()
        {
            ArtikelgroepStub stub = new ArtikelgroepStub();
            ArtikelGroepContainer container = new ArtikelGroepContainer(stub);

            List<ArtikelGroep> lijst = container.ArtikelGroepBekijken();

            Assert.IsNotNull(lijst);
            Assert.AreEqual(2, lijst.Count);
            Assert.AreEqual("Koekjes", lijst[0].Naam);
        }

        [TestMethod]
        public void ArtikelgroepVerwijderen()
        {
            ArtikelgroepStub stub = new ArtikelgroepStub();
            ArtikelGroepContainer container = new ArtikelGroepContainer(stub);

            bool retval = container.ArtikelGroepVerwijderen(1);

            Assert.IsTrue(retval);
            Assert.AreEqual(1, stub.artikelGroepDTOs.Count);
            Assert.AreNotEqual(1, stub.artikelGroepDTOs[0]);
        }

        [TestMethod]
        public void ArtikelGroepDetails()
        {
            ArtikelgroepStub stub = new ArtikelgroepStub();
            ArtikelGroepContainer container = new ArtikelGroepContainer(stub);
            ArtikelGroepDTO test = new ArtikelGroepDTO();

            test.GroepId = container.ArtikelGroepDetails(0).GroepId;
            test.Naam = container.ArtikelGroepDetails(0).Naam;
            test.Beschrijving = container.ArtikelGroepDetails(0).Beschrijving;

            Assert.AreEqual(1, test.GroepId);
            Assert.AreEqual("Koekjes", test.Naam);
            Assert.AreEqual("Van die dingen die je in je mond stopt.", test.Beschrijving);
        }

        [TestMethod]
        public void ArtikelGroepUpdaten()
        {
            ArtikelgroepStub stub = new ArtikelgroepStub();
            ArtikelGroepContainer container = new ArtikelGroepContainer(stub);
                        
            bool lekker = container.ArtikelGroepUpdaten(stub.artikelGroepen[0]);
            ArtikelGroep test = stub.artikelGroepen[0];

            Assert.AreEqual("Koekjes", test.Naam);
            Assert.IsTrue(lekker);
        }
    }
}


