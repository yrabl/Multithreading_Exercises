namespace DownloadQueueManagerDemo.Utils;
public static class MenuUtil
{
    static Dictionary<ConsoleKey, string> Controls = new()
    {
        { ConsoleKey.S, "Start" },
        { ConsoleKey.P, "Pause" },
        { ConsoleKey.R, "Resume" },
        { ConsoleKey.C, "Cancel" },
        { ConsoleKey.Q, "Quit" }
    };

    public static void DisplayControls()
    {
        StringBuilder controlString = new StringBuilder("Press:");
        int counter = 0;
        foreach (var control in Controls)
        {
            counter++;
            if (counter % 3 == 1)
            {
                controlString.Append("\r\n");
            }
            controlString.Append($"{control.Key} -> to {control.Value}".PadRight(20));
        }
        Console.WriteLine(controlString);
        ConsoleDisplayManager.CurrentLineIndex = Console.CursorTop + 1;
    }
}
