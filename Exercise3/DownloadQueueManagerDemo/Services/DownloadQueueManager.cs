using DownloadQueueManagerDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownloadQueueManagerDemo.Services;
public class DownloadQueueManager
{
    private readonly SemaphoreSlim semaphore = new(3);
    private readonly ApplicationStateManager _stateManager;
    private PriorityQueue<FileDownload, int> _queue;
    private List<Thread> _threads;

    public DownloadQueueManager(ApplicationStateManager stateManager)
    {
        _stateManager = stateManager;
        _stateManager.OnApplicationStateChanged += StateHandler.StateChanged;
    }

    public void StartAllDownloads(PriorityQueue<FileDownload, int> queue)
    {
        _queue = queue;
        _threads = new List<Thread>(semaphore.CurrentCount);
        _stateManager.ApplicationState = ApplicationState.Downloading;
        while (_queue.Count > 0)
        {
            FileDownload fileDownload = _queue.Dequeue();
            int currentConsoleLine = ConsoleDisplayManager.IncrementLineIndex;
            fileDownload.consoleLine = currentConsoleLine;
            fileDownload.FileDownloadStatus = FileDownloadStatus.NotStarted;
            var worker = new DownloadWorker(fileDownload, _stateManager);
            Thread thread = new Thread(() =>
            {
                semaphore.Wait();
                try
                {
                    worker.Run();
                }
                finally
                {
                    semaphore.Release();
                }
            });
            _threads.Add(thread);
            thread.Start();
            
        }

        while (_threads.Exists(t => t.IsAlive))
        {
            Thread.Sleep(200);
        }

        if (_stateManager.ApplicationState == ApplicationState.Downloading)
        {
            _stateManager.ApplicationState = ApplicationState.Completed;
        }
    }
}
