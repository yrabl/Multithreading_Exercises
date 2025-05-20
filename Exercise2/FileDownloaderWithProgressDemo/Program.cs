using FileDownloaderWithProgressDemo.Application;
using FileDownloaderWithProgressDemo.Domain;

internal class Program
{
    private static void Main(string[] args)
    {
        var app = new DownloadApp();
        app.Run();
    }
}