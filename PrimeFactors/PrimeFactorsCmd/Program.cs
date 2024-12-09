using static System.Console;

using PrimeFactorsLib;

PrimeFactors pr = new();

string primes = pr.FindPrimeFactors(100);

WriteLine($"Primes: {primes}");