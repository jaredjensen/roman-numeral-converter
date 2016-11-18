using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralConverterTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void FromRoman()
		{
			var converter = new RomanNumeralConverter.RomanNumeralConverter();
			Assert.AreEqual(36, converter.FromRoman("XXXVI"));
			Assert.AreEqual(2012, converter.FromRoman("MMXII"));
			Assert.AreEqual(1996, converter.FromRoman("MCMXCVI"));
		}

		[TestMethod]
		public void ToRoman()
		{
			var converter = new RomanNumeralConverter.RomanNumeralConverter();
			Assert.AreEqual("XXXVI", converter.ToRoman(36));
			Assert.AreEqual("MMXII", converter.ToRoman(2012));
			Assert.AreEqual("MCMXCVI", converter.ToRoman(1996));
		}

		[TestMethod]
		public void NextRoman()
		{
			var converter = new RomanNumeralConverter.RomanNumeralConverter();
			const string roman = "MMXII";
			Assert.AreEqual("M", converter.GetNextRoman(roman, 0));
			Assert.AreEqual("M", converter.GetNextRoman(roman, 1));
			Assert.AreEqual("X", converter.GetNextRoman(roman, 2));
			Assert.AreEqual("I", converter.GetNextRoman(roman, 3));
			Assert.AreEqual("I", converter.GetNextRoman(roman, 4));
		}
	}
}
