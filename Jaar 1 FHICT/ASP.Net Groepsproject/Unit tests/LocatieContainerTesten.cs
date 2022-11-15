using LogicaLaag;
using LogicaLaag.AlleLocaties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_tests_.LocatieTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class LocatieContainerTesten
    {
        [TestMethod]
        public void sorteerLocatieLijstOpRuimteTest()
        {
            //arrange
            LocatieContainer container = new LocatieContainer(new LocatieSTUB());
            List<Locatie> locaties = new List<Locatie>();
            List<Locatie> sortedLocaties = new List<Locatie>();
            Locatie locatie1 = new Locatie() { AantalInLocatie = 1 };
            Locatie locatie5 = new Locatie() { AantalInLocatie = 5 };
            Locatie locatie12 = new Locatie() { AantalInLocatie = 12 };

            //act
            locaties.Add(locatie1);
            locaties.Add(locatie12);
            locaties.Add(locatie1);
            locaties.Add(locatie5);
            locaties.Add(locatie1);
            locaties.Add(locatie5);
            sortedLocaties = container.SorteerLocatieLijstOpRuimte(locaties);

            //assert
            Assert.AreEqual(12, sortedLocaties[0].AantalInLocatie);
            Assert.AreEqual(5, sortedLocaties[1].AantalInLocatie);
            Assert.AreEqual(5, sortedLocaties[2].AantalInLocatie);
            Assert.AreEqual(1, sortedLocaties[3].AantalInLocatie);
            Assert.AreEqual(1, sortedLocaties[4].AantalInLocatie);
            Assert.AreEqual(1, sortedLocaties[5].AantalInLocatie);
        }

        [TestMethod]
        public void VerdeelArtikelTest()
        {
            //arrange
            int testArtikelId = 3;
            LocatieContainer container = new LocatieContainer(new LocatieSTUB());
            Artikel Artikel9 = new Artikel("skateboard", 9, 0, testArtikelId, 22.32, "plank met wielen");
            Artikel Artikel200 = new Artikel("skateboard", 200, 0, testArtikelId, 22.32, "plank met wielen");
            Artikel Artikel400 = new Artikel("skateboard", 400, 0, testArtikelId, 22.32, "plank met wielen");
            List<Tuple<Locatie, int>> locaties1;
            List<Tuple<Locatie, int>> locaties2;
            List<Tuple<Locatie, int>> locaties3;


            //act
            locaties1 = container.VerdeelArtikel(Artikel9);
            locaties2 = container.VerdeelArtikel(Artikel200);
            locaties3 = container.VerdeelArtikel(Artikel400);


            //assert
            Assert.AreEqual(1, locaties1.Count);
            Assert.AreEqual(6, locaties2.Count);
            Assert.AreEqual(11, locaties3.Count);

            Assert.AreEqual(9, locaties1[0].Item2);

            Assert.AreEqual(31, locaties2[0].Item2);
            Assert.AreEqual(32, locaties2[1].Item2);
            Assert.AreEqual(33, locaties2[2].Item2);
            Assert.AreEqual(34, locaties2[3].Item2);
            Assert.AreEqual(35, locaties2[4].Item2);
            Assert.AreEqual(35, locaties2[5].Item2);

            Assert.AreEqual(31, locaties3[0].Item2);
            Assert.AreEqual(32, locaties3[1].Item2);
            Assert.AreEqual(33, locaties3[2].Item2);
            Assert.AreEqual(34, locaties3[3].Item2);
            Assert.AreEqual(35, locaties3[4].Item2);
            Assert.AreEqual(36, locaties3[5].Item2);
            Assert.AreEqual(37, locaties3[6].Item2);
            Assert.AreEqual(38, locaties3[7].Item2);
            Assert.AreEqual(39, locaties3[8].Item2);
            Assert.AreEqual(40, locaties3[9].Item2);
            Assert.AreEqual(45, locaties3[10].Item2);
        }
    }
}
