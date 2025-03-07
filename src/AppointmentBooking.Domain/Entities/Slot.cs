using AppointmentBooking.Domain.Common;

namespace AppointmentBooking.Domain.Entities;

public class Slot : BaseEntity
{
    public required int SalesManagerId { get; init; }
    public required SalesManager SalesManager { get; init; } = null!;
    public required DateTimeOffset StartDate { get; init; }
    public required DateTimeOffset EndDate { get; init; }
    public required bool Booked { get; init; }
}