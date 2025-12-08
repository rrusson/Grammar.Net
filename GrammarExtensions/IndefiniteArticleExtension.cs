using System.Globalization;
using System.Text.RegularExpressions;

namespace GrammarExtensions
{
    public static class IndefiniteArticleExtension
    {
        /// <summary>
        /// Returns "a" or "an" based on grammatical rules
        /// </summary>
        /// <param name="noun">object of the article</param>
        /// <returns>"a" or "an"-- empty if input was empty</returns>
        public static string IndefiniteArticle(this string noun)
        {
            if (string.IsNullOrWhiteSpace(noun))
            {
                return string.Empty;
            }

            //Acronyms starting with a vowel sound (with or without periods between letters)
            if (noun.Length > 1 && (noun[1] == '.' || noun == noun.ToUpper())
                && "AEFHILMNORSX".Contains(noun[0].ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                return "an";
            }

            //Acronyms starting with a U sound (with or without periods between letters)
            if (noun.Length > 1 && (noun[1] == '.' || noun == noun.ToUpper())
                && noun[0].ToString().Equals("U", StringComparison.CurrentCultureIgnoreCase))
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

            if (exceptions.Any(regEx => Regex.IsMatch(noun, regEx, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100))))
            {
				return "a";
            }

            bool startsWithVowel = noun.StartsWith('a')
                || noun.StartsWith('e')
                || noun.StartsWith('i')
                || noun.StartsWith('o')
                || noun.StartsWith('u');

            return startsWithVowel
                ? "an"
                : "a";
        }
    }
}
