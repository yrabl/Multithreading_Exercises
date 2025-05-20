using DownloadQueueManagerDemo.Application;

internal class Program
{
    private static void Main(string[] args)
    {
        DownloadApp app = new();
        app.Run();
    }
}