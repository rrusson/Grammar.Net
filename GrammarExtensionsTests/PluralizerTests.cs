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
        [DataRow("Test", "Tests")]
        [DataRow("test", "tests")]
        [DataRow("potato", "potatoes")]
		// Greek words
		[DataRow("analysis", "analyses")]
		[DataRow("crisis", "crises")]
		[DataRow("Criterion", "Criteria")]
        [DataRow("phenomenon", "phenomena")]
        // Latin words
        [DataRow("Alumna", "Alumnae")]
        [DataRow("Alumnus", "Alumni")]
        [DataRow("index", "indices")]
        [DataRow("matrix", "matrices")]
        [DataRow("stimulus", "stimuli")]
		// French words
		[DataRow("bureau", "bureaux")]
		[DataRow("château", "châteaux")]
		// Odds and Ends
		[DataRow("Lunch", "Lunches")]
        [DataRow("fox", "foxes")]
        [DataRow("hero", "heroes")]
        [DataRow("Torpedo", "Torpedoes")]
		// More tests
		[DataRow("appendix", "appendices")]
		[DataRow("axis", "axes")]
		[DataRow("bacillus", "bacilli")]
		[DataRow("bacterium", "bacteria")]
		[DataRow("basis", "bases")]
		[DataRow("codex", "codices")]
		[DataRow("criterion", "criteria")]
		[DataRow("curriculum", "curricula")]
		[DataRow("datum", "data")]
		[DataRow("diagnosis", "diagnoses")]
		[DataRow("ellipsis", "ellipses")]
		[DataRow("erratum", "errata")]
		[DataRow("focus", "foci")]
		[DataRow("formula", "formulae")]
		[DataRow("fungus", "fungi")]
		[DataRow("hypothesis", "hypotheses")]
		[DataRow("index", "indices")]
		[DataRow("larva", "larvae")]
		[DataRow("loaf", "loaves")]
		[DataRow("locus", "loci")]
		[DataRow("matrix", "matrices")]
		[DataRow("medium", "media")]
		[DataRow("memorandum", "memoranda")]
		[DataRow("minutia", "minutiae")]
		[DataRow("nebula", "nebulae")]
		[DataRow("nucleus", "nuclei")]
		[DataRow("oasis", "oases")]
		[DataRow("ovum", "ova")]
		[DataRow("parenthesis", "parentheses")]
		[DataRow("phenomenon", "phenomena")]
		[DataRow("phylum", "phyla")]
		[DataRow("radius", "radii")]
		[DataRow("referendum", "referenda")]
		[DataRow("series", "series")]
		[DataRow("stimulus", "stimuli")]
		[DataRow("stratum", "strata")]
		[DataRow("syllabus", "syllabi")]
		[DataRow("symposium", "symposia")]
		[DataRow("synopsis", "synopses")]
		[DataRow("tableau", "tableaux")]
		[DataRow("thesis", "theses")]
		[DataRow("vertebra", "vertebrae")]
		[DataRow("vertex", "vertices")]
		[DataRow("libretto", "librettos")]
		[DataRow("vita", "vitae")]
		[DataRow("vortex", "vortices")]
		// Weirdo plurals
		[DataRow("corpus", "corpora")]
		[DataRow("child", "children")]
		[DataRow("die", "dice")]
		[DataRow("dwarf", "dwarves")]
		[DataRow("foot", "feet")]
		[DataRow("genus", "genera")]
		[DataRow("goose", "geese")]
		[DataRow("half", "halves")]
		[DataRow("hoof", "hooves")]
		[DataRow("tableau", "tableaux")]
		[DataRow("loaf", "loaves")]
		[DataRow("louse", "lice")]
		[DataRow("man", "men")]
		[DataRow("mouse", "mice")]
		[DataRow("opus", "opera")]
		[DataRow("ox", "oxen")]
		[DataRow("quiz", "quizzes")]
		[DataRow("scarf", "scarves")]
		[DataRow("self", "selves")]
		[DataRow("thief", "thieves")]
		[DataRow("tooth", "teeth")]
		[DataRow("wharf", "wharves")]
		[DataRow("wife", "wives")]
		[DataRow("wolf", "wolves")]
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
