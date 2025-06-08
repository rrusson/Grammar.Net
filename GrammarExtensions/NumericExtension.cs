using System.Collections.Generic;

namespace GrammarExtensions
{
    public static class NumericExtension
    {
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
                var unitsMap = new[]
                {
                    "zero", "one", "two", "three", "four", "five", "six",
                    "seven", "eight", "nine", "ten", "eleven", "twelve",
                    "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                    "eighteen", "nineteen"
                };
                var tensMap = new[]
                {
                    "zero", "ten", "twenty", "thirty", "forty",
                    "fifty", "sixty", "seventy", "eighty", "ninety"
                };

                if (number < 20)
                {
                    parts.Add(unitsMap[number]);
                }
                else
                {
                    long tens = number / 10;
                    long units = number % 10;
                    parts.Add(tensMap[tens]);
                    if (units > 0)
                    {
                        parts[parts.Count - 1] += $"-{unitsMap[units]}";
                    }
                }
            }

            return string.Join(" ", parts);
        }
    }
}