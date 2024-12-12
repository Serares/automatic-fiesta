using System.Numerics;

namespace NumbersAsWordsLib.Shared;

public static class NumbersAsWords
{

    private static string[] words = ["one", "two", "three", "four"];

    public static string ToWords(this int number)
    {
        return ToWords((BigInteger)number);
    }

    public static string ToWords(this long number)
    {
        // cast to bigint to call the correct overloaded method
        return ToWords((BigInteger)number);
    }

    public static string ToWords(this BigInteger number)
    {
        if (number > words.Length)
        {
            throw new ArgumentException("Number is too big", $"{nameof(number)}");
        }
        number -= 1;
        return words[(int)number];
    }
}