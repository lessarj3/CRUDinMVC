using System;
using System.Net;
using System.Net.Http;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUDinMVC.Api;
using CathRepoCommon.Models;

namespace CathRepoTest
{
    [TestClass]
    public class MixControllerApiTests
    {
        [TestMethod]
        public void TestAddMix()
        {
            var controller = new MixesController();
            controller.Request = new HttpRequestMessage();
            var response = controller.Post(new Mix { Id = 1, MixName = "Mix 19999999999999999999999999999999999999999999", CFx = 12, SVO = 24, Carbon = 32, Binder = 23, Ratio = 23 });
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void TestAddNullMix()
        {
            var controller = new MixesController();
            controller.Request = new HttpRequestMessage();
            var response = controller.Post(null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
