using AppointmentBooking.Domain.Enums;
using MediatR;

namespace AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;

public record GetAvailableSlotsQuery : IRequest<List<AvailableSlotViewModel>>
{
    public required DateOnly Date { get; init; }
    public required IReadOnlyCollection<Product> Products { get; init; } = new HashSet<Product>();
    public required Language Language { get; init; }
    public required CustomerRating Rating { get; init; }
}