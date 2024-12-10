using static System.Console;

namespace MyLibrary.Shared;

public class DvdPlayer : IPlayable
{
    public void Pause()
    {
        WriteLine("DVD Player paused");
    }

    public void Play()
    {
        WriteLine("DVD player started...");
    }
}