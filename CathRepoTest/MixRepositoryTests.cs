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
        public void TestGettingMixes()
        {
            var repo = MixRepositoryFactory.Get();
            var mixes = repo.GetMixes();
            Assert.AreEqual(2, mixes.ToList().Count());
        }

        [TestMethod]
        public void TestAddingNewMix()
        {
            var repo = MixRepositoryFactory.Get();
            var mixes = repo.GetMixes();
            Assert.AreEqual(2, mixes.ToList().Count());
            repo.AddMix(new Mix { Id = 1, MixName = "Mix 1", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });
            Assert.AreEqual(3, mixes.ToList().Count());
        }
    }
}
