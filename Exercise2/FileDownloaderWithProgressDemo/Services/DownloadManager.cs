using System.Threading;

namespace FileDownloaderWithProgressDemo.Services;
public class DownloadManager
{
    private volatile bool _isCancelled = false;
    private volatile bool _isRunning = true;
    private List<Thread> _threads = new();

    public void StartDownloads(List<FileDownload> fileDownloads)
    {
        _threads.Clear();
        _threads.Capacity = fileDownloads.Count;
        foreach (var item in fileDownloads)
        {
            Thread thread = new (() => DownloadFile(item));
            _threads.Add(thread);
            thread.Start();
            Thread.Sleep(10); // Small delay to avoid overwhelming the system
        }
    }

    public void ListenForControlKeys()
    {

        while (_threads.Exists(t => t.IsAlive))
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.C)
                {
                    _isCancelled = true;
                    Console.WriteLine("Cancelling downloads...");
                    break;
                }
                else if (key == ConsoleKey.Q)
                {
                    _isRunning = false;
                    _isCancelled = true;
                    break;
                }
            }
            Thread.Sleep(100);
        }
        if (_isCancelled && _isRunning)
        {
            while (_threads.Exists(t => t.IsAlive))
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("All downloads cancelled.");
        }
        else if (_isRunning)
        {
            Console.WriteLine("All downloads completed.");
        }
        else
        {
            while (_threads.Exists(t => t.IsAlive))
            {
                Thread.Sleep(100);
                Console.WriteLine("Exiting...");
            }
            
        }
    }
    private void DownloadFile(FileDownload fileDownload)
    {
        Console.WriteLine($"Starting download for file {fileDownload.Index} - {fileDownload.Url}");
        // Simulate file download
        int steps = 10;
        int stepDuration = fileDownload.DownloadTime / steps;
        for (int i = 1; i <= steps; i++)
        {
            if (_isCancelled)
            {
                fileDownload.IsCancelled = true;
                return;
            }
            else
            {
                Thread.Sleep(stepDuration);
                fileDownload.ElapsedTime += stepDuration;
                fileDownload.DownloadProgress = i * 10;
            }
        }
    }
}
