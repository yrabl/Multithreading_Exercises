namespace FileDownloaderWithProgressDemo.Services;
public static class ProgressHandler
{
    public static void ProgressChange(FileDownload fileDownload, int progress)
    {
        Console.WriteLine($"File {fileDownload.Index} from {fileDownload.Url} is {progress}% downloaded. ({fileDownload.ElapsedTime:N0} of {fileDownload.DownloadTime:N0})");
    }

    public static void DownloadCompleted(FileDownload fileDownload)
    {
        Console.WriteLine($"File {fileDownload.Index} from {fileDownload.Url} finished at {DateTime.Now:HH:mm:ss.fff}.");
    }

    public static void DownloadCancelled(FileDownload fileDownload)
    {
        Console.WriteLine($"File {fileDownload.Index} from {fileDownload.Url} cancelled at {fileDownload.DownloadProgress}%.");
    }
}
