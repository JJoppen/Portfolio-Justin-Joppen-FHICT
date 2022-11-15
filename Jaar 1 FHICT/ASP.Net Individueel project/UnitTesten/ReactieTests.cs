using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Layer;
using Logic_layer;
using Inter.Layer;
using System.Collections.Generic;
using System;

namespace UnitTesten
{
    [TestClass]
    public class ReactieTests
    {
        public static UserDTO userDTO = new UserDTO
        {
            email = "Test@Test.nl",
            gebruikersnaam = "Test",
            wachtwoord = "Test",
            userID = 1
        };
        public static UserDTO userDTO2 = new UserDTO
        {
            gebruikersnaam = "peer",
            userID = 2
        };
        public static DateTime dateTime = new DateTime(2012, 12, 24);
        public static ReactieDTO reactieDTO = new ReactieDTO
        {
            Comment = "Appel",
            NummerID = 1,
            userDTO = userDTO,
            ReactieID = 1,
            PlaatsTijd = dateTime

        };
        public static ReactieDTO reactieDTO2 = new ReactieDTO
        {
            Comment = "Peer",
            NummerID = 2,
            userDTO = userDTO2,
            ReactieID = 2,
            PlaatsTijd = dateTime
        };
        public static List<ReactieDTO> reactieDTOs = new List<ReactieDTO>
        {
            reactieDTO,
            reactieDTO2
        };

        public static ReactieStub stub = new ReactieStub();
        public  static ReactieContainer container = new ReactieContainer(stub);
        [TestMethod]
        public void TestInsertReactieTrue()
        {
            //arrange
            stub.retbool = true;
            Reactie reactie = new Reactie(reactieDTO);
            //act
            var retbool = reactie.InsertReactie(stub);
            ReactieDTO dto = stub.retdto;
            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(reactie.NummerID, dto.NummerID);
            Assert.AreEqual(reactie.user.gebruikersnaam, dto.userDTO.gebruikersnaam);
            Assert.AreEqual(reactie.user.userID, dto.userDTO.userID);
            Assert.AreEqual(reactie.Comment, dto.Comment);
            Assert.AreEqual(reactie.PlaatsTijd, dto.PlaatsTijd);
            Assert.AreEqual(reactie.ReactieID, dto.ReactieID);

        }
        [TestMethod]
        public void TestInsertReactieFalse()
        {
            //arrange
            stub.retbool = false;
            Reactie reactie = new Reactie(reactieDTO);
            //act
            var retbool = reactie.InsertReactie(stub);
            ReactieDTO dto = stub.retdto;
            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(reactie.NummerID, dto.NummerID);
            Assert.AreEqual(reactie.user.gebruikersnaam, dto.userDTO.gebruikersnaam);
            Assert.AreEqual(reactie.user.userID, dto.userDTO.userID);
            Assert.AreEqual(reactie.Comment, dto.Comment);
            Assert.AreEqual(reactie.PlaatsTijd, dto.PlaatsTijd);
            Assert.AreEqual(reactie.ReactieID, dto.ReactieID);
        }
        [TestMethod]
        public void TestUpdateReactieTrue()
        {
            //arrange
            stub.retbool = true;
            Reactie reactie = new Reactie(reactieDTO);
            //act
            var retbool = reactie.UpdateReactie( stub);
            ReactieDTO dto = stub.retdto;
            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(reactie.NummerID, dto.NummerID);
            Assert.AreEqual(reactie.user.gebruikersnaam, dto.userDTO.gebruikersnaam);
            Assert.AreEqual(reactie.user.userID, dto.userDTO.userID);
            Assert.AreEqual(reactie.Comment, dto.Comment);
            Assert.AreEqual(reactie.PlaatsTijd, dto.PlaatsTijd);
            Assert.AreEqual(reactie.ReactieID, dto.ReactieID);
        }
        [TestMethod]
        public void TestUpdateReactieFalse()
        {
            //arrange
            stub.retbool = false;
            Reactie reactie = new Reactie(reactieDTO);
            //act
            var retbool = reactie.UpdateReactie( stub);
            ReactieDTO dto = stub.retdto;
            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(reactie.NummerID, dto.NummerID);
            Assert.AreEqual(reactie.user.gebruikersnaam, dto.userDTO.gebruikersnaam);
            Assert.AreEqual(reactie.user.userID, dto.userDTO.userID);
            Assert.AreEqual(reactie.Comment, dto.Comment);
            Assert.AreEqual(reactie.PlaatsTijd, dto.PlaatsTijd);
            Assert.AreEqual(reactie.ReactieID, dto.ReactieID);
        }
        [TestMethod]
        public void TestSelectReactiesBijNummers()
        {
            //arrange
            stub.retbool = true;
            Reactie reactie = new Reactie(reactieDTO);
            Reactie reactie2 = new Reactie(reactieDTO2);
            List<Reactie> reacties = new List<Reactie>
            {
                reactie,
                reactie2
            };
            ReactieContainer container = new ReactieContainer(stub);
            stub.retlist = reactieDTOs;
            int testID = 1;
            //act
            var retlist = container.SelectCommentsVanNummer(testID);
            var retid = stub.retid;
            //assert
            Assert.AreEqual(retid, testID);
            for (int i = 0; i > retlist.Count; i++)
            {
                Assert.AreEqual(retlist[i].NummerID, reactieDTOs[i].NummerID);
                Assert.AreEqual(retlist[i].user.gebruikersnaam, reactieDTOs[i].userDTO.gebruikersnaam);
                Assert.AreEqual(retlist[i].user.userID, reactieDTOs[i].userDTO.userID);
                Assert.AreEqual(retlist[i].Comment, reactieDTOs[i].Comment);
                Assert.AreEqual(retlist[i].PlaatsTijd, reactieDTOs[i].PlaatsTijd);
                Assert.AreEqual(retlist[i].ReactieID, reactieDTOs[i].ReactieID);
            }
        }
        [TestMethod]
        public void TestDeleteTrue()
        {
            //arrange
            ReactieContainer container = new ReactieContainer(stub);
            int testint = 1;
            stub.retbool = true;
            //act
            var retbool = container.DeleteComment(testint);
            var retint = stub.retid;
            //assert
            Assert.AreEqual(retint, testint);
            Assert.IsTrue(retbool);
        }
        [TestMethod]
        public void TestDeleteFalse()
        {
            //arrange
            ReactieContainer container = new ReactieContainer(stub);
            int testint = 1;
            stub.retbool = false;
            //act
            var retbool = container.DeleteComment(testint);
            var retint = stub.retid;
            //assert
            Assert.AreEqual(retint, testint);
            Assert.IsFalse(retbool);
        }
    }
}
