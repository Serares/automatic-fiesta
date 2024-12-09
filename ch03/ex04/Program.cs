// handle exceptions
using static System.Console;


// can covert to byte to make sure it's between 0 - 255
try
{
    checked
    {

        Write("Enter a number between 0 and 255: ");
        string? firstInput = ReadLine();

        byte firstInputParsed = (byte)int.Parse(firstInput);

        WriteLine("Enter another number between 0 and 255: ");
        string? secondInput = ReadLine();

        byte secondInputParsed = (byte)int.Parse(secondInput);

        WriteLine("{0} divided by {1}", arg0: firstInputParsed, arg1: secondInputParsed);
    }
}
catch (OverflowException)
{
    WriteLine("Numbers are too big, you must enter numbers between 0 - 255");
}
catch (Exception ex)
{
    WriteLine($"Got an error from the inputs {ex.GetType()}");
    WriteLine($"Message {ex.Message}");
}