using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circus;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class Tests
    {
        public Dier TestDierGrootVlees1 = new Dier(true, "Leeuw", Grootte.groot);

        public Dier TestDierMiddelGrootVlees1 = new Dier(true, "Wolf", Grootte.groot);
        public Dier TestDierMiddelGrootVlees2 = new Dier(true, "Hyena", Grootte.groot);
        public Dier TestDierMiddelGrootVlees3 = new Dier(true, "Poema", Grootte.groot);


        public Dier TestDierKleinVlees1 = new Dier(true, "havik", Grootte.groot);
        public Dier TestDierKleinVlees2 = new Dier(true, "Slang", Grootte.groot);
        public Dier TestDierKleinVlees3 = new Dier(true, "Kikker", Grootte.groot);


        public Dier TestDierKleinHerbivoor1 = new Dier(false, "Konijn", Grootte.klein);
        public Dier TestDierKleinHerbivoor2 = new Dier(false, "Muis", Grootte.klein);
        public Dier TestDierKleinHerbivoor3 = new Dier(false, "Rat", Grootte.klein);

        public Dier TestDierMiddelGrootHerbivoor1 = new Dier(false, "paard", Grootte.middelgroot);
        public Dier TestDierMiddelGrootHerbivoor2 = new Dier(false, "aap", Grootte.middelgroot);
        public Dier TestDierMiddelGrootHerbivoor3 = new Dier(false, "Koe", Grootte.middelgroot);

        public Dier TestDierGrootHerbivoor1 = new Dier(false, "Olifant", Grootte.middelgroot);
        public Dier TestDierGrootHerbivoor2 = new Dier(false, "Neushoorn", Grootte.middelgroot);
        public Dier TestDierGrootHerbivoor3 = new Dier(false, "Nijlpaard", Grootte.middelgroot);



        //DierTests
        [TestMethod]
        public void TestMagDierErbijTrue()
        {
            Assert.IsTrue(TestDierKleinHerbivoor1.MagDierErbij(TestDierMiddelGrootHerbivoor1));
        }
        [TestMethod]
        public void TestMagDierErbijFalse()
        {
            Assert.IsFalse(TestDierGrootVlees1.MagDierErbij(TestDierKleinHerbivoor1));
        }


        //WagonTests
        [TestMethod]
        public void TestVoegToeTrue()
        {
            Wagon TestWagon = new Wagon();
            TestWagon.dieren.Add(TestDierKleinHerbivoor1);
            Assert.IsTrue(TestWagon.VoegToeAlsDierErbijKan(TestDierMiddelGrootHerbivoor1));
            Assert.AreEqual(TestWagon.dieren[1].naam, TestDierMiddelGrootHerbivoor1.naam);
            Assert.AreEqual(TestWagon.dieren[1].grootte, TestDierMiddelGrootHerbivoor1.grootte);
            Assert.AreEqual(TestWagon.dieren[1].Vleeseter, TestDierMiddelGrootHerbivoor1.Vleeseter);
        }
        [TestMethod]
        public void TestVoegToeFalse()
        {
            Wagon TestWagon = new Wagon();
            TestWagon.dieren.Add(TestDierKleinHerbivoor1);
            Assert.IsFalse(TestWagon.VoegToeAlsDierErbijKan(TestDierGrootVlees1));
        }

        //Test volledige functies.
        [TestMethod]
        public void TestToevoeging()
        {
            //arrange
            List<Dier> dieren = new List<Dier>{ 
                TestDierGrootVlees1,

                TestDierMiddelGrootVlees1,
                TestDierMiddelGrootVlees2,
                TestDierMiddelGrootVlees3,

                TestDierKleinVlees1,
                TestDierKleinVlees2,
                TestDierKleinVlees3,

                TestDierKleinHerbivoor1,
                TestDierKleinHerbivoor2,
                TestDierKleinHerbivoor3,

                TestDierMiddelGrootHerbivoor1,
                TestDierMiddelGrootHerbivoor2,
                TestDierMiddelGrootHerbivoor3,

                TestDierGrootHerbivoor1,
                TestDierGrootHerbivoor2,
                TestDierGrootHerbivoor3,
            };

            Trein trein = new Trein(dieren);
            //act
            trein.VoegToeAanWagons();
            //assert
            var ZittenAlleDierenInTreinList = ZittenAlleDierenInTrein(dieren, trein);

            for (int i = 0; i<ZittenAlleDierenInTreinList.Count;i++)
            {
                Assert.IsTrue(ZittenAlleDierenInTreinList[i]);
            }
            List<Dier> Treindieren = new List<Dier>();
            foreach(Wagon wagon in trein.wagons)
            {
                foreach(Dier dier in wagon.dieren)
                {
                    Treindieren.Add(dier);
                }
            }
            var ZittenAlleTreinDierenInDierenList = ZittenAlleTreinDierenInDieren(Treindieren, dieren);
            for(int i = 0;i<ZittenAlleTreinDierenInDierenList.Count;i++)
            {
                Assert.IsTrue(ZittenAlleTreinDierenInDierenList[i]);
            }
            var ZijnWagonsCorrectList = ZijnWagonsCorrect(trein);
            for(int i=0;i<ZijnWagonsCorrectList.Count;i++)
            {
                Assert.IsTrue(ZijnWagonsCorrectList[i]);
            }
        }

        public List<bool> ZittenAlleDierenInTrein(List<Dier>dieren,Trein trein)
        {
            List<bool> boollist = new List<bool>();
            foreach (Dier dier in dieren)
            {
                bool komtovereen = false;
                for (int i = 0; i < trein.wagons.Count; i++)
                {
                    for (int j = 0; j < trein.wagons[i].dieren.Count; j++)
                    {
                        if (trein.wagons[i].dieren[j] == dier)
                        {
                            komtovereen = true;
                        }
                    }
                }
                boollist.Add(komtovereen);
            }
            return boollist;
        }

        public List<bool> ZijnWagonsCorrect(Trein trein)
        {
            List<bool> BoolList = new List<bool>();
            foreach (Wagon wagon in trein.wagons)
            {
                bool IsCorrect = true;
                if (wagon.punten > 10)
                {
                    IsCorrect = false;
                }
                else
                {
                    bool eenvleeseter = false;
                    Grootte grootte = Grootte.klein;
                    bool tweevleeseters = false;
                    foreach (Dier dier in wagon.dieren)
                    {
                        if (eenvleeseter == false)
                        {
                            if (dier.Vleeseter)
                            {
                                eenvleeseter = true;
                                grootte = dier.grootte;
                            }
                            else if (eenvleeseter == true)
                            {
                                if (dier.Vleeseter)
                                {
                                    tweevleeseters = true;
                                }
                                else if (grootte >= dier.grootte)
                                {
                                    IsCorrect = false;
                                }
                            }
                            else if (eenvleeseter == true && tweevleeseters == true)
                            {
                                IsCorrect = false;
                            }
                        }
                    }
                }
                BoolList.Add(IsCorrect);
                
            }
            return BoolList;
        }
        public List<bool> ZittenAlleTreinDierenInDieren(List<Dier> TreinDieren,List<Dier>dieren)
        {
            List<bool> boollist = new List<bool>();
            foreach(Dier dier in TreinDieren)
            {
                bool komtovereen = false;
                for(int i = 0; i<dieren.Count;i++)
                {
                    if(dieren[i] == dier)
                    {
                        komtovereen = true;
                    }
                }
                boollist.Add(komtovereen);
            }
            return boollist;
        }
    }
}
