using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrammarExtensions
{
	public static class PluralizerExtension
	{
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
				return noun;
			}

			string latin = TryLatinateEndings(noun);
			if (latin != null)
			{
				return latin;
			}

			char lastLetter = noun.Reverse().Take(1).ToArray()[0];

			//Vowel endings
			if (lastLetter == 'y')
			{
				return ReplaceEnd(noun, 1, "ies");
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
				return ReplaceEnd(noun, 1, "ves");
			}
			if (noun.EndsWith("fe"))
			{
				return ReplaceEnd(noun, 2, "ves");
			}

			//Greek words
			if (noun.EndsWith("sis"))   // e.g. hypothesis --> hypotheses
			{
				return ReplaceEnd(noun, 2, "es");
			}

			if (noun.EndsWith("ion") || noun.EndsWith("non"))   // e.g. criterion --> Criteria
			{
				return ReplaceEnd(noun, 2, "a");
			}

			return noun + "s";
		}

		public static string ToSingular(this string noun)
		{
			//  Singularizing RegEx:        /(?<![aei])([ie][d])(?=[^a-zA-Z])|(?<=[ertkgwmnl])s(?=[^a-zA-Z])/g
			throw new NotImplementedException("This is nowhere near complete");

			return ReplaceEnd(noun, 1, "");
		}

		private static string ReplaceEnd(string input, int numberOfChars, string ending)
		{
			return input.Substring(0, input.Length - numberOfChars) + ending;
		}


		private static string TryLatinateEndings(string noun)
		{
			if (noun.EndsWith("ex") || noun.EndsWith("ix"))
			{
				return ReplaceEnd(noun, 2, "ices");
			}

			if (noun.EndsWith("um"))    //e.g. memorandum --> memoranda
			{
				return ReplaceEnd(noun, 2, "a");
			}
			if (noun.EndsWith("us"))    //e.g. radius --> radii
			{
				return ReplaceEnd(noun, 2, "i");
			}

			if (noun.EndsWith("a"))
			{
				return noun + "e";
			}

			return null;
		}
	}
}
