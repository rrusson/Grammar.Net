using System.Collections.Immutable;

namespace GrammarExtensions
{
	public static class PluralizerExtension
	{
		// NOTE: Spent a couple hours on this, then realized Microsoft has a perfectly good wheel in System.Data.Entity.Design.PluralizationServices
		// https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.design.pluralizationservices.pluralizationservice?view=netframework-4.8.1
		// And the Humanizer library has these methods and much more: https://github.com/Humanizr/Humanizer

		private static readonly string[] _samePluralEndings = { 
			"bison", "craft", "deer", "faux pas", "fish", "itis", "moose", "offspring", "ois", 
			"pants", "pos", "salmon", "scissors", "series", "sheep", "shrimp", "species", "swine", "trout", "tuna", "tweezers"
		};

		private static readonly ImmutableDictionary<string, string> _specialCases =
			new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
			{
				{ "child", "children" },
				{ "corpus", "corpora" },
				{ "die", "dice" },
				{ "foot", "feet" },
				{ "genus", "genera" },
				{ "goose", "geese" },
				{ "louse", "lice" },
				{ "man", "men" },
				{ "mouse", "mice" },
				{ "opus", "opera" },
				{ "ox", "oxen" },
				{ "quiz", "quizzes" },
				{ "tooth", "teeth" },
				{ "woman", "women" },
			}.ToImmutableDictionary();

		public static string ToPlural(this string noun)
		{
			if (string.IsNullOrWhiteSpace(noun))
			{
				return string.Empty;
			}

			if (_samePluralEndings.Any(w => noun.EndsWith(w)))
			{
				return noun;
			}

			string? specialCase = TrySpecialCases(noun);
			if (specialCase != null)
			{
				return specialCase;
			}

			string? foreignWord = TryForeignLanguageEndings(noun);
			if (foreignWord != null)
			{
				return foreignWord;
			}

			char lastLetter = noun.Reverse().Take(1).ToArray()[0];

			// Vowel endings
			if (lastLetter == 'y')
			{
				return ReplaceEnding(noun, 1, "ies");
			}

			// If the noun ends with -ch, -s, -sh, -x, or -z, add "es"
			if (lastLetter == 'o' || lastLetter == 's' || lastLetter == 'x' || lastLetter == 'z'
				|| noun.EndsWith("ch") || noun.EndsWith("sh"))
			{
				return noun + "es";
			}

			// If the noun ends with -f or -fe, change to "ves" (e.g. knife --> knives)
			if (lastLetter == 'f')
			{
				return ReplaceEnding(noun, 1, "ves");
			}
			if (noun.EndsWith("fe"))
			{
				return ReplaceEnding(noun, 2, "ves");
			}

			return noun + "s";
		}

		private static string ReplaceEnding(string input, int numberOfChars, string ending)
		{
			return input != null
				? string.Concat(input.AsSpan(0, input.Length - numberOfChars), ending)
				: string.Empty;
		}

		private static string? TryForeignLanguageEndings(string noun)
		{
			// Start with Latin words
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

			// Greek words
			if (noun.EndsWith("is"))   //e.g. hypothesis --> hypotheses
			{
				return ReplaceEnding(noun, 2, "es");
			}

			if (noun.EndsWith("ion") || noun.EndsWith("non"))   // e.g. criterion --> Criteria
			{
				return ReplaceEnding(noun, 2, "a");
			}

			// French words
			if (noun.EndsWith("eau") || noun.EndsWith("eu") || noun.EndsWith("ou"))
			{
				return noun + "x"; // e.g. tableau --> tableaux
			}

			// Italian words
			if (noun.EndsWith("tto")) // e.g. virtuoso --> virtuosos
			{
				return noun + "s"; // Let's use the English pluralization for these instead of proper Italian pluralization
			}

			return null;
		}

		private static string? TrySpecialCases(this string noun)
		{
			if (string.IsNullOrEmpty(noun))
			{
				return null;
			}

			if (_specialCases.TryGetValue(noun, out var pluralForm))
			{
				return pluralForm;
			}

			return null;
		}
	}
}
