using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bordspil;
using Bordspil.GameService;

namespace Bordspil.Tests.GameService.BlackJack
{
    [TestClass]
    public class BJServiceTest
    {
        BJService bjTest = new BJService();

        List<int> testList1 = new List<int> { 1, 14, 27, 40 }; // 4 Ace
        List<int> testList2 = new List<int> { 1, 10, 26 };  // ace, 10, K
        List<int> testList3 = new List<int> { 10, 51, 43 };  // 10 , Q and 4

        [TestMethod]
        public void TestAce()
        {
            Assert.AreEqual(bjTest.IsAce(1), true); // is an Ace
            Assert.AreEqual(bjTest.IsAce(14), true); // is an Ace
            Assert.AreEqual(bjTest.IsAce(42), false); // is not an Ace
        }

        [TestMethod]
        public void TestCalculateSum()
        {
            Assert.AreEqual(bjTest.CalculateSum(testList1), 14);
            Assert.AreEqual(bjTest.CalculateSum(testList2), 31); 
            Assert.AreEqual(bjTest.CalculateSum(testList3), 24); 
        }


    }
}
