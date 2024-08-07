﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace GrammarExtensions
{
	public static class Grammar
    {
        /// <summary>
        /// Returns "a" or "an" based on grammatical rules
        /// </summary>
        /// <param name="noun">object of the article</param>
        /// <returns>"a" or "an"-- empty if input was empty</returns>
        public static string IndefiniteArticle(this string? noun)
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

		// NOTE: Spent a couple hours on this, then realized Microsoft has a perfectly good wheel in System.Data.Entity.Design.PluralizationServices
		// https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.design.pluralizationservices.pluralizationservice?view=netframework-4.8.1
		// And the Humanizer library has these methods and much more: https://github.com/Humanizr/Humanizer

		public static string ToPlural(this string noun)
        {
            if (string.IsNullOrWhiteSpace(noun))
            {
                return string.Empty;
            }

            string[] alreadyPluralEndings = { "deer", "fish", "itis", "ois", "pos", "sheep" };
            if (alreadyPluralEndings.Any(w => noun.EndsWith(w)))
            {
                return noun ?? string.Empty;
			}

            string? latin = TryLatinateEndings(noun);
            if (latin != null)
            {
                return latin;
            }

            char lastLetter = noun.Reverse().Take(1).ToArray()[0];

            //Vowel endings
            if (lastLetter == 'y')
            {
                return ReplaceEnding(noun, 1, "ies");
            }
            
            //If the noun ends with -ch, -s, -sh, -x, or -z, add "es"
            if (lastLetter == 'o' || lastLetter == 's' || lastLetter == 'x' || lastLetter == 'z'
                || noun.EndsWith("ch") || noun.EndsWith("sh"))
            {
                return noun + "es";
            }

            //If the noun ends with -f or -fe, change to "ves" (e.g. knife --> knives)
            if (lastLetter == 'f')
            {
                return ReplaceEnding(noun, 1, "ves");
            }
            if (noun.EndsWith("fe"))
            {
                return ReplaceEnding(noun, 2, "ves");
            }

            //Greek words
            if (noun.EndsWith("sis"))   // e.g. hypothesis --> hypotheses
            {
                return ReplaceEnding(noun, 2, "es");
            }

            if (noun.EndsWith("ion") || noun.EndsWith("non"))   // e.g. criterion --> Criteria
            {
                return ReplaceEnding(noun, 2, "a");
            }

            return noun + "s";
        }

        public static string ToSingular(this string noun)
        {
            //  Singularizing RegEx:        /(?<![aei])([ie][d])(?=[^a-zA-Z])|(?<=[ertkgwmnl])s(?=[^a-zA-Z])/g
            throw new NotImplementedException("This is nowhere near complete");

            //return ReplaceEnd(noun, 1, "");
        }

		private static string? TryLatinateEndings(string noun)
		{
			if (noun.EndsWith("ex") || noun.EndsWith("ix"))
			{
				return ReplaceEnding(noun, 2, "ices");
			}

			if (noun.EndsWith("um"))    //e.g. memorandum --> memoranda
			{
				return ReplaceEnding(noun, 2, "a");
			}
			if (noun.EndsWith("us"))    //e.g. radius --> radii
			{
				return ReplaceEnding(noun, 2, "i");
			}

			if (noun.EndsWith("a"))
			{
				return noun + "e";
			}

			return null;
		}

		private static string ReplaceEnding(string input, int numberOfChars, string ending)
        {
            if (string.IsNullOrWhiteSpace(ending))
            {
                return input ?? string.Empty;
            }

            return string.IsNullOrWhiteSpace(input)
                ? ending
				: string.Concat(input.AsSpan(0, input.Length - numberOfChars), ending);
        }
    }
}
