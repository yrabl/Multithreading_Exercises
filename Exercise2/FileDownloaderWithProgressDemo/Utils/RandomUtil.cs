namespace FileDownloaderWithProgressDemo.Utils;
public static class RandomUtil
{
    // Create a ThreadLocal instance of Random to ensure each thread has its own instance
    private static readonly ThreadLocal<Random> _random = new(() => new Random());

    public static int GetRandomNumber(int min, int max)
    {
        var rand = _random.Value;
        if (rand == null)
        {
            rand = new Random();
        }
        return rand.Next(min, max);
    }
}
