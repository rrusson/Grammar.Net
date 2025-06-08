using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrammarExtensions;

namespace GrammarExtensionsTests
{
    [TestClass]
    public class IndefiniteArticleTests
    {
        [TestMethod()]
        public void IndefiniteArticle_aTest()
        {
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
                "urologist",
                "urea",
                "useful",
                "user"
            };

            foreach (var word in aWords)
            {
                if (word.IndefiniteArticle() == "an")
                {
                    Assert.Fail($"Wrong IndefiniteArticle for {word}");
                }
            }
        }

        [TestMethod()]
        public void IndefiniteArticle_anTest()
        {
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

            foreach (var word in anWords)
            {
                if (word.IndefiniteArticle() == "a")
                {
                    Assert.Fail($"Wrong IndefiniteArticle for {word}");
                }
            }
        }

        [TestMethod()]
        public void IndefiniteArticle_caseSensitivityTest()
        {
            Assert.AreEqual("a", "hamburger".IndefiniteArticle());
            Assert.AreEqual("a", "Hamburger".IndefiniteArticle());

            Assert.AreEqual("an", "honor".IndefiniteArticle());
            Assert.AreEqual("an", "Honor".IndefiniteArticle());

            //Acronyms
            Assert.AreEqual("a", "Faa".IndefiniteArticle());
            Assert.AreEqual("an", "FAA".IndefiniteArticle());
        }

        [TestMethod()]
        public void IndefiniteArticle_emptyTest()
        {
            string nothing = null;
            Assert.AreEqual("", nothing.IndefiniteArticle());
            Assert.AreEqual("", "".IndefiniteArticle());
            Assert.AreEqual("", "       ".IndefiniteArticle());
        }

    }
}
