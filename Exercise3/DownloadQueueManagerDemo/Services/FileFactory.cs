using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadQueueManagerDemo.Services;
public class FileFactory
{
    public PriorityQueue<FileDownload, int> CreateFileDownloadQueues(string[] urls)
    {
        PriorityQueue<FileDownload, int> fileDownloads = new(urls.Length);
        Parallel.For(0, urls.Length, i =>
        {
            int index = i;
            var url = urls[index];
            int priority = RandomUtil.GetRandomNumber(1, 4);
            var file = new FileDownload
            {
                Url = url,
                Index = index + 1,
                DownloadTime = RandomUtil.GetRandomNumber(300, 600) * 10
            };
            file.OnProgressChanged += ProgressHandler.ProgressChange;
            file.OnStatusChanged += StatusHandler.StatusChanged;
            fileDownloads.Enqueue(file, priority);
        });
        // Sort the file downloads by index
        return fileDownloads;
    }
}
