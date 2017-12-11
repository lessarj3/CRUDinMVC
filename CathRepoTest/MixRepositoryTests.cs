using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CathRepoCommon.Models;
using System.Linq;

namespace CathRepoTest
{
    [TestClass]
    public class MixRepositoryTests
    {
        private IMixRepository  repo;
        //In memory only test
        //[TestMethod]
        public void TestGettingMixes()
        {
            SetUpRepo();
   
            var mixes = repo.GetMixes();
            Assert.AreEqual(6, mixes.ToList().Count());
            CleanUpRepo();
        }

        //In memory only test
        //[TestMethod]
        public void TestAddingNewMix()
        {
            SetUpRepo();
            Assert.AreEqual(6, repo.GetMixes().ToList().Count());
            repo.AddMix(new Mix { MixName = "Mix 1", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });
            Assert.AreEqual(7, repo.GetMixes().ToList().Count());
            CleanUpRepo();
        }

        //General test
        //[TestMethod]
        public void TestAddingMixWithPellets()
        {
            repo = MixRepositoryFactory.Get();
            var mix = new Mix() {MixName = "Mix 1", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23};
    
            var pellet1 = new Pellet(1.000, 16.015, 2.350, 25);
            var pellet2 = new Pellet(2.000, 17.015, 2.450, 30);
            var pellet3 = new Pellet(3.000, 18.015, 2.550, 35);
            //var pellet4 = new Pellet() {Diameter= 1, Mass = 2, Resistance = 2};
            
            mix.Pellets.Add(pellet1);
            mix.Pellets.Add(pellet2);
            mix.Pellets.Add(pellet3);

            repo.AddMix(mix);
        }

        //In memory 6 mix set up
        private void SetUpRepo()
        {
            try
            {
                repo = MixRepositoryFactory.Get();
                repo.AddMix(new Mix { MixName = "Mix 1", CFx = 90,  Ratio = 1, SVO = 10 });
                repo.AddMix(new Mix { MixName = "Mix 2", CFx = 80,  Ratio = 1, SVO = 20 });
                repo.AddMix(new Mix { MixName = "Mix 3", CFx = 70,  Ratio = 1, SVO = 30 });
                repo.AddMix(new Mix { MixName = "Mix 4", CFx = 60,  Ratio = 1, SVO = 40 });
                repo.AddMix(new Mix { MixName = "Mix 5", CFx = 50,  Ratio = 1, SVO = 50 });
                repo.AddMix(new Mix { MixName = "Mix 6", CFx = 40,  Ratio = 1, SVO = 60 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CleanUpRepo()
        {
            var mixes = repo.GetMixes().ToList();
            foreach (Mix mix in mixes)
                repo.DeleteMix(mix.Id);
        }
    }
}
