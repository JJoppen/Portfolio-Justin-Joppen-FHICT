using LogicaLaag.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_tests_.AccountTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class AccountContainerTesten
    {
        [TestMethod]
        public void SuccesFullLoginAccount()
        {
            //arrange
            string Email = "Test";
            string Password = "1234";

            AccountStub stub = new AccountStub();
            GebruikerContainer Gebruikercontainer = new GebruikerContainer(stub);
            Gebruiker gebruiker = new Gebruiker(Email, Password);

            //act
            var Result = Gebruikercontainer.LoginGebruiker(gebruiker);

            //assert
            Assert.AreEqual(1, Result);
            Assert.AreEqual(Email, stub.LastAccount.Email);
            Assert.AreEqual(Password, stub.LastAccount.Password);
        }

        [TestMethod]
        public void GetPriorityLevelTest()
        {
            //arrange
            int id = 1;

            AccountStub stub = new AccountStub();
            GebruikerContainer Gebruikercontainer = new GebruikerContainer(stub);

            //act
            var Result = Gebruikercontainer.GetGebruikerPriorityLevel(id);

            //assert
            Assert.AreEqual(4, Result);
            Assert.AreEqual(id, stub.LastAccount.ID);
        }
    }
}
