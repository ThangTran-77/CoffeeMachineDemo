using System.Text.Json;
using System.Text.Json.Serialization;

namespace Commons.Converters;

public class DateTimeWithTimezoneConverter :  JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-ddTHH:mm:sszzz"; // yyyy-MM-dd'T'HH:mm:sszzz

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}