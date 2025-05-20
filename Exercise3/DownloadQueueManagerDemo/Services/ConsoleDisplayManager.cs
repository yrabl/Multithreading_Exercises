using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadQueueManagerDemo.Services;
public class ConsoleDisplayManager
{
    private static int _statusLineIndex = 0;
    private static int _currentLineIndex = 0;
    private static string _currentStatus = string.Empty;

    public static int CurrentLineIndex
    {
        get => Volatile.Read(ref _currentLineIndex);
        set => Volatile.Write(ref _currentLineIndex, value);
    }

    public static int StatusLineIndex
    {
        get => Volatile.Read(ref _statusLineIndex);
        set => Volatile.Write(ref _statusLineIndex, value);
    }

    public static int IncrementLineIndex => Interlocked.Increment(ref _currentLineIndex);

    public static void WriteLineToConsole(string message, int lineIndex)
    {
        Console.SetCursorPosition(0, lineIndex);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, lineIndex);
        Console.Write(message);
        if (lineIndex == _statusLineIndex)
        {
            WriteToStatusLine(_currentStatus);
        }
        else
        {
            Console.SetCursorPosition(0, _statusLineIndex + 1);
        }

    }

    public static void WriteToStatusLine(string message)
    {
        int statusLineIndex = Volatile.Read(ref _currentLineIndex) + 2;
        _statusLineIndex = statusLineIndex;
        _currentStatus = message;
        Console.SetCursorPosition(0, statusLineIndex);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, statusLineIndex);
        Console.Write(message);
        Console.SetCursorPosition(0, _statusLineIndex + 1);
    }
}
