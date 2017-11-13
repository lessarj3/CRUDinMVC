using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CathRepoCommon.Models;
using System.Linq;

namespace CathRepoTest
{
    [TestClass]
    public class MixRepositoryTests
    {
        private IMixRepository repo;

        [TestMethod]
        public void TestGettingMixes()
        {
            SetUpRepo();
            var mixes = repo.GetMixes();
            Assert.AreEqual(6, mixes.ToList().Count());
            CleanUpRepo();
        }

        [TestMethod]
        public void TestAddingNewMix()
        {
            SetUpRepo();
            var mixes = repo.GetMixes();
            Assert.AreEqual(6, mixes.ToList().Count());
            repo.AddMix(new Mix { Id = 1, MixName = "Mix 1", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });
            Assert.AreEqual(7, mixes.ToList().Count());
            CleanUpRepo();
        }

        private void SetUpRepo()
        {
            repo = MixRepositoryFactory.Get();
            repo.AddMix(new Mix { MixName = "Mix 1", CFx = 90, Id = 1, Ratio = 1, SVO = 10 });
            repo.AddMix(new Mix { MixName = "Mix 2", CFx = 80, Id = 2, Ratio = 1, SVO = 20 });
            repo.AddMix(new Mix { MixName = "Mix 3", CFx = 70, Id = 3, Ratio = 1, SVO = 30 });
            repo.AddMix(new Mix { MixName = "Mix 4", CFx = 60, Id = 4, Ratio = 1, SVO = 40 });
            repo.AddMix(new Mix { MixName = "Mix 5", CFx = 50, Id = 5, Ratio = 1, SVO = 50 });
            repo.AddMix(new Mix { MixName = "Mix 6", CFx = 40, Id = 6, Ratio = 1, SVO = 60 });
        }

        private void CleanUpRepo()
        {
            var mixes = repo.GetMixes().ToList();
            foreach (Mix mix in mixes)
                repo.DeleteMix(mix.Id);
        }
    }
}
