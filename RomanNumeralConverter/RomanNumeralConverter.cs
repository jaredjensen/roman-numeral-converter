using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralConverter
{
	public class RomanNumeralConverter : IRomanNumeralConverter
	{
		private static readonly Dictionary<string, int> Numbers = new Dictionary<string, int>
		{
			{"I", 1},
			{"IV", 4},
			{"V", 5},
			{"IX", 9},
			{"X", 10},
			{"XL", 40},
			{"L", 50},
			{"XC", 90},
			{"C", 100},
			{"CD", 400},
			{"D", 500},
			{"CM", 900},
			{"M", 1000},
		};

		public int FromRoman(string romanNumeral)
		{
			if (String.IsNullOrEmpty(romanNumeral))
			{
				throw new ArgumentException("No roman numeral specified", "romanNumeral");
			}

			var number = 0;
			var i = 0;

			while (i < romanNumeral.Length)
			{
				var nextRoman = GetNextRoman(romanNumeral, i);
				if (nextRoman == null)
				{
					throw new Exception("Invalid roman numeral");
				}

				number += Numbers[nextRoman];
				i += nextRoman.Length;
			}

			return number;
		}

		public string ToRoman(int number)
		{
			var roman = "";

			while (number > 0)
			{
				var r = Numbers.Last(x => x.Value <= number);
				roman += r.Key;
				number -= r.Value;
			}

			return roman;
		}

		public string GetNextRoman(string romanNumeral, int startAt)
		{
			if (startAt > romanNumeral.Length - 1)
			{
				throw new ArgumentOutOfRangeException("startAt", "Start position exceeds string length");
			}

			var len = 2;
			while (len > 0)
			{
				if (startAt <= romanNumeral.Length - len)
				{
					var roman = romanNumeral.Substring(startAt, len);
					if (Numbers.ContainsKey(roman))
					{
						return roman;
					}
				}

				len--;
			}

			return null;
		}
	}
}
