using System.Text.Json.Serialization;

namespace AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;

public class AvailableSlotViewModel
{
    [JsonPropertyName("available_count")] public int AvailableCount { get; set; }
    [JsonPropertyName("start_date")] public DateTimeOffset StartDate { get; set; }
}