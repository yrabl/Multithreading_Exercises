using DownloadQueueManagerDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownloadQueueManagerDemo.Application;
public class DownloadApp
{
    private readonly DownloadQueueManager _manager;
    private readonly FileFactory _fileFactory;
    private readonly ApplicationStateManager _stateManager = new();
    private readonly UserInputHandler _userInputHandler;
    public ApplicationState CurrentState
    {
        get => _stateManager.ApplicationState;
        set => _stateManager.ApplicationState = value;
    }

    public DownloadApp()
    {
        _manager = new DownloadQueueManager(_stateManager);
        _fileFactory = new FileFactory();
        _userInputHandler = new UserInputHandler(_stateManager);
        _stateManager.OnApplicationStateChanged += StateHandler.StateChanged;
    }
    public void Run()
    {
        string[] urls = GetSampleUrls();
        var files = _fileFactory.CreateFileDownloadQueues(urls);

        Console.WriteLine($"Ready to start downloading {files.Count} files.");
        MenuUtil.DisplayControls();
        CurrentState = ApplicationState.Idle;

        while (CurrentState == ApplicationState.Idle)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.S)
            {
                Thread downloadThread = new(() => _manager.StartAllDownloads(files));
                downloadThread.Start();
                break;
            }
            else if (key == ConsoleKey.Q)
            {
                CurrentState = ApplicationState.Stopped;
                break;
            }
        }
        Thread inputThread = new(_userInputHandler.HandleUserInput);
        inputThread.Start();

        inputThread.Join();
        Console.SetCursorPosition(0, ConsoleDisplayManager.StatusLineIndex + 1);
    }

    private string[] GetSampleUrls() => new string[]
    {
        "https://example.com/file1.txt",
        "https://example.com/file2.txt",
        "https://example.com/file3.txt",
        "https://example.com/file4.txt",
        "https://example.com/file5.txt",
        "https://example.com/file6.txt",
        "https://example.com/file7.txt",
        "https://example.com/file8.txt",
        "https://example.com/file9.txt",
        "https://example.com/file10.txt"
    };
}
