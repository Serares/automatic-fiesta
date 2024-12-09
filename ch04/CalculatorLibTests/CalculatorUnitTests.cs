using CalculatorLib;
using Xunit;

namespace CalculatorLibTests;

public class CalculatorUnitTests
{
    [Fact]
    public void TestAdding2And2()
    {
        // arrange
        double a = 2;
        double b = 2;
        double expected = 4;

        Calculator calc = new();
        // act
        double result = calc.Add(a, b);

        // assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestAdding3And2()
    {
        // arrange
        double a = 3;
        double b = 2;
        double expected = 5;

        Calculator calc = new();
        // act
        double result = calc.Add(a, b);

        // assert
        Assert.Equal(expected, result);
    }
}
