using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AppointmentBooking.WebApi.Helpers;

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    private const string TzDateFormat = "yyyy-MM-ddThh:mm:ss.fffZ";

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTimeOffset.Parse(reader.GetString()!, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(TzDateFormat, CultureInfo.InvariantCulture));
    }
}