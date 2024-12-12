using NumbersAsWordsLib.Shared;

namespace NumbersAsWordsTests;

public class UnitTest1
{
    [Fact]
    public void TestFour()
    {
        // arrange
        int number = 4;
        string expected = "four";
        //act
        string result = NumbersAsWords.ToWords(number);
        // assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestException()
    {
        // arrange
        int number = 5;
        string expectedMessage = "Number is too big";

        // act
        var exception = Assert.Throws<ArgumentException>(() => NumbersAsWords.ToWords(number));

        // assert
        Assert.Equal(nameof(number), exception.ParamName);
        Assert.Contains(expectedMessage, exception.Message);
    }
}
