using static System.Console;
namespace MyLibrary.Shared;

public interface IPlayable
{
    void Play();
    void Pause();

    void Stop()
    {
        WriteLine("Default implementation of STOP");
    } // defualt interface implementation; added after a type implemented the interface
}