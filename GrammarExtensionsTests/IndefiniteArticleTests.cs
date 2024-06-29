using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
				"ouija",
				"ubiquity",
				"uboat",
				"ufo",
				"UK",
				"ukulele",
				"u.n.",
				"unanimous",
				"unicorn",
				"unilateral",
				"urinologist",
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
				"euler",
				"honor",
				"honorable",
				"hour",
				"honest",
				"heir",
				"onerous",
				"Oaxaca",
				"unassailable",
				"ubermensch",
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
			Assert.AreEqual("a", "Hamburger".IndefiniteArticle(), "Wrong IndefiniteArticle for 'Hamburger'");

			Assert.AreEqual("an", "honor".IndefiniteArticle(), "Wrong IndefiniteArticle for 'honor'");
			Assert.AreEqual("an", "Honor".IndefiniteArticle(), "Wrong IndefiniteArticle for 'Honor'");

			// Acronyms
			Assert.AreEqual("a", "Faa".IndefiniteArticle(), "Wrong IndefiniteArticle for 'Faa'");
			Assert.AreEqual("an", "FAA".IndefiniteArticle(), "Wrong IndefiniteArticle for 'FAA'");
		}

		[TestMethod]
		public void IndefiniteArticle_emptyTest()
		{
			// Arrange
			string? nothing = null;

			// Act and Assert
			Assert.AreEqual("", nothing.IndefiniteArticle(), "Wrong IndefiniteArticle for null string");
			Assert.AreEqual("", "".IndefiniteArticle(), "Wrong IndefiniteArticle for empty string");
			Assert.AreEqual("", "       ".IndefiniteArticle(), "Wrong IndefiniteArticle for whitespace string");
		}
	}
}
