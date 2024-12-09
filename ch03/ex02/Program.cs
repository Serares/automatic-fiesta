using static System.Console;

try
{

  checked
  {
    int max = 500;
    for (byte i = 0; i < max; i++)
    {
      WriteLine(i);
    }
  }

}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()} says {ex.Message}");
}