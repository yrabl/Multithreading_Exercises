using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesDownloaderDemo.Utils;
public static class DownloadFileUtil
{
    public static void DownloadFiles(string[] urls)
    {
        Parallel.ForEach(
            urls.Select((url, i) => (url, Index: i + 1)),
            new ParallelOptions { MaxDegreeOfParallelism = 3},
            pair =>
            {
                DownloadFile(pair.url, pair.Index);
            });
    }

    private static void DownloadFile(string url, int index)
    {

        Console.WriteLine($"Start downloading file {index} from {url} at {DateTime.Now:HH:mm:ss.fff}");
        // Simulate file download
        int downloadTime = RandomUtil.GetRandomNumber(2000, 5000);
        Thread.Sleep(downloadTime);
        Console.WriteLine($"Finished downloading file {index} from {url} at {DateTime.Now:HH:mm:ss.fff} ({downloadTime:N0} ms)");
    }
}
