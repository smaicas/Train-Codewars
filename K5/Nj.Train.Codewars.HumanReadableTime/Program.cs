Console.WriteLine(TimeFormat.GetReadableTime(359999));

public static class TimeFormat
{
    public static string GetReadableTime(int seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);

        return $"{(int)time.TotalHours:D2}:{time:\\:mm\\:ss}";
    }
}