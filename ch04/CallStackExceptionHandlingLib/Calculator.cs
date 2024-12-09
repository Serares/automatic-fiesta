using static System.Console;
namespace CallStackExceptionHandlingLib;

public class Calculator
{
    public static void Gamma()
    {
        WriteLine("Gamma");
        Belta();
    }


    private static void Belta()
    {
        WriteLine("In belta");
        File.OpenText("noFile.txt");
    }
}
