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

		[DataTestMethod]
		// Test capitalization and pluralization
		[DataRow("test", "tests")]
		[DataRow("Test", "Tests")]
		[DataRow("HMO", "HMOs")]
		// French words
		[DataRow("château", "châteaux")]
		[DataRow("tableau", "tableaux")]
		// Greek words
		[DataRow("analysis", "analyses")]
		[DataRow("Criterion", "Criteria")]
		[DataRow("diagnosis", "diagnoses")]
		[DataRow("phenomenon", "phenomena")]
		// Italian words
		[DataRow("libretto", "librettos")]
		[DataRow("tempo", "tempos")]
		// Latin words
		[DataRow("Alumna", "Alumnae")]
		[DataRow("Alumnus", "Alumni")]
		[DataRow("datum", "data")]
		[DataRow("index", "indices")]
		[DataRow("matrix", "matrices")]
		[DataRow("minutia", "minutiae")]
		[DataRow("radius", "radii")]
		[DataRow("stimulus", "stimuli")]
		// Odds and ends
		[DataRow("fox", "foxes")]
		[DataRow("hero", "heroes")]
		[DataRow("Lunch", "Lunches")]
		[DataRow("potato", "potatoes")]
		[DataRow("loaf", "loaves")]
		[DataRow("wife", "wives")]
		[DataRow("wolf", "wolves")]
		// Same as singular
		[DataRow("aircraft", "aircraft")]
		[DataRow("deer", "deer")]
		[DataRow("dermatitis", "dermatitis")]
		[DataRow("faux pas", "faux pas")]
		[DataRow("patois", "patois")]
		[DataRow("salmon", "salmon")]
		[DataRow("species", "species")]
		// Weirdo plurals
		[DataRow("corpus", "corpora")]
		[DataRow("child", "children")]
		[DataRow("die", "dice")]
		[DataRow("foot", "feet")]
		[DataRow("genus", "genera")]
		[DataRow("goose", "geese")]
		[DataRow("louse", "lice")]
		[DataRow("man", "men")]
		[DataRow("mouse", "mice")]
		[DataRow("opus", "opera")]
		[DataRow("ox", "oxen")]
		[DataRow("quiz", "quizzes")]
		[DataRow("tooth", "teeth")]
		[DataRow("woman", "women")]
		public void ToPlural_ReturnsCorrectPluralForm(string singular, string expectedPlural)
		{
			// Act
			string actualPlural = singular.ToPlural();

			// Assert
			Assert.AreEqual(expectedPlural, actualPlural);
		}
	}
}
