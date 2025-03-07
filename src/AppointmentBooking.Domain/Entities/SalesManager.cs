using AppointmentBooking.Domain.Common;
using AppointmentBooking.Domain.Enums;

namespace AppointmentBooking.Domain.Entities;

public class SalesManager : BaseEntity
{
    public required string Name { get; init; }
    public IReadOnlyCollection<Language> Languages { get; init; } = new HashSet<Language>();
    public IReadOnlyCollection<Product> Products { get; init; } = new HashSet<Product>();
    public IReadOnlyCollection<CustomerRating> CustomerRatings { get; init; } = new HashSet<CustomerRating>();
    public IReadOnlyCollection<Slot> Slots { get; init; } = new HashSet<Slot>();
}