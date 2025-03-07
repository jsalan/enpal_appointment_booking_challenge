using FluentValidation;

namespace AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;

public class GetAvailableSlotsQueryValidator : AbstractValidator<GetAvailableSlotsQuery>
{
    public GetAvailableSlotsQueryValidator()
    {
        RuleFor(query => query.Products).NotEmpty();
    }
}