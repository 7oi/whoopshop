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
        BJService test = new BJService();
        [TestMethod]
        public void TestAce()
        {
            Assert.AreEqual(test.IsAce(1), true); // is an Ace
            Assert.AreEqual(test.IsAce(14), true); // is an Ace
            Assert.AreEqual(test.IsAce(42), false); // is not an Ace
        }
    

    }
}
