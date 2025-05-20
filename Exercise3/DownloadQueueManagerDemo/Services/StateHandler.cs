namespace DownloadQueueManagerDemo.Services;
public static class StateHandler
{
    public static void StateChanged(ApplicationState applicationState)
    {
        switch (applicationState)
        {
            case ApplicationState.Initializing:
                ConsoleDisplayManager.WriteToStatusLine("Initializing...");
                break;
            case ApplicationState.Idle:
                ConsoleDisplayManager.WriteToStatusLine("Waiting for command...");
                break;
            case ApplicationState.Downloading:
                ConsoleDisplayManager.WriteToStatusLine("Downloading...");
                break;
            case ApplicationState.Paused:
                ConsoleDisplayManager.WriteToStatusLine("Pausing downloads...");
                break;
            case ApplicationState.Cancelled:
                ConsoleDisplayManager.WriteToStatusLine("Cancelling downloads...");
                break;
            case ApplicationState.Stopped:
                ConsoleDisplayManager.WriteToStatusLine("Exiting...");
                break;
            case ApplicationState.Completed:
                ConsoleDisplayManager.WriteToStatusLine("All downloads completed.");
                break;
        }
    }
}
