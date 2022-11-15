using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Layer;
using Logic_layer;
using Inter.Layer;
using System.Collections.Generic;

namespace UnitTesten
{
    [TestClass]
    public class UserTests
    {
        public static UserDTO userDTO = new UserDTO
        {
            email = "Test@Test.nl",
            gebruikersnaam = "Tester",
            wachtwoord = "Testen",
            userID = 1
        };
        public static User user = new User(userDTO);
        public UserStub stub = new UserStub();
        [TestMethod]
        public void TestLoginTrue()
        {
            //Arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);
            //Act
            var RetBool = container.loginUser(user);
            UserDTO retDTO = stub.RetDTO;
            //Assert
            Assert.AreEqual(retDTO.email, user.email);
            Assert.AreEqual(retDTO.wachtwoord, user.wachtwoord);
            Assert.AreEqual(retDTO.gebruikersnaam, user.gebruikersnaam);
            Assert.AreEqual(retDTO.userID, user.userID);
            Assert.IsTrue(RetBool);
        }
        [TestMethod]
        public void TestLoginFalse()
        {
            //Arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);
            //Act
            var RetBool = container.loginUser(user);
            UserDTO retDTO = stub.RetDTO;
            //Assert
            Assert.AreEqual(retDTO.email, user.email);
            Assert.AreEqual(retDTO.wachtwoord, user.wachtwoord);
            Assert.AreEqual(retDTO.gebruikersnaam, user.gebruikersnaam);
            Assert.AreEqual(retDTO.userID, user.userID);
            Assert.IsTrue(RetBool);
        }
        [TestMethod]
        public void TestAccountDetails()
        {
            //arrange
            stub.RetDTO = userDTO;
            UserContainer container = new UserContainer(stub);
            int userID = 1;
            //act
            User retuser = container.UserDetails(userID);
            int retID = stub.RetID;
            //Assert
            Assert.AreEqual(retID, userID);
            Assert.AreEqual(retuser.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retuser.email, userDTO.email);
            Assert.AreEqual(retuser.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retuser.userID, userDTO.userID);

        }
        [TestMethod]
        public void TestCompareNewEmailTrue()
        {
            //arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewEmail(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareNewEmailFalse()
        {
            //arrange
            stub.RetBool = false;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewEmail(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareEmailUpdateTrue()
        {
            //arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewEmailUpdate(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        public void TestCompareEmailUpdateFalse()
        {
            //arrange
            stub.RetBool = false;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewEmail(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareNewGebruikersNaamTrue()
        {
            //arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewUsername(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareNewGebruikersNaamFalse()
        {
            //arrange
            stub.RetBool = false;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewUsername(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareGebruikersNaamUpdateTrue()
        {
            //arrange
            stub.RetBool = true;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewUsernameUpdate(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestCompareGebruikersNaamUpdateFalse()
        {
            //arrange
            stub.RetBool = false;
            UserContainer container = new UserContainer(stub);

            //act
            bool retbool = container.CompareNewUsernameUpdate(user);
            var retdto = stub.RetDTO;
            //arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestInsertTrue()
        {
            //Arrange
            stub.RetBool = true;
            //Act
            bool retbool = user.InsertUser( stub);
            var retdto = stub.RetDTO;
            //Arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestInsertFalse()
        {
            //Arrange
            stub.RetBool = false;
            //Act
            bool retbool = user.InsertUser( stub);
            var retdto = stub.RetDTO;
            //Arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestUpdateTrue()
        {
            //Arrange
            stub.RetBool = true;
            //Act
            bool retbool = user.UpdateUser( stub);
            var retdto = stub.RetDTO;
            //Arrange
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestUpdateFalse()
        {
            //Arrange
            stub.RetBool = false;
            //Act
            bool retbool = user.InsertUser(stub);
            var retdto = stub.RetDTO;
            //Arrange
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.gebruikersnaam, userDTO.gebruikersnaam);
            Assert.AreEqual(retdto.email, userDTO.email);
            Assert.AreEqual(retdto.wachtwoord, userDTO.wachtwoord);
            Assert.AreEqual(retdto.userID, userDTO.userID);
        }
        [TestMethod]
        public void TestSelectUserID()
        {
            //Arrange
            stub.RetID = user.userID;
            UserContainer container = new UserContainer(stub);
            //act
            int retint = container.SelectUserID(user);
            var retdto = stub.RetDTO;
            //assert
            Assert.AreEqual(retint, user.userID);
            Assert.AreEqual(retdto.gebruikersnaam, user.gebruikersnaam);
            Assert.AreEqual(retdto.email, user.email);
            Assert.AreEqual(retdto.wachtwoord, user.wachtwoord);
            Assert.AreEqual(retdto.userID, user.userID);
        }
    }
}
