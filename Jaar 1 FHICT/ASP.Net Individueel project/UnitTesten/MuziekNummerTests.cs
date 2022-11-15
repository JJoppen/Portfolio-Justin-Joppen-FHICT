using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Layer;
using Logic_layer;
using Inter.Layer;
using System.Collections.Generic;
namespace UnitTesten
{
    [TestClass]
    public class MuziekNummerTests
    {
        public Muzieknummer nummer = new Muzieknummer("Layla", "Clapton", "Lead", "XXX23X", 1);
        public MuziekNummerDALStub stub = new MuziekNummerDALStub();
        public MuziekNummerDTO NummerDTO1 = new MuziekNummerDTO
        {
            Naam = "Sound of Silence",
            Beschrijving = "meme nummer",
            Type = "Rythm",
            Tab = "XX553X",
            NummerID = 2
        };
        public MuziekNummerDTO NummerDTO2 = new MuziekNummerDTO
        {
            Naam = "layla",
            Beschrijving = "Eric clapton unplugged version",
            NummerID = 1,
            UserID = 1,
            Tab = "X1X33X",
            Type = "Lead",
        };
        MuziekNummerDTO NummerDTO3 = new MuziekNummerDTO
        {
            Naam = "Sweet child of mine",
            Beschrijving = "Guns and Roses",
            NummerID = 2,
            UserID = 2,
            Tab = "X123",
            Type = "Lead",
        };
        

        [TestMethod]
        public void TestInsertNummerTrue()
        {
            //arrange
            stub.retbool = true;
            var MuziekNummerContainer = new MuziekNummerContainer(stub);
            MuziekNummerDTO dto;
            //act
            var InsertResult = MuziekNummerContainer.InsertNummer(nummer);
            dto = stub.retdto;
            //assert
            Assert.AreEqual(nummer.Beschrijving, dto.Beschrijving);
            Assert.AreEqual(nummer.Naam, dto.Naam);
            Assert.AreEqual(nummer.Tab, dto.Tab);
            Assert.AreEqual(nummer.Type, dto.Type);
            Assert.AreEqual(nummer.userID, dto.UserID);
            Assert.IsTrue(InsertResult);
        }

