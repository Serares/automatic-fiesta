namespace PrimeFactorsLib;

public class PrimeFactors
{
    /// <summary>
    /// Find Prime Factors of n > 1 && n <= 1000
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public string FindPrimeFactors(int number)
    {

        if (number > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Parameter overflow");
        }

        string foundPrimes = "";
        int primeDivizor = 2;
        // start dividing with the smallest prime number 2
        // found online 😅
        while (number > 1)
        {
            while (number % primeDivizor == 0)
            {
                foundPrimes += primeDivizor.ToString() + " ";
                number /= primeDivizor;
            }
            primeDivizor += 1;

            if (primeDivizor * primeDivizor > number)
            {
                if (number > 1)
                {
                    foundPrimes += number.ToString() + " ";
                    break;
                }
            }
        }

        return string.Join(" X ", foundPrimes.TrimEnd(' ').Split(" ").Reverse());
    }
}
