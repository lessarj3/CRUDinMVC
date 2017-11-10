using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CathRepoCommon.Models;
using System.Linq;

namespace CathRepoTest
{
    [TestClass]
    public class MixRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = MixRepositoryFactory.Get();
            var mixes = repo.GetMixes();
            Assert.AreEqual(2, mixes.ToList().Count());
        }
    }
}
