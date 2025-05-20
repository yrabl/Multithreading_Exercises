using FileDownloaderWithProgressDemo.Domain;
using System.Threading.Tasks;

namespace FileDownloaderWithProgressDemo.Services;
public class FileFactory
{
    public List<FileDownload> CreateFileDownloads(string[] urls)
    {
        List<FileDownload> fileDownloads = new (urls.Length);
        Parallel.For(0, urls.Length, i =>
        {
            int index = i;
            var url = urls[index];
            var file = new FileDownload
            {
                Url = url,
                Index = index+1,
                DownloadTime = RandomUtil.GetRandomNumber(300, 600) * 10
            };
            file.OnProgressChanged += ProgressHandler.ProgressChange;
            file.OnDownloadCompleted += ProgressHandler.DownloadCompleted;
            file.OnDownloadCancelled += ProgressHandler.DownloadCancelled;
            fileDownloads.Add(file);
        });
        // Sort the file downloads by index
        fileDownloads = [.. fileDownloads.OrderBy(f => f.Index)];
        return fileDownloads;
    }
}