        [TestMethod]
        public void TestInsertNummerFalse()
        {
            //Arrange

            stub.retbool = false;
            var MuziekNummerContainer = new MuziekNummerContainer(stub);
            MuziekNummerDTO dto;
            //act

            var InsertResult = MuziekNummerContainer.InsertNummer(nummer);
            dto = stub.retdto;
            //assert
            Assert.AreEqual(nummer.Beschrijving, dto.Beschrijving);
            Assert.AreEqual(nummer.Naam, dto.Naam);
            Assert.AreEqual(nummer.Tab, dto.Tab);
            Assert.AreEqual(nummer.Type, dto.Type);
            Assert.AreEqual(nummer.userID, dto.UserID);
            Assert.IsFalse(InsertResult);
        }
        [TestMethod]
        public void TestListTrue()
        {
            //Arrange
            MuziekNummerDALStub stub = new MuziekNummerDALStub();

            var MuziekNummerContainer = new MuziekNummerContainer(stub);
            List<MuziekNummerDTO> muziekNummerDTOs = new List<MuziekNummerDTO>();
            muziekNummerDTOs.Add(NummerDTO1);
            muziekNummerDTOs.Add(NummerDTO2);
            muziekNummerDTOs.Add(NummerDTO3);
            stub.retlist = muziekNummerDTOs;


            //Act
            List<Muzieknummer> retlist = MuziekNummerContainer.Selectnummers();

            //Assert
            for (int i = 0; i < muziekNummerDTOs.Count; i++)
            {
                Assert.AreEqual(retlist[i].Naam, muziekNummerDTOs[i].Naam);
                Assert.AreEqual(retlist[i].Beschrijving, muziekNummerDTOs[i].Beschrijving);
                Assert.AreEqual(retlist[i].MuziekNummerID, muziekNummerDTOs[i].NummerID);
                Assert.AreEqual(retlist[i].userID, muziekNummerDTOs[i].UserID);
                Assert.AreEqual(retlist[i].Tab, muziekNummerDTOs[i].Tab);
                Assert.AreEqual(retlist[i].Type, muziekNummerDTOs[i].Type);
            }
        }
        [TestMethod]
        public void TestUpdateTrue()
        {
            //arrange
            stub.retbool = true;
            var Container = new MuziekNummerContainer(stub);
            //act
            var UpdateResult = Container.UpdateNummer(nummer);
            MuziekNummerDTO dto = stub.retdto;
            Assert.AreEqual(nummer.Beschrijving, dto.Beschrijving);
            Assert.AreEqual(nummer.Naam, dto.Naam);
            Assert.AreEqual(nummer.Tab, dto.Tab);
            Assert.AreEqual(nummer.Type, dto.Type);
            Assert.AreEqual(nummer.userID, dto.UserID);
            Assert.IsTrue(UpdateResult);
        }
        [TestMethod]
        public void TestUpdateFalse()
        {
            //arrange
            stub.retbool = false;
            var Container = new MuziekNummerContainer(stub);
            //act
            var UpdateResult = Container.UpdateNummer(nummer);
            MuziekNummerDTO dto = stub.retdto;
            Assert.AreEqual(nummer.Beschrijving, dto.Beschrijving);
            Assert.AreEqual(nummer.Naam, dto.Naam);
            Assert.AreEqual(nummer.Tab, dto.Tab);
            Assert.AreEqual(nummer.Type, dto.Type);
            Assert.AreEqual(nummer.userID, dto.UserID);
            Assert.IsFalse(UpdateResult);
        }
        [TestMethod]
        public void TestSelect()
        {
            //Arrange
            stub.retdto = NummerDTO1;
            int SendID = 2;
            var Container = new MuziekNummerContainer(stub);
            //act
            Muzieknummer nummer = Container.SelectNummer(SendID);
            var retid = stub.retid;
            //Assert
            Assert.AreEqual(nummer.Beschrijving, NummerDTO1.Beschrijving);
            Assert.AreEqual(nummer.Naam, NummerDTO1.Naam);
            Assert.AreEqual(nummer.Tab, NummerDTO1.Tab);
            Assert.AreEqual(nummer.Type, NummerDTO1.Type);
            Assert.AreEqual(nummer.userID, NummerDTO1.UserID);
            Assert.AreEqual(retid, SendID);

        }
        [TestMethod]
        public void TestSelectQuery()
        {
            //Arrange
            MuziekNummerDALStub stub = new MuziekNummerDALStub();
            var container = new MuziekNummerContainer(stub);
            List<MuziekNummerDTO> muziekNummerDTOs = new List<MuziekNummerDTO>();
            muziekNummerDTOs.Add(NummerDTO1);
            muziekNummerDTOs.Add(NummerDTO2);
            muziekNummerDTOs.Add(NummerDTO3);

            string query = "query";
            stub.retlist = muziekNummerDTOs;
            stub.retstring = query;

            //act
            List<Muzieknummer> retlist = container.SelectNummersWithQuery(query);
            var retstring = stub.retstring;
            //Assert
            Assert.AreEqual(retstring, query);
            for (int i = 0; i < muziekNummerDTOs.Count; i++)
            {
                Assert.AreEqual(retlist[i].Naam, muziekNummerDTOs[i].Naam);
                Assert.AreEqual(retlist[i].Beschrijving, muziekNummerDTOs[i].Beschrijving);
                Assert.AreEqual(retlist[i].MuziekNummerID, muziekNummerDTOs[i].NummerID);
                Assert.AreEqual(retlist[i].userID, muziekNummerDTOs[i].UserID);
                Assert.AreEqual(retlist[i].Tab, muziekNummerDTOs[i].Tab);
                Assert.AreEqual(retlist[i].Type, muziekNummerDTOs[i].Type);
            }
        }
    }


}
