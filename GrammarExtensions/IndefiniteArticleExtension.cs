using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace GrammarExtensions
{
    public static class IndefiniteArticleExtension
    {
        /// <summary>
        /// Returns "a" or "an" based on grammatical rules
        /// </summary>
        /// <param name="noun">object of the article</param>
        /// <returns>"a" or "an"</returns>
        public static string IndefiniteArticle(this string noun)
        {
            if (string.IsNullOrWhiteSpace(noun))
            {
                return string.Empty;
            }

            //Acronyms starting with a vowel sound (with or without periods between letters)
            if (noun.Length > 1 && (noun[1] == '.' || noun == noun.ToUpper())
                && "AEFHILMNORSX".Contains(noun[0].ToString().ToUpper()))
            {
                return "an";
            }

            //Acronyms starting with a U sound (with or without periods between letters)
            if (noun.Length > 1 && (noun[1] == '.' || noun == noun.ToUpper())
                && noun[0].ToString().ToUpper() == "U")
            {
                return "a";
            }

            //Convert to lower case for remaining tests
            noun = noun.ToLower(CultureInfo.InvariantCulture);

            string[] specialCases = { "euler", "heir", "honest", "hono", "hour", "uber" };

            if (specialCases.Any(noun.StartsWith))
            {
                return "an";
            }

            //Special cases where a word that begins with a vowel should be preceded by "a"
            string[] exceptions = { "^e[uw]", "^onc?e\\b", "^u[bcfhjkqrst][aeiou]", "^unani", "uni(l[^l]|[a-ko-z])", "^ouija" };

            foreach (var regEx in exceptions)
            {
                if (Regex.IsMatch(noun, regEx)) return "a";
            }

            bool startsWithVowel = noun.StartsWith("a", true, CultureInfo.InvariantCulture)
                || noun.StartsWith("e", true, CultureInfo.InvariantCulture)
                || noun.StartsWith("i", true, CultureInfo.InvariantCulture)
                || noun.StartsWith("o", true, CultureInfo.InvariantCulture)
                || noun.StartsWith("u", true, CultureInfo.InvariantCulture);

            return startsWithVowel
                ? "an"
                : "a";
        }
    }
}
