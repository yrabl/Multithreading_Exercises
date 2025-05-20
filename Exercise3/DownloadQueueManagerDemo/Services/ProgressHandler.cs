namespace DownloadQueueManagerDemo.Services;
public static class ProgressHandler
{
    public static void ProgressChange(FileDownload fileDownload, int progress)
    {
        ConsoleDisplayManager.WriteLineToConsole($"File {fileDownload.Index:00} - {fileDownload.Url} - {fileDownload.DownloadProgress}%", fileDownload.consoleLine);
    }
}
