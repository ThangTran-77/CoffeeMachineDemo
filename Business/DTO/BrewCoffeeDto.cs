using System.Text.Json.Serialization;
using Commons.Converters;

namespace Business.DTO;

public class BrewCoffeeDto
{
    public string Message { get; set; }
    [JsonConverter(typeof(DateTimeWithTimezoneConverter))]
    public DateTime Prepared { get; set; }
}