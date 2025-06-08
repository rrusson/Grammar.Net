using System.Collections.Generic;

namespace GrammarExtensions
{
	/// <summary>
	/// Extension methods for converting numeric values to their English word or ordinal representations
	/// </summary>
	/// <remarks>This static class includes methods for converting numeric values to their English word forms,
	/// ordinal forms, and ordinal word forms. These methods will handle both positive and negative numbers, as
	/// well as special cases such as zero.</remarks>
	public static class NumericExtension
	{
		private static readonly string[] CardinalOnes = {
			"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", 
			"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
		};

		private static readonly string[] CardinalTens = {
			"zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
		};

		private static readonly string[] OrdinalOnes = {
			"zeroth", "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", 
			"tenth", "eleventh", "twelfth", "thirteenth", "fourteenth", "fifteenth", "sixteenth", "seventeenth", "eighteenth", "nineteenth"
		};

		private static readonly string[] OrdinalTens = {
			"zeroth", "tenth", "twentieth", "thirtieth", "fortieth", "fiftieth", "sixtieth", "seventieth", "eightieth", "ninetieth"
		};

		/// <summary>
		/// Returns the ordinal representation for any positive number
		/// </summary>
		/// <param name="number">Any integer value</param>
		/// <returns>String representation of the ordinal form.</returns>
		/// <example>1 -> 1st, 2 -> 2nd, 3 -> 3rd, 11 -> 11th, etc.</example>
		public static string ToOrdinal(this long number)
		{
			if (number <= 0)
			{
				return number.ToString();
			}

			// Handle special cases in the teens
			long lastTwoDigits = number % 100;
			if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
			{
				return $"{number}th";
			}

			// Determine suffix based on the last digit
			switch (number % 10)
			{
				case 1: return $"{number}st";
				case 2: return $"{number}nd";
				case 3: return $"{number}rd";
				default: return $"{number}th";
			}
		}

		/// <summary>
		/// Converts an integer to its English word representation
		/// </summary>
		/// <param name="number">Any integer value</param>
		/// <returns>English word representation of the <paramref name="number"/></returns>
		/// <example>1 -> one, 20 -> twenty, 404 -> four-hundred and four, etc.</example>
		public static string ToWords(this long number)
		{
			if (number == 0)
			{
				return "zero";
			}

			if (number < 0)
			{
				return "minus " + (-number).ToWords();
			}

			var parts = new List<string>();

			if ((number / 1_000_000) > 0)
			{
				parts.Add($"{(number / 1_000_000).ToWords()} million");
				number %= 1_000_000;
			}

			if ((number / 1_000) > 0)
			{
				parts.Add($"{(number / 1_000).ToWords()} thousand");
				number %= 1_000;
			}

			if ((number / 100) > 0)
			{
				parts.Add($"{(number / 100).ToWords()} hundred");
				number %= 100;
			}

			if (number > 0)
			{
				if (number < 20)
				{
					parts.Add(CardinalOnes[number]);
				}
				else
				{
					long tens = number / 10;
					long units = number % 10;
					parts.Add(CardinalTens[tens]);
					if (units > 0)
					{
						parts[parts.Count - 1] += $"-{CardinalOnes[units]}";
					}
				}
			}

			return string.Join(" ", parts);
		}

		/// <summary>
		/// Converts an integer to its ordinal English word representation
		/// </summary>
		/// <param name="number">Any integer value</param>
		/// <returns>Ordinal English word form of the <paramref name="number"/></returns>
		/// <example>1 -> first, 2 -> second, 21 -> twenty-first, etc.</example>
		public static string ToWordsOrdinal(this long number)
		{
			if (number == 0)
			{
				return "zeroth";
			}

			if (number < 0)
			{
				return "minus " + (-number).ToWordsOrdinal();
			}

			var parts = new List<string>();

			long millions = number / 1_000_000;
			if (millions > 0)
			{
				number %= 1_000_000;
				if (number == 0)
				{
					return $"{millions.ToWordsOrdinal()} million";
				}

				parts.Add($"{millions.ToWords()} million");
			}

			long thousands = number / 1000;
			if (thousands > 0)
			{
				number %= 1000;
				if (number == 0)
				{
					//return $"{string.Join(" ", parts)} {thousands.ToWordsOrdinal()} thousand".Trim();
					return $"{string.Join(" ", parts)} {thousands.ToWords()} thousandth".Trim();
				}

				parts.Add($"{thousands.ToWords()} thousand");
			}

			long hundreds = number / 100;
			if (hundreds > 0)
			{
				number %= 100;
				if (number == 0)
				{
					// Handle "100" as "one hundredth"
					if (hundreds == 1)
					{
						return $"{string.Join(" ", parts)} one hundredth".Trim();
					}
					return $"{string.Join(" ", parts)} {hundreds.ToWordsOrdinal()} hundred".Trim();
				}

				parts.Add($"{hundreds.ToWords()} hundred");
			}

			if (number > 0)
			{
				parts.Add(ConvertUnder100ToOrdinal(number));
			}

			return string.Join(" ", parts);
		}

		private static string ConvertUnder100ToOrdinal(long number)
		{
			if (number < 20)
			{
				return OrdinalOnes[number];
			}

			long tens = number / 10;
			long ones = number % 10;

			return (ones == 0)
				? OrdinalTens[tens]
				: $"{CardinalTens[tens]}-{OrdinalOnes[ones]}"; // e.g. 21 -> "twenty-first"
		}
	}
}
