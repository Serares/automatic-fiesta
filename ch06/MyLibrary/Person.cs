using static System.Console;
namespace MyLibrary.Shared;
public class Person : object, IComparable<Person>
{
    // fields
    public string? Name; // ? allows null
    public DateTime DateOfBirth;
    public List<Person> Children = new(); // C# 9 or later
                                          // methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    // static method to "multiply"
    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}"
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }
    // instance method to "multiply"
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    // 💡define a method for * symbol
    public static Person operator *(Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }

    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than 0");
        }

        return localFactorial(number);

        int localFactorial(int localNumber)
        {
            if (localNumber < 1) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }

    // 💡 delegates
    public event EventHandler? Shout;

    public int AngerLevel;

    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel >= 3)
        {
            // This is the same as checking if the method is empty
            Shout?.Invoke(this, EventArgs.Empty);
            // if (Shout != null)
            // {
            //     Shout(this, EventArgs.Empty);
            // }
        }
    }

    public void TimeTravel(DateTime when)
    {
        if (when <= DateOfBirth)
        {
            throw new PersonException($"If you travel back in time to a date earlier than your own birth, then the universe will explode!");
        }
        else
        {
            WriteLine($"Welcome to {when:yyyy}!");
        }
    }

    public int CompareTo(Person? other)
    {
        if (Name is null) return 0;
        return Name.CompareTo(other?.Name);
    }
}