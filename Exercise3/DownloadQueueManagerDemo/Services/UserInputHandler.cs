namespace DownloadQueueManagerDemo.Services;
public class UserInputHandler
{
    private readonly ApplicationStateManager _stateManager;

    public UserInputHandler(ApplicationStateManager stateManager)
    {
        _stateManager = stateManager;
    }
    public void HandleUserInput()
    {
        while (true)
        {
            if (_stateManager.ApplicationState == ApplicationState.Completed)
            {
                break;
            }
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.C)
                {
                    _stateManager.ApplicationState = ApplicationState.Cancelled;
                    break;
                }
                else if (key == ConsoleKey.Q)
                {
                    _stateManager.ApplicationState = ApplicationState.Stopped;
                    break;
                }
                else if (key == ConsoleKey.P)
                {
                    _stateManager.ApplicationState = ApplicationState.Paused;
                }
                else if (key == ConsoleKey.R)
                {
                    _stateManager.ApplicationState = ApplicationState.Downloading;
                }
                Thread.Sleep(100);
            }
        }
    }
}
