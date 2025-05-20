namespace FileDownloaderWithProgressDemo.Domain;
public class FileDownload
{
    public string Url { get; set; }
    public int Index { get; set; }
    public int DownloadTime { get; set; }
    public int ElapsedTime { get; set; } = 0;



    private int _downloadProgress = 0;
    private int _lastNotifiedProgress = 0;

    public int DownloadProgress
    {
        get => _downloadProgress;
        set
        {
            _downloadProgress = value;
            if (!IsCancelled)
            {
                if (_downloadProgress == 100)
                {
                    OnDownloadCompleted?.Invoke(this);
                }
                else if (_downloadProgress >= _lastNotifiedProgress + 10)
                {
                    _lastNotifiedProgress = _downloadProgress / 10 * 10;

                    OnProgressChanged?.Invoke(this, _downloadProgress);
                }
            }
        }
    }
    private bool _isCancelled = false;

    public bool IsCancelled
    {
        get => _isCancelled;

        set
        {
            if (!_isCancelled && value)
            {
                _isCancelled = true;
                OnDownloadCancelled?.Invoke(this);
            }
        }
    }

    public event ProgressChangedHandler OnProgressChanged;

    public event DownloadCompletedHandler OnDownloadCompleted;

    public event DownloadCancelledHandler OnDownloadCancelled;

    public delegate void ProgressChangedHandler(FileDownload fileDownload, int progress);
    public delegate void DownloadCompletedHandler(FileDownload fileDownload);
    public delegate void DownloadCancelledHandler(FileDownload fileDownload);
}
