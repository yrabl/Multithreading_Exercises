namespace DownloadQueueManagerDemo.Services;
public static class StatusHandler
{
    public static void StatusChanged(FileDownload fileDownload, FileDownloadStatus fileDownloadStatus)
    {
        string message = $"File {fileDownload.Index:00} - {fileDownload.Url}";
        switch (fileDownloadStatus)
        {
            case FileDownloadStatus.NotStarted:
                ConsoleDisplayManager.WriteLineToConsole($"{message} - Not Started", fileDownload.consoleLine);
                break;
            case FileDownloadStatus.InProgress:
                break;
            case FileDownloadStatus.Paused:
                ConsoleDisplayManager.WriteLineToConsole($"{message} - {fileDownload.DownloadProgress}% Paused at {DateTime.Now:HH:mm:ss.fff}", fileDownload.consoleLine);
                break;
            case FileDownloadStatus.Completed:
                ConsoleDisplayManager.WriteLineToConsole($"{message} - {fileDownload.DownloadProgress}% Completed at {DateTime.Now:HH:mm:ss.fff}", fileDownload.consoleLine);
                break;
            case FileDownloadStatus.Cancelled:
                ConsoleDisplayManager.WriteLineToConsole($"{message} - Cancelled at {DateTime.Now:HH:mm:ss.fff}", fileDownload.consoleLine);
                break;
        }
    }
}
