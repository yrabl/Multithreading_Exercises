namespace DownloadQueueManagerDemo.Application;
public class ApplicationStateManager
{
    private ApplicationState _applicationState = ApplicationState.Initializing;
    public ApplicationState ApplicationState
    {
        get => _applicationState;
        set
        {
            if (_applicationState != value)
            {
                _applicationState = value;
                OnApplicationStateChanged?.Invoke(_applicationState);
            }
        }
    }
    public event ApplicationStateChangedHandler OnApplicationStateChanged;

    public delegate void ApplicationStateChangedHandler(ApplicationState applicationState);
}


