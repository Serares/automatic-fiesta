using static System.Console;
using CallStackExceptionHandlingLib;

WriteLine("In main");
Alpha();

static void Alpha()
{
    WriteLine("Alpha");
    Beta();
}

static void Beta()
{
    try
    {
        WriteLine("Beta");
        Calculator.Gamma();
    }
    catch (Exception ex)
    {
        WriteLine($"Caught this: {ex.Message}");
        throw;
    }
}