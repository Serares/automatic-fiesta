using System.Text.RegularExpressions;

namespace MyLibrary.Shared;

public static class StringExtensions
{
    // using this tells the compiler the method is extending the string type
  public static bool IsValidEmail(this string input)
  {
    // use simple regular expression to check  
    // that the input string is a valid email  
    return Regex.IsMatch(input,
      @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
  }
}
