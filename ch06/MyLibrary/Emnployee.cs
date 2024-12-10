using static System.Console;
namespace MyLibrary.Shared;

public class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateTime HireDate { get; set; }

    // Hiding the inherited methods is non-polymorphic
    public new void WriteToConsole()
    {
        WriteLine(format:
          "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
          arg0: Name,
          arg1: DateOfBirth,
          arg2: HireDate);
    }

    // 🤔 overriden methods
    // overriding methods is polymorphic
    public override string ToString()
    {
        // 💡 we can use base. to access members of the superclass from the subclass
        // $"{Name} is a {base.ToString()}"; 
        return $"{Name}'s code is {EmployeeCode}";
    }
}