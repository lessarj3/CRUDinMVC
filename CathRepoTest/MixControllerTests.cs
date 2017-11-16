using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUDinMVC.Controllers;
using CathRepoCommon.Models;

namespace CathRepoTest
{
    [TestClass]
    public class MixControllerTests
    {
        [TestMethod]
        public void TestAddingMix()
        {
            var mixController = new MixController();
            ActionResult  result = mixController.Create(new Mix { MixName = "Mix Name", CFx = 90, Id = 1, Ratio = 1, SVO = 10 });
        }
    }
}
