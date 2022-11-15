using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaLaag;
using InterfaceLaag;
using System.Collections.Generic;
using Unit_tests_.ArtikelTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class ArtikelContainerTesten
    {
        public static System.DateTime date1 = new System.DateTime(2021, 12, 30);
        public static System.DateTime date2 = new System.DateTime(2021, 12, 14);

        public static ArtikelGroepDTO ArtikelGroepDTO = new ArtikelGroepDTO
        {
            Naam = "Fruit",
            GroepId = 1,
        };
        public static ArtikelDTO artikel2 = new ArtikelDTO
            {
                Naam = "Peer",
                Aantal = 5,
                ArtikelNummer = 6,
                ArtikelID = 7,
                artikelGroep = ArtikelGroepDTO,
                Prijs = 6.5,
                Beschrijving = "Peer",
                Tht = date2,
                Afmeting = "10x10x5",
                Kleur = "Groen",
                Gewicht = 12,
                IsVoedsel = true,
            };
        public static ArtikelDTO artikel1 = new ArtikelDTO
        {
            Naam = "appel",
            Aantal = 1,
            ArtikelNummer = 2,
            ArtikelID = 3,
            artikelGroep = ArtikelGroepDTO,
            Prijs = 6.5,
            Beschrijving = "Groene appel",
            Tht = date1,
            Afmeting = "10x10x5",
            Kleur = "Groen",
            Gewicht = 12,
            IsVoedsel = true,
        };
        [TestMethod]
        public void TestVerwijderArtikelTrue()
        {
            // arrange
            int id = 7;
            ArtikelStub stub = new ArtikelStub();
            stub.retbool = true;
            var Artikelcontainer = new ArtikelContainer(stub);
            //act
            var insertresult = Artikelcontainer.VerwijderArtikel(id);
            int retint = stub.retid;

            //assert
            Assert.AreEqual(id, retint);
            Assert.IsTrue(insertresult);
        }
        [TestMethod]
        public void TestVerwijderArtikelFalse()
        {
            // arrange
            int id = 7;
            ArtikelStub stub = new ArtikelStub();
            stub.retbool = false;
            var Artikelcontainer = new ArtikelContainer(stub);
            //act
            var insertresult = Artikelcontainer.VerwijderArtikel(id);
            int retint = stub.retid;

            //assert
            Assert.AreEqual(id, retint);
            Assert.IsFalse(insertresult);
        }
        [TestMethod]
        public void SelecteerArtikelList()
        {
            //arrange

            List<ArtikelDTO> artikels = new List<ArtikelDTO>();
            artikels.Add(artikel1);
            artikels.Add(artikel2);
            ArtikelStub stub = new ArtikelStub();
            stub.retlist = artikels;
            ArtikelContainer container = new ArtikelContainer(stub);
            // act
            List<Artikel> ReturnList = container.SelecteerArtikels();
            bool retbool = stub.retbool;
            //Assert

            for (int i = 0; i < artikels.Count; i++)
            {
                Assert.AreEqual(ReturnList[i].Artikelnaam, artikels[i].Naam);
                Assert.AreEqual(ReturnList[i].Aantal, artikels[i].Aantal);
                Assert.AreEqual(ReturnList[i].ArtikelNummer, artikels[i].ArtikelNummer);
                Assert.AreEqual(ReturnList[i].ArtikelID, artikels[i].ArtikelID);
                Assert.AreEqual(ReturnList[i].Artikelgroep.GroepId, artikels[i].artikelGroep.GroepId);
                Assert.AreEqual(ReturnList[i].Artikelgroep.Naam, artikels[i].artikelGroep.Naam);
                Assert.AreEqual(ReturnList[i].Prijs, artikels[i].Prijs);
                Assert.AreEqual(ReturnList[i].Beschrijving, artikels[i].Beschrijving);
                Assert.AreEqual(ReturnList[i].THT, artikels[i].Tht);
                Assert.AreEqual(ReturnList[i].Afmeting, artikels[i].Afmeting);
                Assert.AreEqual(ReturnList[i].Kleur, artikels[i].Kleur);
                Assert.AreEqual(ReturnList[i].Gewicht, artikels[i].Gewicht);
                Assert.AreEqual(ReturnList[i].IsVoedsel, artikels[i].IsVoedsel);
            }
            
        }
        [TestMethod]
        public void TestToevoegenArtikelTrue()
        {
            //Arrange
            ArtikelStub stub = new ArtikelStub();
            Artikel Artikel = new Artikel(artikel1);
            stub.retbool = true;
            //act
            Artikel.ArtikelAanmaken(Artikel, stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsTrue(stub.retbool);
            Assert.AreEqual(retdto.Aantal, Artikel.Aantal);
            Assert.AreEqual(retdto.Afmeting, Artikel.Afmeting);
            Assert.AreEqual(retdto.artikelGroep.Naam, Artikel.Artikelgroep.Naam);
            Assert.AreEqual(retdto.artikelGroep.GroepId, Artikel.Aantal);
            Assert.AreEqual(retdto.ArtikelID, Artikel.ArtikelID);
            Assert.AreEqual(retdto.ArtikelNummer, Artikel.ArtikelNummer);
            Assert.AreEqual(retdto.Beschrijving, Artikel.Beschrijving);
            Assert.AreEqual(retdto.Gewicht, Artikel.Gewicht);
            Assert.AreEqual(retdto.IsVoedsel, Artikel.IsVoedsel);
            Assert.AreEqual(retdto.Kleur, Artikel.Kleur);
            Assert.AreEqual(retdto.Naam, Artikel.Artikelnaam);
            Assert.AreEqual(retdto.Prijs, Artikel.Prijs);
            Assert.AreEqual(retdto.Tht, Artikel.THT);
        }

        [TestMethod]
        public void TestToevoegenArtikelFalse()
        {
            //Arrange
            ArtikelStub stub = new ArtikelStub();
            Artikel Artikel = new Artikel(artikel1);
            stub.retbool = false;
            //act
            Artikel.ArtikelAanmaken(Artikel, stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsFalse(stub.retbool);
            Assert.AreEqual(retdto.Aantal, Artikel.Aantal);
            Assert.AreEqual(retdto.Afmeting, Artikel.Afmeting);
            Assert.AreEqual(retdto.artikelGroep.Naam, Artikel.Artikelgroep.Naam);
            Assert.AreEqual(retdto.artikelGroep.GroepId, Artikel.Aantal);
            Assert.AreEqual(retdto.ArtikelID, Artikel.ArtikelID);
            Assert.AreEqual(retdto.ArtikelNummer, Artikel.ArtikelNummer);
            Assert.AreEqual(retdto.Beschrijving, Artikel.Beschrijving);
            Assert.AreEqual(retdto.Gewicht, Artikel.Gewicht);
            Assert.AreEqual(retdto.IsVoedsel, Artikel.IsVoedsel);
            Assert.AreEqual(retdto.Kleur, Artikel.Kleur);
            Assert.AreEqual(retdto.Naam, Artikel.Artikelnaam);
            Assert.AreEqual(retdto.Prijs, Artikel.Prijs);
            Assert.AreEqual(retdto.Tht, Artikel.THT);
        }
        [TestMethod]
        public void TestUpdatenArtikelTrue()
        {
            //Arrange
            ArtikelStub stub = new ArtikelStub();
            Artikel Artikel = new Artikel(artikel1);
            stub.retbool = true;
            //act
            Artikel.ArtikelUpdaten(Artikel, stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsTrue(stub.retbool);
            Assert.AreEqual(retdto.Aantal, Artikel.Aantal);
            Assert.AreEqual(retdto.Afmeting, Artikel.Afmeting);
            Assert.AreEqual(retdto.artikelGroep.Naam, Artikel.Artikelgroep.Naam);
            Assert.AreEqual(retdto.artikelGroep.GroepId, Artikel.Aantal);
            Assert.AreEqual(retdto.ArtikelID, Artikel.ArtikelID);
            Assert.AreEqual(retdto.ArtikelNummer, Artikel.ArtikelNummer);
            Assert.AreEqual(retdto.Beschrijving, Artikel.Beschrijving);
            Assert.AreEqual(retdto.Gewicht, Artikel.Gewicht);
            Assert.AreEqual(retdto.IsVoedsel, Artikel.IsVoedsel);
            Assert.AreEqual(retdto.Kleur, Artikel.Kleur);
            Assert.AreEqual(retdto.Naam, Artikel.Artikelnaam);
            Assert.AreEqual(retdto.Prijs, Artikel.Prijs);
            Assert.AreEqual(retdto.Tht, Artikel.THT);
        }

        [TestMethod]
        public void TestUpdatenArtikelFalse()
        {
            //Arrange
            ArtikelStub stub = new ArtikelStub();
            Artikel Artikel = new Artikel(artikel1);
            stub.retbool = false;
            //act
            Artikel.ArtikelUpdaten(Artikel, stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsFalse(stub.retbool);
            Assert.AreEqual(retdto.Aantal, Artikel.Aantal);
            Assert.AreEqual(retdto.Afmeting, Artikel.Afmeting);
            Assert.AreEqual(retdto.artikelGroep.Naam, Artikel.Artikelgroep.Naam);
            Assert.AreEqual(retdto.artikelGroep.GroepId, Artikel.Aantal);
            Assert.AreEqual(retdto.ArtikelID, Artikel.ArtikelID);
            Assert.AreEqual(retdto.ArtikelNummer, Artikel.ArtikelNummer);
            Assert.AreEqual(retdto.Beschrijving, Artikel.Beschrijving);
            Assert.AreEqual(retdto.Gewicht, Artikel.Gewicht);
            Assert.AreEqual(retdto.IsVoedsel, Artikel.IsVoedsel);
            Assert.AreEqual(retdto.Kleur, Artikel.Kleur);
            Assert.AreEqual(retdto.Naam, Artikel.Artikelnaam);
            Assert.AreEqual(retdto.Prijs, Artikel.Prijs);
            Assert.AreEqual(retdto.Tht, Artikel.THT);
        }
        [TestMethod]
        public void TestSelectArtikelFalse()
        {
            //Arrange
            ArtikelStub stub = new ArtikelStub();
            var container = new ArtikelContainer(stub);
            stub.retdto = artikel1;
            stub.retid = artikel1.ArtikelID;
            //Act
            var retdto = container.SelecteerArtikel(artikel1.ArtikelID);
            var retint = stub.retid;
            //assert
            Assert.AreEqual(retint, artikel1.ArtikelID);
            Assert.AreEqual(retdto.Aantal, artikel1.Aantal);
            Assert.AreEqual(retdto.Afmeting, artikel1.Afmeting);
            Assert.AreEqual(retdto.Artikelgroep.Naam, artikel1.artikelGroep.Naam);
            Assert.AreEqual(retdto.Artikelgroep.GroepId, artikel1.Aantal);
            Assert.AreEqual(retdto.ArtikelID, artikel1.ArtikelID);
            Assert.AreEqual(retdto.ArtikelNummer, artikel1.ArtikelNummer);
            Assert.AreEqual(retdto.Beschrijving, artikel1.Beschrijving);
            Assert.AreEqual(retdto.Gewicht, artikel1.Gewicht);
            Assert.AreEqual(retdto.IsVoedsel, artikel1.IsVoedsel);
            Assert.AreEqual(retdto.Kleur, artikel1.Kleur);
            Assert.AreEqual(retdto.Artikelnaam, artikel1.Naam);
            Assert.AreEqual(retdto.Prijs, artikel1.Prijs);
            Assert.AreEqual(retdto.THT, artikel1.Tht);
        }
        
    }
}
