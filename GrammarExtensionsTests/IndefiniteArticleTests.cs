using GrammarExtensions;

namespace GrammarExtensionsTests
{
    [TestClass]
	public class IndefiniteArticleTests
	{
		[TestMethod]
		public void IndefiniteArticle_aTest()
		{
			// Arrange
			var aWords = new string[] {
				"banana",
				"ewe",
				"European",
				"one",
				"once",
				"one-armed",
				"one-time",
				"Ouija",
				"ubiquity",
				"uboat",
				"ufo",
				"UK",
				"ukulele",
				"U.N.",
				"unanimous",
				"unicorn",
				"unilateral",
				"urologist",
				"urea",
				"useful",
				"user"
			};

			// Act and Assert
			foreach (var word in aWords)
			{
				Assert.AreEqual("a", word.IndefiniteArticle(), $"Wrong IndefiniteArticle for {word}");
			}
		}

		[TestMethod]
		public void IndefiniteArticle_anTest()
		{
			// Arrange
			var anWords = new string[]
			{
				"apple",
				"Euler",
				"honor",
				"honorable",
				"hour",
				"honest",
				"heir",
				"onerous",
				"Oaxaca",
				"unassailable",
				"Uber mensch",
				"unanswered",
				"ungrammatical",
				"unilluminated",
				"unintentional",
				"unlikely",
				"urgent",
				"utter"
			};

			// Act and Assert
			foreach (var word in anWords)
			{
				Assert.AreEqual("an", word.IndefiniteArticle(), $"Wrong IndefiniteArticle for {word}");
			}
		}

		[TestMethod]
		public void IndefiniteArticle_caseSensitivityTest()
		{
			// Act and Assert
			Assert.AreEqual("a", "hamburger".IndefiniteArticle(), "Wrong IndefiniteArticle for 'hamburger'");

			Assert.AreEqual("an", "honor".IndefiniteArticle(), "Wrong IndefiniteArticle for 'honor'");

			// Acronyms
			Assert.AreEqual("a", "Faa".IndefiniteArticle(), "Wrong IndefiniteArticle for 'Faa'");
			Assert.AreEqual("an", "FAA".IndefiniteArticle(), "Wrong IndefiniteArticle for 'FAA'");
		}

		[TestMethod("IndefiniteArticle returns empty string when the string is null or empty")]
		public void IndefiniteArticle_emptyTest()
		{
			// Arrange
			string? nothing = null;

            // Act and Assert
#pragma warning disable CS8604 // Possible null reference argument. Not just possible, but deliberate in this test.
            Assert.AreEqual(string.Empty, nothing.IndefiniteArticle(), "Wrong IndefiniteArticle for null string");
#pragma warning restore CS8604
			Assert.AreEqual(string.Empty, "".IndefiniteArticle(), "Wrong IndefiniteArticle for empty string");
			Assert.AreEqual(string.Empty, "       ".IndefiniteArticle(), "Wrong IndefiniteArticle for whitespace string");
		}
	}
}
