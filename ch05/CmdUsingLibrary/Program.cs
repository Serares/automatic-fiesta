using static System.Console;

using MyLibrary.Shared;
using System.Reflection.Metadata;

Person jon = new();

jon.Name = "Jon";
jon.DateOfBirth = new DateTime(1989, 1, 28);
jon.FavouriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;
// WriteLine(jon.ToString());

WriteLine(
    "{0} was born on: {1:dddd, d MMMM yyyy}, Favourite wonder: {2}",
    arg0: jon.Name,
    arg1: jon.DateOfBirth,
    arg2: jon.FavouriteAncientWonder
    );

// Shorthand object initializer
Person alice = new()
{
    Name = "Alice",
    DateOfBirth = new(1998, 4, 10)
};

WriteLine("{0} was born on: {1:dddd, d MMMM yyyy}",
arg0: alice.Name,
arg1: alice.DateOfBirth,
arg2: alice.FavouriteAncientWonder
);

// Storing multiple values using an enum type
// 💡This is a cool trick
jon.BucketList =
WondersOfTheAncientWorld.GreatPyramidOfGiza |
WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine($"{jon.Name} bucket list {jon.BucketList}");

jon.Children.Add(new Person { Name = "Bob" }); // C# 3.0 and later
jon.Children.Add(new() { Name = "Zoe" }); // C# 9.0 and later

WriteLine(
    $"{jon.Name} has {jon.Children.Count} children: "
    );
foreach (Person child in jon.Children)
{
    Write($"{child.Name} ");
}

BankAccount.InterestRate = 0.012M; // store a shared value
BankAccount jonesAccount = new(); // C# 9.0 and later
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
arg0: jonesAccount.AccountName,
arg1: jonesAccount.Balance * BankAccount.InterestRate);
BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
arg0: gerrierAccount.AccountName,
arg1: gerrierAccount.Balance * BankAccount.InterestRate);

// read-only fields
WriteLine($"{jon.Name} was born on {jon.HomePlanet}");

Person blankPerson = new();
WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
arg0: blankPerson.Name,
arg1: blankPerson.HomePlanet,
arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
arg0: gunny.Name,
arg1: gunny.HomePlanet,
arg2: gunny.Instantiated);

jon.WriteToConsole();
WriteLine(jon.GetOrigin());

(string, int) fruit = jon.GetFruit();
WriteLine($"{fruit.Item1} : {fruit.Item2}");


var namedFruit = jon.GetNamedFruit();
WriteLine($"{namedFruit.Name} : {namedFruit.Number}");

// 💡Inferring tuple names
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (jon.Name, jon.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

// 💡 Deconstructing tuples
// assigning the parts of the tuple to new variables
(string TheName, int TheNumber) tupleWithNamedFields = jon.GetNamedFruit();
(string fruitName, int fruitNumber) = jon.GetFruit();

WriteLine($"Deconstructed tuple: {fruitName} : {fruitNumber}");

// 💡Deconstructing a instance
var (name1, dob1) = jon;
WriteLine($"Deconstructed: {name1} : {dob1}");

// Optional parameters
WriteLine(jon.OptionalParameters("Jump!", 98.5));
// Naming parameters
WriteLine(jon.OptionalParameters(
number: 52.7, command: "Hide!"));
// Skipping the middle parameter:
WriteLine(jon.OptionalParameters("Poke!", active: false));

// Ways of passing paremeters:
int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
jon.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");
// stdount: 10 ; 21 ; 100

int d = 10;
int e = 20;
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
// simplified C# 7.0 or later syntax for the out parameter
jon.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");

// read-only properties
Person sam = new()
{
    Name = "Same",
    DateOfBirth = new(1972, 1, 10)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

// 💡Using indexers:
sam.Children.Add(new() { Name = "Charlie" });
sam.Children.Add(new() { Name = "Ella" });
WriteLine($"Sam's first child is {sam.Children[0].Name}");
WriteLine($"Sam's second child is {sam.Children[1].Name}");
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");


// 💡 Exploring pattern matching

object[] passengers = {
        new FirstClassPassenger { AirMiles = 1_419 },
        new FirstClassPassenger { AirMiles = 16_562 },
        new BusinessClassPassenger(),
        new CoachClassPassenger { CarryOnKG = 25.7 },
        new CoachClassPassenger { CarryOnKG = 0 },
      };

foreach (object passenger in passengers)
{
    decimal flightCost = passenger switch
    {

        /* C# 8 syntax
        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger                           => 2000M, */

        // C# 9 syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M
        },

        BusinessClassPassenger => 1000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger => 650M,
        _ => 800M
    };

    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}


// Working with records
ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};

// the following is not allowed with init properties
// jeff.FirstName = "Geoff";
ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5",
    Color = "Metallic Soul Red",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car
  with
{ Color = "Polymetallic Grey" };

WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // calls Deconstruct method
WriteLine($"{who} is a {what}.");