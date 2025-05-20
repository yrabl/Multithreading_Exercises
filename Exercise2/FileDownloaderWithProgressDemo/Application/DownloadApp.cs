namespace FileDownloaderWithProgressDemo.Application;
public class DownloadApp
{
    private readonly DownloadManager _manager;
    private readonly FileFactory _fileFactory;

    public DownloadApp()
    {
        _manager = new DownloadManager();
        _fileFactory = new FileFactory();
    }

    public void Run()
    {
        // Simulate a list of file URLs to download - hardcoded for exercise purposes
        string[] urls = GetSampleUrls();
        var files = _fileFactory.CreateFileDownloads(urls);

        Console.WriteLine($"Ready to start downloading {files.Count} files.");
        Console.WriteLine("Press:\r\ns -> to start\r\nc -> to cancel\r\nq -> to quit");

        bool isRunning = true;
        while (isRunning)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.S)
            {
                _manager.StartDownloads(files);
                break;
            }
            else if (key == ConsoleKey.Q)
            {
                isRunning = false;
                break;
            }
        }

        if (isRunning)
        {
            _manager.ListenForControlKeys();
        }
        else
        {
            Console.WriteLine("Exiting...");
        }

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
