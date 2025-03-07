using AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBooking.WebApi.Controllers;

[ApiController]
[Route("calendar")]
public class CalendarController(IMediator mediator) : ControllerBase
{
    [HttpPost("query")]
    public async Task<IActionResult> Query(GetAvailableSlotsQuery query)
    {
        return Ok(await mediator.Send(query));
    }
}