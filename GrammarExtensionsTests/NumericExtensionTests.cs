using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrammarExtensions;

namespace GrammarExtensionsTests
{
	[TestClass]
	public class NumericExtensionTests
	{
		[DataTestMethod]
		[DataRow(1, "1st")]
		[DataRow(2, "2nd")]
		[DataRow(3, "3rd")]
		[DataRow(4, "4th")]
		[DataRow(10, "10th")]
		[DataRow(11, "11th")]
		[DataRow(12, "12th")]
		[DataRow(13, "13th")]
		[DataRow(21, "21st")]
		[DataRow(22, "22nd")]
		[DataRow(23, "23rd")]
		[DataRow(111, "111th")]
		[DataRow(25313, "25313th")]
		[DataRow(0, "0")]
		[DataRow(-5, "-5")]
		public void ToOrdinal_Test(long input, string expected)
		{
			var result = input.ToOrdinal();
			Assert.AreEqual(expected, result);
		}

		[DataTestMethod]
		[DataRow(0, "zero")]
		[DataRow(1, "one")]
		[DataRow(-1, "minus one")]
		[DataRow(15, "fifteen")]
		[DataRow(21, "twenty-one")]
		[DataRow(100, "one hundred")]
		[DataRow(101, "one hundred one")]
		[DataRow(999, "nine hundred ninety-nine")]
		[DataRow(1000, "one thousand")]
		[DataRow(1001, "one thousand one")]
		[DataRow(1000000, "one million")]
		[DataRow(1073046, "one million seventy-three thousand forty-six")]
		public void ToWords_Test(long input, string expected)
		{
			var result = input.ToWords();
			Assert.AreEqual(expected, result);
		}
	}
}
