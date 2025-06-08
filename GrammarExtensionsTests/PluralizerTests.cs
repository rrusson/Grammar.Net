using GrammarExtensions;

namespace GrammarExtensionsTests
{
    [TestClass]
    public class PluralizerTests
    {
        public void Leave_it_to_the_professionals_test()
        {
			// The Humanizer library does this really well. Just use that.
        }
        
        [TestMethod]
        public void ToPlural_ConsonantEnding()
        {
			Assert.AreEqual("Tests", "Test".ToPlural());
			Assert.AreEqual("tests", "test".ToPlural());
			//Assert.AreEqual("mice", "mouse".ToPlural());  //TODO: Handle this case
			Assert.AreEqual("potatoes", "potato".ToPlural());
        }

        [TestMethod]
        public void ToPlural_Greek()
        {
            Assert.AreEqual("Criteria", "Criterion".ToPlural());
            Assert.AreEqual("phenomena", "phenomenon".ToPlural());
        }

        [TestMethod]
        public void ToPlural_Latin()
        {
            Assert.AreEqual("Alumnae", "Alumna".ToPlural());
            Assert.AreEqual("Alumni", "Alumnus".ToPlural());
            Assert.AreEqual("indices", "index".ToPlural());

            Assert.AreEqual("matrices", "matrix".ToPlural());
            Assert.AreEqual("stimuli", "stimulus".ToPlural());
        }

        [TestMethod]
        public void ToPlural_OddsAndEnds()
        {
            Assert.AreEqual("Lunches", "Lunch".ToPlural());
            Assert.AreEqual("foxes", "fox".ToPlural());
            Assert.AreEqual("heroes", "hero".ToPlural());
            Assert.AreEqual("Torpedoes", "Torpedo".ToPlural());
        }
    }
}
