namespace RomanNumeralConverter
{
	public interface IRomanNumeralConverter
	{
		int FromRoman(string romanNumeral);
		string ToRoman(int number);
		string GetNextRoman(string romanNumeral, int startAt);
	}
}
