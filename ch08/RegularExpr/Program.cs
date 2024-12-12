using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using static System.Console;

// ❗ not really working but it's a start

bool shouldStop = false;
CancellationTokenSource cts = new();
CancellationToken ct = cts.Token;

Thread EscKeyMonitor = new Thread(() =>
{
    while (!ct.IsCancellationRequested)
    {
        if (IsEscPressed())
        {
            cts.Cancel();
        }

        Thread.Sleep(500);
    }
});
EscKeyMonitor.Start();

while (!shouldStop)
{
    if (ct.IsCancellationRequested)
    {
        shouldStop = true;
        Console.Clear();
        break;
    }
    Console.WriteLine("Please enter a regex");
    string? regexPattern = Console.ReadLine();
    if (regexPattern == null || regexPattern == " ")
    {
        regexPattern = @"\d+";
    }

    Regex r = new(regexPattern);

    WriteLine("Add a string to check the Regex agains");

    string? stringToCheck = ReadLine();

    MatchCollection matches = r.Matches(stringToCheck);

    WriteLine("Matches found:");
    foreach (Match m in matches)
    {
        WriteLine($"match -> {0}", m.Value);
    }
}

static bool IsEscPressed()
{
    ConsoleKey key = Console.ReadKey(true).Key;
    return key == ConsoleKey.Escape;
}