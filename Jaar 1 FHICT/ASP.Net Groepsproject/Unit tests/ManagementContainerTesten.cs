using LogicaLaag.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_tests_.ManagementTestOnderdelen;

namespace Unit_tests_
{
    [TestClass]
    public class ManagementContainerTesten
    {
        [TestMethod]
        public void SelecteerAccountListTest()
        {
            //arrange
            ManagementStub stub = new ManagementStub();
            ManagementContainer managementContainer = new ManagementContainer(stub);

            //act
            var Result = managementContainer.SelecteerAccounts();

            //assert
            Assert.AreEqual(1, Result[0].id);
            Assert.AreEqual(4, Result[0].PriorityLevel);
            Assert.AreEqual("1234", Result[0].Password);
            Assert.AreEqual("Test", Result[0].Email);
        }

        [TestMethod]
        public void AccountWijzigenTest()
        {
            //arrange
            int id = 1;
            string email = "Test";
            int prioritylevel = 4;
            string password = "1234";
            Management management = new Management(id, email, password, prioritylevel);
            ManagementStub stub = new ManagementStub();
            ManagementContainer managementContainer = new ManagementContainer(stub);
            stub.RetVal = true;

            //act
            var Result = managementContainer.AccountWijzigen(management);

            //assert
            Assert.IsTrue(Result);
            Assert.AreEqual(id, stub.LastAccount.id);
            Assert.AreEqual(password, stub.LastAccount.Password);
            Assert.AreEqual(prioritylevel, stub.LastAccount.PriorityLevel);
            Assert.AreEqual(email, stub.LastAccount.Email);
        }

        [TestMethod]
        public void VerwijderAccountTest()
        {
            //arrange
            int id = 1;
            string email = "Test";
            int prioritylevel = 4;
            string password = "1234";
            Management management = new Management(id, email, password, prioritylevel);
            ManagementStub stub = new ManagementStub();
            ManagementContainer managementContainer = new ManagementContainer(stub);
            stub.RetVal = true;

            //act
            managementContainer.VerwijderAccount(management);

            //assert
            Assert.AreEqual(id, stub.LastAccount.id);
            Assert.AreEqual(password, stub.LastAccount.Password);
            Assert.AreEqual(prioritylevel, stub.LastAccount.PriorityLevel);
            Assert.AreEqual(email, stub.LastAccount.Email);
        }
    }
}
