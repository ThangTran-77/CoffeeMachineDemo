namespace Commons.Helpers;

public static class KoreaDateTimeHelper
{
    private static readonly string _koreaTimeZone = "Asia/Seoul";

    public static DateTime Now()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(_koreaTimeZone));
    }
}