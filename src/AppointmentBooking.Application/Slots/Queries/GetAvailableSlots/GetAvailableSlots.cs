using AppointmentBooking.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;

public class GetAvailableSlotsQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetAvailableSlotsQuery, List<AvailableSlotViewModel>>
{
    public async Task<List<AvailableSlotViewModel>> Handle(GetAvailableSlotsQuery request,
        CancellationToken cancellationToken)
    {
        var startDateTimeOffset = new DateTimeOffset(request.Date, TimeOnly.MinValue, TimeSpan.Zero);

        return await context.Slots
            .AsNoTracking()
            .Where(slot =>
                slot.StartDate.Date == startDateTimeOffset.Date &&
                slot.EndDate.Date == startDateTimeOffset.Date &&
                !slot.Booked &&
                request.Products.All(product => slot.SalesManager.Products.Contains(product)) &&
                slot.SalesManager.Languages.Contains(request.Language) &&
                slot.SalesManager.CustomerRatings.Contains(request.Rating) &&
                // Looking for overlaps
                !context.Slots.Any(bookedSlot =>
                    bookedSlot.StartDate < slot.EndDate &&
                    bookedSlot.EndDate > slot.StartDate &&
                    bookedSlot.Booked &&
                    bookedSlot.SalesManagerId == slot.SalesManagerId))
            .GroupBy(slot => slot.StartDate)
            .Select(slotGroup => new AvailableSlotViewModel
            {
                AvailableCount = slotGroup.Count(),
                StartDate = slotGroup.Key
            })
            .OrderBy(model => model.StartDate)
            .ToListAsync(cancellationToken);
    }
}