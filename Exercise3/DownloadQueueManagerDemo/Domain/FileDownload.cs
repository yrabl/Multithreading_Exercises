namespace DownloadQueueManagerDemo.Domain;
public class FileDownload
{
    public string Url { get; set; }
    public int Index { get; set; }
    public int DownloadTime { get; set; }
    public int ElapsedTime { get; set; } = 0;

    public int consoleLine { get; set; }

    private FileDownloadStatus _fileDownloadStatus = FileDownloadStatus.None;

    public FileDownloadStatus FileDownloadStatus
    {
        get => _fileDownloadStatus;
        set
        {
            if(_fileDownloadStatus != value)
            {
                _fileDownloadStatus = value;
                OnStatusChanged?.Invoke(this, _fileDownloadStatus);
            }
            
        }
    }

    private int _downloadProgress = 0;
    private int _lastNotifiedProgress = 0;

    public int DownloadProgress
    {
        get => _downloadProgress;
        set
        {
            _downloadProgress = value;
            if (FileDownloadStatus == FileDownloadStatus.InProgress)
            {
                if (_downloadProgress == 100)
                {
                    FileDownloadStatus = FileDownloadStatus.Completed;
                    // OnDownloadCompleted?.Invoke(this);
                }
                else if (_downloadProgress >= _lastNotifiedProgress + 10)
                {
                    _lastNotifiedProgress = _downloadProgress / 10 * 10;

                    OnProgressChanged?.Invoke(this, _downloadProgress);
                }
            }
        }
    }

    public event ProgressChangedHandler OnProgressChanged;

    public event StatusChangedHandler OnStatusChanged;

    public delegate void ProgressChangedHandler(FileDownload fileDownload, int progress);
    public delegate void StatusChangedHandler(FileDownload fileDownload, FileDownloadStatus fileDownloadStatus);
}
