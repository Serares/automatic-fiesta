using PrimeFactorsLib;
using Xunit;

namespace PrimeFactorsTest;


public class PrimeFactorUnitTests
{
    [Fact]
    public void PrimeFactorsOf4()
    {
        int number = 4;
        string expected = "2 X 2";

        PrimeFactors prime = new();

        string result = prime.FindPrimeFactors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void PrimeFactorsOf7()
    {
        int number = 7;
        string expected = "7";

        PrimeFactors prime = new();

        string result = prime.FindPrimeFactors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void PrimeFactorsOf30()
    {
        int number = 30;
        string expected = "5 X 3 X 2";

        PrimeFactors prime = new();

        string result = prime.FindPrimeFactors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void PrimeFactorsOf40()
    {
        int number = 40;
        string expected = "5 X 2 X 2 X 2";

        PrimeFactors prime = new();

        string result = prime.FindPrimeFactors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void PrimeFactorsOf50()
    {
        int number = 50;
        string expected = "5 X 5 X 2";

        PrimeFactors prime = new();

        string result = prime.FindPrimeFactors(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void PrimeFactorsThrowException()
    {
        // arrange
        int number = 1001;
        string expectedMessage = "Parameter overflow";
        PrimeFactors prime = new();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => prime.FindPrimeFactors(number));
        Assert.Equal(nameof(number), exception.ParamName);
        Assert.Contains(expectedMessage, exception.Message);
    }
}
