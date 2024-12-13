using static System.Console;

// create a auto generated program
// That will merge into the main class Program
partial class Program
{
    private static void SectionTitle(string title)
    {
        WriteLine();
        ConsoleColor previousColr = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkGreen;

        WriteLine($"*** {title} ***");
        ForegroundColor = previousColr;
    }
}