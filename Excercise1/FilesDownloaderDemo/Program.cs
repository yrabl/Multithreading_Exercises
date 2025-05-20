using FilesDownloaderDemo.Utils;
using System.Diagnostics;

internal class Program
{
    

    private static void Main(string[] args)
    {
        // Define the URLs to download for demo purposes
        string[] urls =
        {
            "https://example.com/file1.txt",
            "https://example.com/file2.txt",
            "https://example.com/file3.txt",
            "https://example.com/file4.txt",
            "https://example.com/file5.txt",
            "https://example.com/file6.txt",
            "https://example.com/file7.txt",
            "https://example.com/file8.txt",
            "https://example.com/file9.txt",
            "https://example.com/file10.txt"
        };
        DownloadFileUtil.DownloadFiles(urls);
        Console.WriteLine("All downloads completed.");
    }

    

    

    
}