Console.WriteLine("Please add a number:");
string? userInput = Console.ReadLine();
try
{
    int number = int.Parse(userInput);

    for (int i = 0; i < number; i++)
    {
        string state = "";
        if (i % 3 == 0)
        {
            state += "fizz";
        }

        if (i % 5 == 0)
        {
            state += "buzz";
        }

        Console.Write("{0} ", arg0: state == "" ? i : state);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.GetType()} : {ex.Message}");
}