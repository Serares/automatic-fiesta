﻿using static System.Console;

// TimesTable(number: 6);
RunFactorial();

static void TimesTable(byte number = 5)
{
    for (int row = 1; row <= 12; row++)
    {
        WriteLine($"{row} X {number} = {row * number}");
    }
}

static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
{
    decimal rate = 0.0M;
    string regionToUpper = twoLetterRegionCode.ToUpper();
    // since we are matching string values a switch
    // statement is easier than a switch expression

    rate = regionToUpper switch
    {
        // Switzerland 
        "CH" => 0.08M,
        // Denmark 
        "DK" or "NO" => 0.25M,
        // United Kingdom
        "GB" or "FR" => 0.2M,
        // Hungary
        "HU" => 0.27M,
        // Oregon
        "OR" or "AK" or "MT" => 0.0M,
        // North Dakota
        "ND" or "WI" or "ME" or "VA" => 0.05M,
        // California
        "CA" => 0.0825M,
        // most US states 
        _ => 0.06M,
    };
    return amount * rate;
}

static int Factorial(int number)
{
    if (number < 1)
    {
        return 0;
    }
    else if (number == 1)
    {
        return 1;
    }
    else
    {
        return number * Factorial(number - 1);
    }
}

static void RunFactorial()
{
    for (int i = 1; i < 15; i++)
    {
        WriteLine($"{i}! = {Factorial(i):N0}");
    }
}