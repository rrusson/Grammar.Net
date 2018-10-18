using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using GrammarExtensions;

namespace GrammarExtensionsTests
{
    [TestClass]
    public class ToPluralTests
    {
        [TestMethod()]
        public void Leave_it_to_the_professionals_test()
        {
            var x = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            string mice = x.Pluralize("mouse");
            string potatoes = x.Pluralize("potato");
            Assert.AreEqual("mice", mice);
            Assert.AreEqual("potatoes", potatoes);
        }
        
        [TestMethod()]
        public void ToPlural_ConsonantEnding()
        {
            Assert.AreEqual("Tests", "Test".ToPlural());

            var x = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            string mice = x.Pluralize("mouse");
            Assert.AreEqual("mice", mice);
        }

        [TestMethod()]
        public void ToPlural_Greek()
        {
            Assert.AreEqual("Criteria", "Criterion".ToPlural());
            Assert.AreEqual("phenomena", "phenomenon".ToPlural());
        }

        //[TestMethod()]
        //public void ToPlural_Italian()
        //{
        //    Assert.AreEqual("virtuoso", "virtuosi".ToPlural());
        //    Assert.AreEqual("virtuoso", "virtuosos".ToPlural());        //or this?
        //}

        [TestMethod()]
        public void ToPlural_Latin()
        {
            Assert.AreEqual("Alumnae", "Alumna".ToPlural());
            Assert.AreEqual("Alumni", "Alumnus".ToPlural());
            Assert.AreEqual("indices", "index".ToPlural());

            Assert.AreEqual("matrices", "matrix".ToPlural());
            Assert.AreEqual("stimuli", "stimulus".ToPlural());
        }

        [TestMethod()]
        public void ToPlural_OddsAndEnds()
        {
            Assert.AreEqual("Lunches", "Lunch".ToPlural());
            Assert.AreEqual("foxes", "fox".ToPlural());
            Assert.AreEqual("heroes", "hero".ToPlural());
            Assert.AreEqual("Torpedoes", "Torpedo".ToPlural());
        }

        [TestMethod()]
        public void ReplaceEnd_Test()
        {
            string testString = "testString";
            Assert.AreEqual("testStrTEST", Grammar.ReplaceEnd(testString, 3, "TEST"));
        }
    }
}
