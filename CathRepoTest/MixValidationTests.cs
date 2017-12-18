using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CathRepoCommon.Models;
using System.Linq;

namespace CathRepoTest
{
    [TestClass]
    public class MixValidationTests
    {
        [TestMethod]
        public void TestMixNameTooLong()
        {
            var mix = new Mix();
            mix.MixName = "Mix8aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            mix.Ratio = 1;
            var results = ValidateModel(mix);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(results[0].ErrorMessage, "Mix Name too long");
        }

        private List<ValidationResult> ValidateModel<T>(T model)
        {
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(model, context, result, true);
            return result;
        }
    }
}
