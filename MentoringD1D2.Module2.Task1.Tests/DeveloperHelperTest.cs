using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MentoringD1D2.Module2.Task1.Attributes;
using MentoringD1D2.Module2.Task1.Helpers;

namespace MentoringD1D2.Module2.Task1.Tests
{
    [TestClass]
    public class DeveloperHelperTest
    {

        [TestMethod]
        public void GetDeveloperAttributesTest()
        {
            List<Developer> expected = new List<Developer>
            {
                new Developer {Name = "Katsiaryna Tsmyh", Email = "dede"},
                new Developer {Name = "Developer Name", Email = "email@gmail.com"},
                new Developer {Name = "Another Developer Name", Email = "email_1@gmail.com"}
            };
            var actual = DeveloperHelper.GetDeveloperAttributes(typeof(TestHelper))?.ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDeveloperAttributesEmptyResultTest()
        {
            List<Developer> expected = new List<Developer>();
            var actual = DeveloperHelper.GetDeveloperAttributes(typeof(TestCustomType))?.ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDeveloperAttributesNullResultTest()
        {
            var actual = DeveloperHelper.GetDeveloperAttributes(null)?.ToList();
            Assert.AreEqual(null, actual);
        }
    }
}
